using UnityEngine;

public class DefaultCollisionHandler : ICollisionHandler
{
    public void HandleCollision(Collider2D collision, ProjectilePoolData config)
    {
        // Lógica de colisión para proyectiles por defecto
        if (collision.gameObject.CompareTag("Enemy/Minion"))
        {
            Debug.Log("La bala impacto con: " + collision.gameObject.tag);
            if (collision.TryGetComponent(out Life enemyLife))
            {
                enemyLife.TakeDamage(config.damage);
            }
        }
            
        if (collision.gameObject.CompareTag("Enemy/Boss"))
        {
            Debug.Log("La bala impacto con: " + collision.gameObject.tag);
            if (collision.TryGetComponent(out Life enemyLife))
            {
                enemyLife.TakeDamage(config.damage);
            }
        }
            
        if (collision.gameObject.CompareTag("Spawn/NotCollectible"))
        {
            Debug.Log("La bala impacto con: " + collision.gameObject.tag);
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Projectile/Enemy"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}

