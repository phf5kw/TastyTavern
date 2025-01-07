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
    public Sprite Icon { get; set; }

    /// <summary>
    /// List of the ingredients properties, AKA, keeping track of all actions made to them (none if raw, uncut ingredient).
    /// </summary>
    [field: SerializeField]
    public List<Property> Properties { get; set; }

}

public enum Property
{
    Cut,
    Cooked,
    Stewed,
    Salted,
    Peppered,
}

