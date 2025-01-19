using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.UIElements;

// TODO: Organize references and use Event Channels
public class StationView : MonoBehaviour {
    public Slot[] Slots;

    [SerializeField] string PanelName { get; set; }

    [SerializeField]
    // protected UIDocument document; ? keep

    public VisualElement root;
    public VisualElement ingredientSlotContainer;
    [SerializeField]
    private CookingUIEventChannel cookingUIEventChannel;

    public IngredientData basilisk;
    public IngredientData punchPepper;

    private void OnEnable()
    {
        cookingUIEventChannel.OnLoadStationView += LoadStationView;
    }

    private void OnDisable() 
    {
        cookingUIEventChannel.OnLoadStationView -= LoadStationView;
    }

    private void Awake(){
        root = GetComponent<UIDocument>().rootVisualElement;
        Debug.Log("root is" + ingredientSlotContainer);
        ingredientSlotContainer = root.Q<VisualElement>("IngredientSlotContainer"); //already style?
        Debug.Log(ingredientSlotContainer);
    }

    private void Start(){
        // List<Ingredient> dummyIngredients = new()
        // {
        //     basilisk.Create(),
        //     punchPepper.Create()
        // };
        // InitializeView(dummyIngredients);
    }

    // add action item in param
    // ingredients --> live ingredients in the station storage/stock
    // CREATE ON ORDER CREATION
    public void InitializeView(List<Ingredient> ingredients){
        Debug.Log("Initializing Station view");
        ingredientSlotContainer.Clear();

        foreach(Ingredient ingredient in ingredients){
            Slot slot = new(ingredient);
            Debug.Log("Slot created for " + slot.Ingredient.Data.Name);
            slot.AddToClassList("ingredient-slot"); // make helper methods (extension)
            ingredientSlotContainer.Add(slot);
            slot.OnClickIngredient += OnAddIngredient;
        }
        
    }

    private void OnAddIngredient(Slot slot) {
        cookingUIEventChannel.RaiseOnAddIngredient(slot.Ingredient); 
        // disable the ingredient slot here
    }

    private void LoadStationView(Station station){
        // not showing active ingredients yet, just menu
        Debug.Log("View recieved loading request from event channel");
        InitializeView(station.StockIngredients);
    }

    //     private void OnActionClicked()
//     {
//         cookingUIEventChannel.RaiseOnAddProperty(Property.Cut); // Property enum actionProperty
//     }
}
