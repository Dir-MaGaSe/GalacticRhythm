using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public ProjectilePoolData projectileConfig;
    public Transform firePoint;
    public int numberOfProjectiles = 1;
    public float fireRate = 1f; 
    public string poolTag;
    private float nextFireTime;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        for (int i = 0; i < numberOfProjectiles; i++)
        {
            GameObject projectile = PoolingManagerByQueue.Instance.SpawnFromPool(poolTag, firePoint.position, firePoint.rotation);
            Projectile projScript = projectile.GetComponent<Projectile>();
            projScript.Initialize(projectileConfig);
        }
    }
}
