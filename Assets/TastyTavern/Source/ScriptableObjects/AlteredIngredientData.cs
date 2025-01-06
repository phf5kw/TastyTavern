using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IngredientData", menuName = "ScriptableObjects/AlteredIngredientData", order = 0)]
public class AlteredIngredientData : IngredientData  {

    [field: SerializeField]
    public List<Property> Properties { get; set; }

}

public enum Property{
    Cut,
    Cooked,
    Salted,
    Peppered,
}

