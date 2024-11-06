using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    UIDocument HUD;
    public GameObject pauseMenu;

    // HUD
    VisualElement powerUpImage;
    ProgressBar lifeBar;
    Button pauseButton;

    private void OnEnable() 
    {
        HUD = this.GetComponent<UIDocument>();
        VisualElement root = HUD.rootVisualElement;

        // HUD Queries
        powerUpImage = root.Q<VisualElement>("imgPowerUp");
        lifeBar = root.Q<ProgressBar>("lifeBar");
        pauseButton = root.Q<Button>("btnPause");
        // Callbacks
        pauseButton.RegisterCallback<ClickEvent>(OpenPausePanel);
    }
    private void OpenPausePanel(ClickEvent evt)
    {
        Debug.Log("En pausa");
        Time.timeScale = 0f;
        pauseMenu.gameObject.SetActive(true);
    }
}
