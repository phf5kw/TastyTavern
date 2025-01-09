using UnityEngine;
using UnityEngine.UIElements;

// TODO: Organize references and use Event Channels
public class CookingMenuController : MonoBehaviour
{

    public VisualElement ui;
    public Button onionButton;
    public Button actionButton;
    // for now 
    public IngredientData onionData;

    [SerializeField]
    private CookingUIEventChannel cookingUIEventChannel;


    private void Awake()
    {
        ui = GetComponent<UIDocument>().rootVisualElement;
        onionButton = ui.Q<Button>("onion");
        actionButton = ui.Q<Button>("Knife");
    }

    private void OnEnable(){
        onionButton.clicked += OnOnionClicked;
        actionButton.clicked += OnActionClicked;
    }

    private void OnDisable(){
        onionButton.clicked -= OnOnionClicked;
        actionButton.clicked -= OnActionClicked;
    }

    // ********GENERALIZE******Eventually, will not have ingredient specific
    // will BIND ingredients, one function for all ingredients
    private void OnOnionClicked(){
        cookingUIEventChannel.RaiseOnAddIngredient(onionData);
    }

    //********GENERALIZE******Eventually
    private void OnActionClicked(){
        cookingUIEventChannel.RaiseOnAddProperty(Property.Cut); // Property enum actionProperty
    }

}
