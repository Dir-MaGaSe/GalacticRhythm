using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectsPoolData", menuName = "Pooling/ObjectsPoolData")]
public class ObjectsPoolData : ScriptableObject
{
    [System.Serializable]
    public class PoolItem
    {
        public string poolKey;
        public GameObject prefab;
        public int poolSize;
        // Añade cualquier otro parámetro que puedas necesitar en el futuro
    }

    public List<PoolItem> poolItems;
}
