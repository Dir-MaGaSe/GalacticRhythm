using UnityEngine;

[CreateAssetMenu(fileName = "ProjectilePoolData", menuName = "Pooling/ProjectilePoolData")]
public class ProjectilePoolData : ScriptableObject
{
    //Configuracion Basica
    public int damage;
    public float speed, lifetime;
    public string poolTag;
    
    //Diferentes tipos de projectiles
    public enum ProjectileType { 
        Default, Explosive, 
        EnemyDefault 
        }
    public ProjectileType projectileType = ProjectileType.Default;

    //Variables Extras
    public float explosionRadius = .5f;
    
    //Manejo de efectos
    /*public GameObject visualEffect; // Para efectos visuales futuros
    public AudioClip soundEffect; // Para sonidos futuros*/
}