using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 2f;

    public GameObject obstacleExplosion;
    void Start()
    {
        Destroy(gameObject, 5f);
    }
    void Update()
    {
        transform.position = (Vector2)transform.position + Vector2.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            GameObject effect = Instantiate(obstacleExplosion, transform.position, transform.rotation);
            Destroy(effect, 5);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
