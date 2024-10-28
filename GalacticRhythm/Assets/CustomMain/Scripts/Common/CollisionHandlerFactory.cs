using UnityEngine;

public static class CollisionHandlerFactory
{
    public static ICollisionHandler GetHandler(ProjectilePoolData.ProjectileType projectileType)
    {
        switch (projectileType)
        {
            case ProjectilePoolData.ProjectileType.EnemyDefault:
                return new EnemyDefaultCollisionHandler();
            case ProjectilePoolData.ProjectileType.Explosive:
                return new ExplosiveCollisionHandler();
            default:
                return new DefaultCollisionHandler();
        }
    }
}
