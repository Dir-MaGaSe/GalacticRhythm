using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class playerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Vector2 _direction;
    private Rigidbody2D _rb2D;

    private void Start() {
        _rb2D = GetComponent<Rigidbody2D>();
    }
    private void Update() {
        
    }
    private void FixedUpdate() {
        _rb2D.MovePosition(_rb2D.position + _direction * _moveSpeed * Time.fixedDeltaTime);
    }
}
