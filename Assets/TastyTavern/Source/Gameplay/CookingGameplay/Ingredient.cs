using System.Collections.Generic;
using UnityEngine;

public class Ingredient {

    public IngredientData Data { get; set; }

    // Properties added during gameplay. Empty = raw and uncut
    [field: SerializeField]
    public List<Property> Properties { get; set; } = new List<Property>();

    public Ingredient(IngredientData data){
        this.Data = data;
    }
}

public enum Property{
    Cut,
    Cooked,
    Stewed,
    Salted,
    Peppered,
}