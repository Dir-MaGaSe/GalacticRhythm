using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameController : MonoBehaviour
{
    public static float gameSpeed; //Creamos la variable gameSpeed que controlara la velocidad del juego.

    [Range(0, 5)] //Limita el valor de gameSpeedRegulator entre 0 y 5.
    public float gameSpeedRegulator; //Con esta variable podemos regular la velocidad
    public float speedRate = 0.5f; //Cuanto incrementara gameSpeedRegulator por segundo
    public float gameSpeedMax = 5; //El valor maximo que gameSpeedRegulator alcanzara
    void Update()
    {
        if (gameSpeedRegulator <= gameSpeedMax) //Verificamos si gameSpeedRegulator es menor o igual a gameSpeedMax
        {
            gameSpeedRegulator += speedRate * Time.deltaTime; //Incrementamos la velocidad del juego en base a speedRate
        }
        gameSpeed = gameSpeedRegulator; //La velocidad del juego sera igual a la velocidad de gameSpeedRegulator
    }
}
