using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class ProjectileBehavior : MonoBehaviour
{
    //Initial
    private ProjectileElement projectileData; // Almacena el scriptable asociado
    private ObjectPool<GameObject> pool;
    
    //Physics
    private Rigidbody2D rb; // Componente de física
    
    //Art
    private SpriteRenderer imageRender; // Sprite
    private AudioClip soundEffect; // Efecto de sonido
    private Animator animator; // Animacion
    private GameObject visualEffect; // Efecto Visual
    
    private void OnEnable() 
    {
        // Inicializa el elemento cuando se activa
        if (projectileData != null) { Initialize(projectileData, pool); }
    }

    public void Initialize(ProjectileElement data, ObjectPool<GameObject> objectPool)
    {
        rb = GetComponent<Rigidbody2D>();
        imageRender = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        pool = objectPool; // Almacena la referencia de la pool
        projectileData = data; // Guarda la referencia al scriptable
        
        imageRender.sprite = data.elementSprite; // Asigna el sprite del scriptable
        soundEffect = data.elementAudio; // Almacena el efecto de sonido del scriptable
        animator = data.elementAnimator; // Almacena el animator del scriptable para controlar las animaciones
        visualEffect = data.elementVisualEffect; // Almacena el efecto visual del scriptable
    }

    private void Start() 
    {
        StartCoroutine(DeactivateAfterTime(projectileData.lifetime));
    }
    
    private void FixedUpdate() 
    {
        // Aplica la velocidad definida en el scriptable
        if (this.gameObject.tag == "Projectile/Player") {rb.velocity = Vector2.up * projectileData.moveSpeed;}
        if (this.gameObject.tag == "Projectile/Enemy") {rb.velocity = Vector2.down * projectileData.moveSpeed;}
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    IEnumerator DeactivateAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        ReturnToPool();
    }

    // Función para devolver el objeto a la pool
    private void ReturnToPool()
    {
        if (pool != null)
        {
            pool.Release(gameObject);
        }
        else
        {
            Debug.LogWarning("Pool no asignada para este objeto");
        }
    }
}