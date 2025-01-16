using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

public class Customer { // change to class?
    
    [field: SerializeField]
    public string Name { get; set; }

    // This will be the eyes, clothes, hair for a character that's randomized
    [field: SerializeField]
    public List<Sprite> Appearance { get; set; } = new List<Sprite>();

    // expressions for neutral, satisfied, and disappointed
    [field: SerializeField]
    public List<Sprite> Faces { get; set; } = new List<Sprite>();

    [field: SerializeField]
    public List<string> Dialogue { get; set; } = new List<string>();// tentative Dialogue[0] = greet, [1] = satisfied, [2] = unsatisfied, [3] = star npc dialogue?

    [field: SerializeField]
    public int Patience { get; set; }

    [field: SerializeField]
    public Order Order { get; set; }

    [field: SerializeField]
    public Biome Biome { get; set; } // biome... scriptable object or enum

    public Customer(string Name, List<Sprite> Appearance, List<Sprite> Faces, List<string> Dialogue, int Patience, Biome Biome) {
        this.Name = Name;
        this.Appearance = Appearance;
        this.Faces = Faces;
        this.Dialogue = Dialogue;
        this.Patience = Patience;
        System.Random rand = new System.Random();
        RecipeData r = new RecipeData(); // temporary, REPLACE WITH A RANDOM RECIPE IN A PUBLICLY ACCESSIBLE MENU DATA STRUCTURE
        Dictionary<IngredientData, List<Property>> SelectedIngredients = r.SelectedIngredients; // Customer can customize a recipe in their own order, but I think it shouldn't do it very often
        if (rand.Next(0,3) == 3) // 1/4 chance of activating
            SelectedIngredients.Remove(SelectedIngredients.ElementAt(rand.Next(0, SelectedIngredients.Count)).Key);// Removing one random ingredient from the recipe in their order, for now
        Order = new Order(this, r, SelectedIngredients);
        this.Biome = Biome;
    }

    // Customer says satisfied or dissatisfied dialogue -> customer is dismissed -> related UI is updated. Perhaps this could be an event instead if needed
    private void OnCustomerOrderCompleted()
    {

    }
}
