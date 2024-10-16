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
}
