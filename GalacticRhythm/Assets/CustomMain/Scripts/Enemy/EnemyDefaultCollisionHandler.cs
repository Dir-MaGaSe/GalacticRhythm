using UnityEngine;

public class EnemyDefaultCollisionHandler : ICollisionHandler
{
    public void HandleCollision(Collider2D collision, ProjectilePoolData config)
    {
        // Lógica de colisión para proyectiles enemigos por defecto
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("La bala enemiga impacto con el jugador");
            if (collision.TryGetComponent(out Life playerLife))
            {
                playerLife.TakeDamage(config.damage);
            }
        }
        if (collision.gameObject.CompareTag("Projectile/Player"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
