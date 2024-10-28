using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int points;
    public Laser laserPrefab;
    public float shootInterval;
    public float shootTimer;
    public Transform shootPoint;
    public Transform shootPointTwo;

    // Update is called once per frame
    void Update()
    {
        Move();
        shootTimer -= Time.deltaTime;
        Shoot();
    }

    void Shoot()
    {
        if (shootTimer <= 0)
        {
            Instantiate(laserPrefab, shootPoint.position, Quaternion.identity);
            Instantiate(laserPrefab, shootPointTwo.position, Quaternion.identity);
            shootTimer = shootInterval;
        }
    }

    void Move()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 realPos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = realPos;
        }
    }
}
