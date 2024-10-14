using System.Collections.Generic;
using UnityEngine;

public class PoolingManagerByList : MonoBehaviour
{
    /**/
    private Dictionary<string, List<GameObject>> poolDictionary = new Dictionary<string, List<GameObject>>();
    public static PoolingManagerByList Instance;

    void Awake()
    {
        Instance = this;
    }

    public void InitializePools(ObjectPoolData poolData)
    {
        foreach (var item in poolData.poolItems)
        {
            if (!poolDictionary.ContainsKey(item.poolKey))
            {
                List<GameObject> objectPool = new List<GameObject>();
                for (int i = 0; i < item.poolSize; i++)
                {
                    GameObject obj = Instantiate(item.prefab);
                    obj.SetActive(false);
                    objectPool.Add(obj);
                }
                poolDictionary.Add(item.poolKey, objectPool);
            }
        }
    }

    public GameObject GetPooledObject(string poolKey)
    {
        if (poolDictionary.ContainsKey(poolKey))
        {
            foreach (GameObject obj in poolDictionary[poolKey])
            {
                if (!obj.activeInHierarchy)
                {
                    return obj;
                }
            }

            // Si no hay objetos disponibles, crear uno nuevo (opcional)
            GameObject prefab = poolDictionary[poolKey][0];
            GameObject newObj = Instantiate(prefab);
            newObj.SetActive(false);
            poolDictionary[poolKey].Add(newObj);
            return newObj;
        }

        Debug.LogWarning("No se encontró ningún pool con la clave: " + poolKey);
        return null;
    }
}
