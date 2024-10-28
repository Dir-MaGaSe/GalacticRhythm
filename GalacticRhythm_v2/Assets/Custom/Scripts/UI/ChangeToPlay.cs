using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ChangeToPlay : MonoBehaviour
{
    [SerializeField] private GameObject gameElements;
    private UIDocument LvlIntro;

    private void Awake()
    {
        LvlIntro = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        VisualElement optiobRoot = LvlIntro.rootVisualElement;
        Button buttonBack = optiobRoot.Q<Button>("btnPlay");
        buttonBack.clicked += ButtonBackPressed;
    }
        
    private void ButtonBackPressed()
    {
        gameElements.SetActive(true);
        gameObject.SetActive(false);
    }
}
