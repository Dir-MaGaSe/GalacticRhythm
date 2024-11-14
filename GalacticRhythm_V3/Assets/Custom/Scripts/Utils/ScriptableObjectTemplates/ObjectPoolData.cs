using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectsPoolData", menuName = "Pooling/ObjectsPoolData")]
public class ObjectsPoolData : ScriptableObject
{
    [System.Serializable]
    public class PoolItem
    {
        public string poolKey;  // Identificador del objeto
        public GameObject prefab;  // Prefab del objeto
        public int poolSize;  // Tamaño del pool
        public float spawnProbability;  // Probabilidad de aparición
    }

    public List<PoolItem> poolItems;
}
