using UnityEngine;

[CreateAssetMenu(fileName = "NewProjectileBase", menuName = "GalacticRhythm/SpawnElements/ProjectileElement")]
public class ProjectileElement : ElementBase
{
    [Header("Configuración básica del proyectil")]
    [Range(0.1f, 5f)] public float fireRate = 2f;
}