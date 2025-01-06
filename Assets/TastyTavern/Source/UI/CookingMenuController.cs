using UnityEngine;
using UnityEngine.UIElements;

// TODO: Organize references and use Event Channels
public class CookingMenuController : MonoBehaviour
{

    public VisualElement ui;
    public Button onion;
    private void Awake()
    {
        ui = GetComponent<UIDocument>().rootVisualElement;
    }

    private void OnEnable(){
        onion = ui.Q<Button>("onion");
        onion.clicked += OnOnionClicked;
    }

    private void OnDisable(){
        onion.clicked -= OnOnionClicked;
    }

    // this will be kicked to another method via event channel
    private void OnOnionClicked(){
        Debug.Log("Onion clicked!");
    }

}
