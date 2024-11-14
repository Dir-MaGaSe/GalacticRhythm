using UnityEngine;

[CreateAssetMenu(fileName = "NewElement", menuName = "GalacticRhythm/SpawnElements/Base")]
public class ElementBase : ScriptableObject
{
    [Header("Configuración Básica")]
    //Initial
    public string elementName;
    public int damage;
    public float lifetime;
    //Art
    public Sprite elementSprite;
    public AudioClip elementAudio;
    public Animator elementAnimator;
    public GameObject visualEffect;
}