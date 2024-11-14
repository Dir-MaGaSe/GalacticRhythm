using UnityEngine;

[CreateAssetMenu(fileName = "NewFallingElement", menuName = "GalacticRhythm/SpawnElements/FallingElement")]
public class FallingElement : ElementBase
{
    [Header("Configuraci�n de F�sicas")]
    [Range(0.1f, 1f)] public float spawnProbability = 0.5f;
    [Range(0.1f, 5f)] public float fallSpeed = 2f;
}