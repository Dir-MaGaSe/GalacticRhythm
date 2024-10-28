using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ChangeBackToMeu : MonoBehaviour
{
    [SerializeField] GameObject LvlIntro;
    private UIDocument OptionsDocument;

    private void Awake()
    {
        OptionsDocument = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        VisualElement optiobRoot = OptionsDocument.rootVisualElement;

        Button buttonPlay = optiobRoot.Q<Button>("btnPlay");
        Button buttonBack = optiobRoot.Q<Button>("btnBack");

        buttonBack.clicked += ButtonBackPressed;
        buttonPlay.clicked += ButtonPlayPressed;
    }

    private void ButtonPlayPressed()
    {
        LvlIntro.SetActive(true);
        gameObject.SetActive(false);
    }

    private void ButtonBackPressed()
    {
        SceneManager.LoadScene(1);
    }
}
