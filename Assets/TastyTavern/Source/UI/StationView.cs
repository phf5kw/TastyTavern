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

    private VisualElement root;
    public VisualElement ingredientsSlotsContainer;

    // public VisualTreeAsset ingredientButtonTemplate;

    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        ingredientsSlotsContainer = root.Q<VisualElement>("IngredientSlotContainer"); //already style?
        
    }

    // add action item in param
    public void InitializeView(List<Ingredient> ingredients){
        ingredientsSlotsContainer.Clear();

        foreach(Ingredient ingredient in ingredients){
            Slot slot = new(ingredient);
            slot.AddToClassList(".ingredient-slot");
            ingredientsSlotsContainer.Add(slot);
        }
    }
}
