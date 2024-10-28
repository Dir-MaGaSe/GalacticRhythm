using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ChangeSceneMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject optionsUI;

    private UIDocument MenuDocument;

    private void Awake()
    {
        MenuDocument = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        VisualElement menuRoot = MenuDocument.rootVisualElement;

        Button buttonPlay = menuRoot.Q<Button>("btnPlay");
        Button buttonOptions = menuRoot.Q<Button>("btnOptions");
        Button buttonExit = menuRoot.Q<Button>("btnExit");

        buttonPlay.clicked += ButtonPlayPressed;
        buttonOptions.clicked += ButtonOptionsPressed;
        buttonExit.clicked += ButtonExitPressed;
    }


    private void ButtonExitPressed()
    {
        Application.Quit();
    }

    private void ButtonOptionsPressed()
    {
        optionsUI.SetActive(true);
        menuUI.SetActive(false);
    }

    private void ButtonPlayPressed()
    {
        SceneManager.LoadScene(2);  
    }

}
