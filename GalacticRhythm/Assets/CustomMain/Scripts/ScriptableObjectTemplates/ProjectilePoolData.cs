using UnityEngine;

[CreateAssetMenu(fileName = "ProjectilePoolData", menuName = "Pooling/ProjectilePoolData")]
public class ProjectilePoolData : ScriptableObject
{
    public float speed, damage, lifetime;
    public Vector2 direction;
    public string effectTag, collisionTag;
}