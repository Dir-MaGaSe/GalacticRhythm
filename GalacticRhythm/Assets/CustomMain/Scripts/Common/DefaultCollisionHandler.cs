using UnityEngine;

public class DefaultCollisionHandler : ICollisionHandler
{
    public void HandleCollision(Collider2D collision, ProjectilePoolData config)
    {
        // Lógica de colisión para proyectiles por defecto
        if (collision.gameObject.CompareTag("Enemy/Minion"))
        {
            Debug.Log("La bala impacto con: " + collision.gameObject.tag);
            /*// Suponiendo que los enemigos tienen un componente Health
            Health enemyHealth = collision.gameObject.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(config.damage);
            }*/
        }
            
        if (collision.gameObject.CompareTag("Enemy/Boss"))
        {
            Debug.Log("La bala impacto con: " + collision.gameObject.tag);
            /*// Suponiendo que los enemigos tienen un componente Health
            Health enemyHealth = collision.gameObject.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(config.damage);
            }*/
        }
            
        if (collision.gameObject.CompareTag("Spawn/NotCollectible"))
        {
            Debug.Log("La bala impacto con: " + collision.gameObject.tag);
        }
    }
}

