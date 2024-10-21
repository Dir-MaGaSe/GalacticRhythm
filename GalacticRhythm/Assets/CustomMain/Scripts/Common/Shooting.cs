using UnityEngine;

public class Shooting : MonoBehaviour
{
    public ProjectilePoolData projectileConfig;
    public Transform firePoint;
    public float fireRate = 0.5f;

    private float nextFireTime = 0f;

    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void Shoot()
    {
        GameObject projectile = PoolingManagerByQueue.Instance.SpawnFromPool(projectileConfig.poolTag, firePoint.position, firePoint.rotation);
        if (projectile != null)
        {
            projectile.GetComponent<Projectile>().config = projectileConfig;
        }
    }

    /*// Permite ajustar la cadencia de disparo dinámicamente
    public void AdjustFireRate(float multiplier)
    {
        fireRate *= multiplier;
    }*/
}
