using System.Collections.Generic;
using UnityEngine;

public class Order
{
    // [field: SerializeField]
    // public int OrderSlot { get; set; }

    [field: SerializeField]
    public Customer Customer { get; set; }

    [field: SerializeField]
    public RecipeData Recipe { get; set; }

    [field: SerializeField]
    public Dictionary<IngredientData, List<Property>> SelectedIngredients { get; set; } = new Dictionary<IngredientData, List<Property>>(); 

    [field: SerializeField]
    public bool Served { get; set; }
}
