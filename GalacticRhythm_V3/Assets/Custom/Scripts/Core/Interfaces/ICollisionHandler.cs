using UnityEngine;

public interface ICollisionHandler
{
    void HandleCollision(Collider2D collision, ProjectilePoolData config);
}
