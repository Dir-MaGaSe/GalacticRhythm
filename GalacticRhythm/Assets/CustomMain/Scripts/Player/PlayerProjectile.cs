using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : Projectile
{
    public override void OnTriggerEnter2D(Collider2D collision) 
    {
         if (collision.CompareTag(collisionTag))
        {
            // Gestionar explosión desde el PoolingManager
            GameObject effect = PoolingManagerByQueue.Instance.SpawnFromPool(effectTag, transform.position, Quaternion.identity);
            collision.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
