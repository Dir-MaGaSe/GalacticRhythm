using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
    //Life settings
    public int maxLife;
    [HideInInspector] public int currentLife;

    //

    void Start()
    {
        currentLife = maxLife;
    }
    public void TakeDamage(int damage)
    {
        int temporaryLife = currentLife - damage;
        
        if(temporaryLife < 0)
        {
            currentLife = 0;
        }
        else
        {
            currentLife = temporaryLife;
        }

        if(currentLife <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void Heal(int cure)
    {
        int temporaryLife = currentLife + cure;
        
        if(temporaryLife > maxLife)
        {
            currentLife = maxLife;
        }
        else
        {
            currentLife = temporaryLife;
        }
    }
}
