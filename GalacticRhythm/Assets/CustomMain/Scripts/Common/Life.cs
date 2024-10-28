using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
    public int maxLife;
    [HideInInspector] public int currentLife;

    UnityEvent<int> OnChanging;

    void Start()
    {
        currentLife = maxLife;
        //OnChanging.Invoke(currentLife);
    }

    // Update is called once per frame
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

        //OnChanging.Invoke(currentLife);

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

        //OnChanging.Invoke(currentLife);
    }
}
