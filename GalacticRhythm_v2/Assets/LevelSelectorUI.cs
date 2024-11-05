using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class LevelSelectorUI : MonoBehaviour
{
    UIDocument levelSelector;
    Scene gameScene;
    GameObject previousScreen;

    // Level Selector
    Button backButton, startButton;
    
    // Loading Bar
    VisualElement loadScreen;
    ProgressBar loadingBar;

    private void OnEnable()
    {
        levelSelector = this.GetComponent<UIDocument>();
        VisualElement root = levelSelector.rootVisualElement;

        // Level Selector Queries
        backButton = root.Q<Button>("btnBack");
        startButton = root.Q<Button>("btnStart");
        // Callbacks
        backButton.RegisterCallback<ClickEvent>(ReturnMainMenu);
        startButton.RegisterCallback<ClickEvent>(StartLevel);

        // Loading Bar Queries
        loadScreen = root.Q<VisualElement>("LoadScreenContainer");
        loadingBar = root.Q<ProgressBar>("loadingBar");
    }

    private void StartLevel(ClickEvent evt)
    {
        throw new NotImplementedException();
    }

    private void ReturnMainMenu(ClickEvent evt)
    {
        throw new NotImplementedException();
    }
}
