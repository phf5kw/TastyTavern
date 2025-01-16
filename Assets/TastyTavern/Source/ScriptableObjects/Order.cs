using System.Collections.Generic;
using UnityEngine;

public class Order
{
    // [field: SerializeField]
    // public int OrderSlot { get; set; }

    // the customer that ordered the order
    [field: SerializeField]
    public Customer Customer { get; set; }

    // The recipe of the order
    [field: SerializeField]
    public RecipeData Recipe { get; set; }

    // The exact ingredients of the order. The order may be slightly customized by the customer to exclude certain ingredients. 
    [field: SerializeField]
    public Dictionary<IngredientData, List<Property>> SelectedIngredients { get; set; } = new Dictionary<IngredientData, List<Property>>(); 

    // Whether the order is served or not
    [field: SerializeField]
    public bool Served { get; set; }

    [field: SerializeField]
    public Station CurrentStation { get; set; }

    public Order(Customer Customer, RecipeData recipe, Dictionary<IngredientData, List<Property>> SelectedIngredients)
    {
        Served = false;
        this.Customer = Customer;
        Recipe = recipe;
        this.SelectedIngredients = SelectedIngredients;
        CurrentStation = null; // This needs to be whatever the default station is... I don't know yet


    }
}
