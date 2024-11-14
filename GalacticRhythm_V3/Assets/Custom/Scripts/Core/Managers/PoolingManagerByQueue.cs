using UnityEngine;
using System.Collections.Generic;

public class PoolingManagerByQueue : MonoBehaviour
{
    public static PoolingManagerByQueue Instance;
    private Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Awake()
    {
        Instance = this;
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
    }
    public List<Pool> ProjectilePools;

    [System.Serializable]
    public class Pool
    {
        public GameObject prefab;
        public int size;
    }

    void Start()
    {
        foreach (Pool pool in ProjectilePools)
        {
            CreatePool(pool.prefab.GetComponent<Projectile>().config.poolTag, pool.prefab, pool.size);
        }
    }

    public void CreatePool(string tag, GameObject prefab, int poolSize)
    {
        Queue<GameObject> objectPool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }
        poolDictionary.Add(tag, objectPool);
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
            return null;
        }

        if (poolDictionary[tag].Count == 0)
        {
            Debug.LogWarning("No available objects in pool for tag: " + tag);
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}
