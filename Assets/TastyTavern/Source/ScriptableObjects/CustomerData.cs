using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

public class Customer : MonoBehaviour{ // change to class?
    
    [field: SerializeField]
    public string Name { get; set; }

    [field: SerializeField]
    public OrderManager CurrentOrderManager { get; set; }

    [field: SerializeField]
    private CookingUIEventChannel cookingUIEventChannel;

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
    public BiomeData Biome { get; set; } // biome... scriptable object or enum

    public Customer(string Name, List<Sprite> Appearance, List<Sprite> Faces, List<string> Dialogue, int Patience, BiomeData Biome) {
        this.Name = Name;
        this.Appearance = Appearance;
        this.Faces = Faces;
        this.Dialogue = Dialogue;
        this.Patience = Patience;
        System.Random rand = new System.Random();
        RecipeData r = new RecipeData(); // temporary, REPLACE WITH A RANDOM RECIPE IN A PUBLICLY ACCESSIBLE MENU DATA STRUCTURE
        Dictionary<IngredientData, List<Property>> SelectedIngredients = r.SelectedIngredients; // Customer can customize a recipe in their own order, but I think it shouldn't do it very often

        // Placeholder logic
        if (rand.Next(0,3) == 3) // 1/4 chance of activating
            SelectedIngredients.Remove(SelectedIngredients.ElementAt(rand.Next(0, SelectedIngredients.Count)).Key);// Removing one random ingredient from the recipe in their order, for now
        
        Order = new Order(this, r, SelectedIngredients);
        PlaceCustomerOrder(Order);
        this.Biome = Biome;
    }

    public Customer()
    {

    }

    private void PlaceCustomerOrder(Order Order)
    {
        Debug.Log("Order for " + Name + " has been Placed");
        // Order placed logic (UI, update the order list, etc.)
        // When CurrentOrderManager is placed in the scene (as of now it isn't yet), access that somehow and then update its private allOrders list with the new order
        cookingUIEventChannel.RaiseOpenOrder(Order);
    }

    public void CompleteCustomerOrder() // maybe this will be called by the Station UI, or maybe the UI will have its own function. If the station UI has its own way of calling the event, then this function is useless. 
    {
        Debug.Log("Customer order completed");
        // Customer says satisfied or dissatisfied dialogue -> customer is dismissed -> related UI is updated -> allOrders list is updated -> money is received -> etc. Perhaps this could be an event instead if needed
        cookingUIEventChannel.RaiseOnSubmitOrder(Order);
    }
}
