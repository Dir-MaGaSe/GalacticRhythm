using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)//Al entrar en colisión
    {
        if (collision.tag == "Player") //Si la colisión es con un objeto que tenga el tag "Player"...
        {
            Player player = collision.GetComponent<Player>();
            player.points++; //Aumentamos la puntuación en 1
            Destroy(this.gameObject); //Destruimos este objeto
        }
    }
}
