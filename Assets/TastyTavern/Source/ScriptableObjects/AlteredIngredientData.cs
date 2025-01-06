using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IngredientData", menuName = "ScriptableObjects/AlteredIngredientData", order = 0)]
public class AlteredIngredientData : IngredientData  {
    public List<Property> properties = new();

    public enum Property{
        Cut,
        Cooked,
        Salted,
        Peppered,
    }

}


