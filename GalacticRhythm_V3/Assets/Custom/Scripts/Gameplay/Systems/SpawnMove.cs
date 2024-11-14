using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMove : MonoBehaviour
{
    public float speed, lifetime;
    public Vector2 direction;

    private void OnEnable()
    {
        StartCoroutine(DeactivateAfterTime(lifetime));
    }
    void FixedUpdate()
    {
        transform.position += (Vector3)direction * speed * Time.fixedDeltaTime;
    }
    private IEnumerator DeactivateAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
    public float GetLifeTime(){ return this.lifetime; }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (this.gameObject.CompareTag("Spawn/Collectible"))
            {
                // Aplica el efecto del potenciador
                //PlayerController.Instance.ApplyPowerUp();
                gameObject.SetActive(false);
            }
            else if (this.gameObject.CompareTag("Enemy/Minion"))
            {
                // Aplica daño al jugador
                //PlayerController.Instance.TakeDamage();
                gameObject.SetActive(false);
            }
        }
    }
}
