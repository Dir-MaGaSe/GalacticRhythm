using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _waitingTime;
    private float _timeForNextShoot = 0.0f;

    private void Update() {
        if(_timeForNextShoot > 0){
               _timeForNextShoot = Time.deltaTime;
        }
        if(Input.GetButtonDown("Fire1")){
            if(_timeForNextShoot <= 0){
                Shoot();
                _timeForNextShoot = _waitingTime;
            }
        }
    }

    private void Shoot(){
        Instantiate(_bulletPrefab, _spawnPoint.position, _spawnPoint.rotation);
    }
}
