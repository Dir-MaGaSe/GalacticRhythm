using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ChangeScene : MonoBehaviour
{
    private Button btnStart;

    public string sceneName;

    void Start()
    {
        // Obtén el panel raíz de la UI
        var root = GetComponent<UIDocument>().rootVisualElement;

        // Encuentra el botón usando el nombre de su ID o clase
        btnStart = root.Q<Button>("btnStart");  // Reemplaza con el ID de tu botón en UI Builder

        // Añade un evento al hacer clic en el botón
        btnStart.clicked += OnButtonClick;
    }

    private void OnButtonClick()
    {
        SceneManager.LoadScene(sceneName);  // Reemplaza con el nombre de la escena que deseas cargar
    }
}
