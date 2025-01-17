using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IngredientData", menuName = "ScriptableObjects/IngredientData", order = 0)]
public class IngredientData : ScriptableObject 
{

    [field: SerializeField]
    public string Name { get; set; }

    [field: SerializeField]
    public string Description { get; set; }

    [field: SerializeField]
    public Sprite Sprite { get; set; }

    // Factory method to make instance of Ingredient
    public Ingredient Create(){
        return new Ingredient(this);
    }

}

