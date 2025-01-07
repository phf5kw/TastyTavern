using UnityEngine;
using UnityEngine.UIElements;

// TODO: Organize references and use Event Channels
public class CookingMenuController : MonoBehaviour
{

    public VisualElement ui;
    public Button onionButton;
    // for now 
    public IngredientData onionData;

    [SerializeField]
    private CookingUIEventChannel cookingUIEventChannel;


    private void Awake()
    {
        ui = GetComponent<UIDocument>().rootVisualElement;
    }

    private void OnEnable(){
        onionButton = ui.Q<Button>("onion");
        onionButton.clicked += OnOnionClicked;
    }

    private void OnDisable(){
        onionButton.clicked -= OnOnionClicked;
    }

    // this will be kicked to another method via event channel
    private void OnOnionClicked(){
        Debug.Log("Onion clicked!");
        // BIND menu item to the datatype
        cookingUIEventChannel.RaiseOnAddIngredient(onionData);
    }

}
