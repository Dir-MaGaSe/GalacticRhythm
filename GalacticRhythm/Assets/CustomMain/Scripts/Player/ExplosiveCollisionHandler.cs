using UnityEngine;

public class ExplosiveCollisionHandler : ICollisionHandler
{
    public void HandleCollision(Collider2D collision, ProjectilePoolData config)
    {
        // Lógica de colisión para proyectiles explosivos
        // Por ejemplo: infligir daño en área
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(collision.transform.position, config.explosionRadius);
        foreach (var enemy in enemiesHit)
        {
            /*Health enemyHealth = enemy.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(config.damage);
            }*/
            Debug.Log("Ataque de area");
        }
    }
}
