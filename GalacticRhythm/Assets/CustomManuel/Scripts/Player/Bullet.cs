using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _moveSpeed, _lifeTime;

    private void Update() {
        transform.Translate(Vector2.up * _moveSpeed * Time.deltaTime);
    }
}
