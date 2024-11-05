using System;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuUI : MonoBehaviour
{
    UIDocument mainMenu;
    GameObject previousScreen, nextScreen;

    // Main Menu
    VisualElement spaceshipImage;
    Button playButton, optionsButton, exitButton;

    //Option Panel
    VisualElement options_Scrim, options_Container;
    Button options_musicButton, options_soundButton, options_exitButton;

    private void OnEnable() 
    {
        mainMenu = this.GetComponent<UIDocument>();
        VisualElement root = mainMenu.rootVisualElement;

        // Main Menu Queries
        spaceshipImage = root.Q<VisualElement>("imgSpaceship");
        playButton = root.Q<Button>("btnPlay");
        optionsButton = root.Q<Button>("btnOptions");
        exitButton = root.Q<Button>("btnExit");
        // Callbacks
        playButton.RegisterCallback<ClickEvent>(OpenLevelSelector);
        optionsButton.RegisterCallback<ClickEvent>(OpenOptionsPanel);
        exitButton.RegisterCallback<ClickEvent>(ReturnTitle);

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

        // Previous Screen
        previousScreen = FindObjectOfType<TitleUI>().gameObject;
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

    private void OpenLevelSelector(ClickEvent evt)
    {
        throw new NotImplementedException();
    }
}
