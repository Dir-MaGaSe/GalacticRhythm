using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private string effectTag, collisionTag;
    private float damage, speed, lifetime;
    private Vector2 direction;

    private void OnEnable()
    {
        StartCoroutine(DeactivateAfterTime(lifetime));
    }

    // FixedUpdate se usa para el procesamiento de movimiento
    void FixedUpdate()
    {
        transform.position += (Vector3)direction * speed * Time.fixedDeltaTime;
    }

    public void Initialize(ProjectilePoolData projectile)
    {
        this.direction = projectile.direction;
        this.damage = projectile.damage;
        this.speed = projectile.speed;
        this.lifetime = projectile.lifetime;
        this.effectTag = projectile.effectTag;
        this.collisionTag = projectile.collisionTag;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(collisionTag))
        {
            // Gestionar explosión desde el PoolingManager
            GameObject effect = PoolingManagerByQueue.Instance.SpawnFromPool(effectTag, transform.position, Quaternion.identity);
            collision.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }

    private IEnumerator DeactivateAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
