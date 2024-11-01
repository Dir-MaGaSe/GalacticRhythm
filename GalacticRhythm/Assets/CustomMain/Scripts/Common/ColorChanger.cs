using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Renderer objectRenderer; // Referencia al renderer del objeto (para obstáculos, enemigos, etc.)
    private MusicManager musicManager;

    void Start()
    {
        musicManager = FindObjectOfType<MusicManager>();
        musicManager.OnLowDetected += ChangeToLowColor; // Suscribir evento de bajos
        musicManager.OnHighDetected += ChangeToHighColor; // Suscribir evento de altos
    }

    void ChangeToLowColor(float intensity)
    {
        Color newColor = new Color(0.2f * intensity, 0.4f, 0.6f); // Colores fríos para bajos
        objectRenderer.material.color = newColor;
    }

    void ChangeToHighColor(float intensity)
    {
        Color newColor = new Color(0.9f, 0.3f * intensity, 0.5f); // Colores cálidos para altos
        objectRenderer.material.color = newColor;
    }
    
    void OnDisable() 
    {
        musicManager.OnLowDetected -= ChangeToLowColor;
        musicManager.OnHighDetected -= ChangeToHighColor;
    }
}
