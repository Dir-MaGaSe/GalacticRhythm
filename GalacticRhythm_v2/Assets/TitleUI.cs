using UnityEngine;
using UnityEngine.UIElements;

public class TitleUI : MonoBehaviour
{
    UIDocument title;
    GameObject nextScreen;

    // Main Function
    Button startButton;

    private void OnEnable()
    {
        title = this.GetComponent<UIDocument>();
        VisualElement root = title.rootVisualElement;

        //Title Queries
        startButton = root.Q<Button>("btnStart");
        //Callbacks
        startButton.RegisterCallback<ClickEvent>(OpenMenu);
        
        //Next Screen 
        nextScreen = FindObjectOfType<MainMenuUI>().gameObject;
    }

    private void OpenMenu(ClickEvent evt)
    {
        nextScreen.SetActive(true);
        
    }
}
