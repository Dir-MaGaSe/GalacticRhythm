using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class FallingElementBehavior : MonoBehaviour
{
    //Initial
    private FallingElement elementData; // Almacena el scriptable asociado
    private ObjectPool<GameObject> pool;
    private IEnumerator effectCoroutine; //Corutina para el manejo de powerups
    
    //Physics
    private Rigidbody2D rb; // Componente de física
    
    //Art
    private SpriteRenderer imageRender; // Render para el sprite del elemento
    private AudioClip soundEffect; // Efecto de sonido
    private Animator animator; // Animacion
    private GameObject visualEffect; // Efecto Visual
    
    private void OnEnable() 
    {
        // Inicializa el elemento cuando se activa
        if (elementData != null) { Initialize(elementData, pool); }
    }

    public void Initialize(FallingElement data, ObjectPool<GameObject> objectPool)
    {
        rb = GetComponent<Rigidbody2D>();
        imageRender = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        pool = objectPool; // Almacena la referencia de la pool
        elementData = data; // Guarda la referencia al scriptable
        
        imageRender.sprite = data.elementSprite; // Asigna el sprite del scriptable
        soundEffect = data.elementAudio; // Almacena el efecto de sonido del scriptable
        animator = data.elementAnimator; // Almacena el animator del scriptable para controlar las animaciones
        visualEffect = data.elementVisualEffect; // Almacena el efecto visual del scriptable

        effectCoroutine = null;
    }

    private void Start() 
    {
        StartCoroutine(DeactivateAfterTime(elementData.lifetime));
    }
    
    private void FixedUpdate() 
    {
        // Aplica la velocidad de caída definida en el scriptable
        rb.velocity = Vector2.down * elementData.fallSpeed;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Realiza las acciones necesarias según el tipo de elemento
        switch (elementData)
        {
            case PowerUpElement powerUp:

                if (other.gameObject.CompareTag("Player"))
                {
                    if(effectCoroutine == null)
                    {
                        effectCoroutine = ApplyEffectsCoroutine(powerUp.effectDuration, powerUp.effectMultiplier, powerUp.powerUpType);
                        StartCoroutine(effectCoroutine);
                    }
                    else
                    {
                        StopCoroutine(effectCoroutine);
                        effectCoroutine = ApplyEffectsCoroutine(powerUp.effectDuration, powerUp.effectMultiplier, powerUp.powerUpType);
                        StartCoroutine(effectCoroutine);
                    }

                    //AudioManager.Instance.PlayEffect(soundEffect);
                    ReturnToPool();
                }
                break;

            case EnemyElement enemy:
                
                if (other.gameObject.CompareTag("Player"))
                {
                    if (other.TryGetComponent(out Life playerLife))
                    {
                        playerLife.TakeDamage(elementData.contactDamage);
                    }
                    //AudioManager.Instance.PlayEffect(soundEffect);
                    ReturnToPool();
                }

                if (!other.gameObject.CompareTag("Enemy/Minion") || !other.gameObject.CompareTag("Projectile/Enemy"))
                {
                    ReturnToPool();
                }
                
                break;

            default:
                if (other.gameObject.CompareTag("Player"))
                {
                    if (other.TryGetComponent(out Life playerLife))
                    {
                        playerLife.TakeDamage(elementData.contactDamage);
                    }

                    //AudioManager.Instance.PlayEffect(soundEffect);
                    ReturnToPool();
                }
                break;
        }
    }

    private IEnumerator ApplyEffectsCoroutine(float duration, float multiplier, PowerUpElement.PowerUpType powerUpType)
    {
        //GameManager.Instance.CalculateSpeedBonus(multiplier, true);
        yield return new WaitForSeconds(duration);
        //GameManager.Instance.CalculateSpeedBonus(multiplier, false);
        effectCoroutine = null;
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