using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform borderRight, borderLeft;
    public float spawnInterval = 2f;
    public int maxObjectsOnScreen = 5;

    public ObjectsPoolData objectPoolData; // Referencia al ScriptableObject

    private int currentObjectsOnScreen = 0;

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
                Spawn();
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void Spawn()
    {
        // Seleccionar aleatoriamente un tipo de objeto del pool
        int randomIndex = Random.Range(0, objectPoolData.poolItems.Count);
        string poolKey = objectPoolData.poolItems[randomIndex].poolKey;

        float randomX = Random.Range(borderLeft.position.x, borderRight.position.x);
        Vector2 newPosition = new Vector2(randomX, transform.position.y);

        GameObject obj = PoolingManagerByList.Instance.GetPooledObject(poolKey);
        SpawnMove objLifeTime = obj.GetComponent<SpawnMove>();

        if (obj != null)
        {
            obj.transform.position = newPosition;
            obj.SetActive(true);
            currentObjectsOnScreen++;

            StartCoroutine(DeactivateAfterTime(obj, objLifeTime.GetLifeTime()));
        }
    }

    IEnumerator DeactivateAfterTime(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
        currentObjectsOnScreen--;
    }
}
