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
    protected UIDocument ui;

    protected VisualElement root;

    // public VisualTreeAsset ingredientButtonTemplate;

    // add action item in param
    public void InitializeView(List<Ingredient> ingredients){
        // find the ingredients Container and add new slots
        VisualElement slotsContainer = root.Q<VisualElement>("IngredientSlotContainer");
        slotsContainer.Clear();
        
        foreach(Ingredient ingredient in ingredients){
            Slot slot = new(ingredient);
            slotsContainer.Add(slot);
        }
    }
}
