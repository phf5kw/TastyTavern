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

    public IngredientData basilisk;
    public IngredientData punchPepper;

    // public VisualTreeAsset ingredientButtonTemplate;

    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        Debug.Log("root is" + ingredientSlotContainer);
        ingredientSlotContainer = root.Q<VisualElement>("IngredientSlotContainer"); //already style?
        Debug.Log(ingredientSlotContainer);
        List<Ingredient> dummyIngredients = new()
        {
            basilisk.Create(),
            punchPepper.Create()
        };
        InitializeView(dummyIngredients);
    }

    // add action item in param
    public void InitializeView(List<Ingredient> ingredients){
        ingredientSlotContainer.Clear();

        foreach(Ingredient ingredient in ingredients){
            Slot slot = new(ingredient);
            Debug.Log("Slot created for " + slot.Ingredient.Data.Name);
            slot.AddToClassList("ingredient-slot");
            ingredientSlotContainer.Add(slot);
        }
    }
}
