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
        // Obt�n el panel ra�z de la UI
        var root = GetComponent<UIDocument>().rootVisualElement;

        // Encuentra el bot�n usando el nombre de su ID o clase
        btnStart = root.Q<Button>("btnStart");  // Reemplaza con el ID de tu bot�n en UI Builder

        // A�ade un evento al hacer clic en el bot�n
        btnStart.clicked += OnButtonClick;
    }

    private void OnButtonClick()
    {
        SceneManager.LoadScene(sceneName);  // Reemplaza con el nombre de la escena que deseas cargar
    }
}
