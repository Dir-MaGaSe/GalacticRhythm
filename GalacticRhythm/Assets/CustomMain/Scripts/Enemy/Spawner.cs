using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform borderRight, borderLeft;
    public float spawnInterval = 2f;
    public int maxObjectsOnScreen = 5;
    public ObjectsPoolData objectPoolData; // Referencia al ScriptableObject

    private int currentObjectsOnScreen = 0; // Objetos activos en pantalla
    private bool isPowerUpActive = true; // Controla si hay potenciador activo
    private float powerUpCooldown = 8f, powerUpTimer = 0f; // Tiempo para generar nuevo potenciador

    void Start()
    {
        // Inicializar los pools desde el ScriptableObject
        PoolingManagerByList.Instance.InitializePools(objectPoolData);

        // Iniciar la corutina de generación
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            if (currentObjectsOnScreen < maxObjectsOnScreen)
            {
                powerUpTimer += Time.deltaTime;
                if (isPowerUpActive)
                {
                    if (powerUpTimer >= powerUpCooldown)
                    {
                        isPowerUpActive = false;
                        powerUpTimer = 0;
                    }
                }
                Spawn();
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    void Spawn()
    {
        float totalProbability = 0;
        foreach (var item in objectPoolData.poolItems)
        {
            totalProbability += item.spawnProbability;
        }

        // Seleccionar aleatoriamente un tipo de objeto del pool segun la probabilidad
        float randomValue = Random.Range(0, totalProbability);
        float cumulativeProbability = 0;

        ObjectsPoolData.PoolItem selectedItem = null;
        foreach (var item in objectPoolData.poolItems)
        {
            cumulativeProbability += item.spawnProbability;
            if (randomValue <= cumulativeProbability)
            {
                selectedItem = item;
                break;
            }
        }

        if (selectedItem != null)
        {
            // Verifica si el objeto seleccionado es un potenciador y si ya hay uno activo
            if (selectedItem.poolKey == "PowerUp" && isPowerUpActive)
            {
                return;  // Evita generar un nuevo potenciador si ya hay uno
            }

            string poolKey = selectedItem.poolKey;

            // Selecciona una posicion aleatoria del eje X
            float randomX = Random.Range(borderLeft.position.x, borderRight.position.x);
            Vector2 newPosition = new Vector2(randomX, transform.position.y);

            // Crea un objeto de la Object Pool
            GameObject obj = PoolingManagerByList.Instance.GetPooledObject(poolKey);
            SpawnMove objLifeTime = obj.GetComponent<SpawnMove>();

            if (obj != null)
            {
                obj.transform.position = newPosition;
                obj.SetActive(true);
                currentObjectsOnScreen++;

                if (poolKey == "PowerUp")
                {
                    isPowerUpActive = true;  // Marca que el potenciador está activo
                }

                StartCoroutine(DeactivateAfterTime(obj, objLifeTime.GetLifeTime()));
            }
        }
    }

    IEnumerator DeactivateAfterTime(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
        currentObjectsOnScreen--;
    }
}