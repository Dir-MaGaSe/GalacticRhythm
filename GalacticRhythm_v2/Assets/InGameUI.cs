using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    UIDocument HUD;
    Scene mainMenu;

    // HUD
    VisualElement powerUpImage;
    ProgressBar lifeBar;
    Button pauseButton;

    // Pause Panel
    VisualElement pause_Container;
    Button pause_resumeButton, pause_restartButton, pause_settingsButton, pause_returnButton;

    // Options Panel
    VisualElement options_Scrim, options_Container;
    Button options_musicButton, options_soundButton, options_exitButton;

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

        // Pause Panel Queries
        pause_Container = root.Q<VisualElement>(className:"pause_container");
        pause_resumeButton = root.Q<Button>("btnResume");
        pause_restartButton = root.Q<Button>("btnRestart");
        pause_settingsButton = root.Q<Button>("btnSettings");
        pause_returnButton = root.Q<Button>("btnReturn");
        

        // Options Panel Queries
        options_Scrim = root.Q<VisualElement>(className:"options_scrim");
        options_Container = root.Q<VisualElement>(className:"options_container");
        options_musicButton = root.Q<Button>("btnMusic");
        options_soundButton = root.Q<Button>("btnSound");
        options_exitButton = root.Q<Button>(className:"options_btn-exit");
        // Callbacks
        options_musicButton.RegisterCallback<ClickEvent>(ActivateMusic);
        options_soundButton.RegisterCallback<ClickEvent>(ActivateSound);
        options_exitButton.RegisterCallback<ClickEvent>(CloseOptionsPanel);

        // Previous Scene
    }

    private void CloseOptionsPanel(ClickEvent evt)
    {
        throw new NotImplementedException();
    }

    private void ActivateSound(ClickEvent evt)
    {
        throw new NotImplementedException();
    }

    private void ActivateMusic(ClickEvent evt)
    {
        throw new NotImplementedException();
    }

    private void ReturnTitle(ClickEvent evt)
    {
        throw new NotImplementedException();
    }

    private void OpenOptionsPanel(ClickEvent evt)
    {
        throw new NotImplementedException();
    }
    private void OpenPausePanel(ClickEvent evt)
    {
        throw new NotImplementedException();
    }

}
