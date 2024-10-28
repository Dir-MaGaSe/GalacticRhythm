using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Projectile : MonoBehaviour
{
    public ProjectilePoolData config;
    private Rigidbody2D rb;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * config.speed;
        StartCoroutine(DeactivateAfterTime());
    }

    private IEnumerator DeactivateAfterTime()
    {
        yield return new WaitForSeconds(config.lifetime);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("ScreenBounds"))
        {
            ICollisionHandler handler = CollisionHandlerFactory.GetHandler(config.projectileType);
            handler.HandleCollision(collision, config);
            DeactivateProjectile();
        }
    }

    private void DeactivateProjectile()
    {
        gameObject.SetActive(false); // Desactiva el proyectil sin destruirlo
    }

    /*// Aplicar potenciadores u otros cambios dinámicos
    public void ApplyPowerUp(PowerUpType powerUp)
    {
        if (powerUp == PowerUpType.DamageBoost)
        {
            config.damage *= 1.5f; // Incrementa el daño en un 50%
        }
    }*/
}
