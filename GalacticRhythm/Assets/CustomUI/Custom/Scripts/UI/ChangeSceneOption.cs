using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ChangeSceneOption : MonoBehaviour
{
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject optionsUI;

    private UIDocument OptionsDocument;


    private void Awake()
    {
        OptionsDocument = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        VisualElement optiobRoot = OptionsDocument.rootVisualElement;
        Button buttonBack = optiobRoot.Q<Button>("btnBack");
        buttonBack.clicked += ButtonBackPressed;
    }

    private void ButtonBackPressed()
    {
        optionsUI.SetActive(false);
        menuUI.SetActive(true);
    }
}
