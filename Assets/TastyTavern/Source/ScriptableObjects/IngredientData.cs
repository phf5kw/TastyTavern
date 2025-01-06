using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IngredientData", menuName = "ScriptableObjects/IngredientData", order = 0)]
public class IngredientData : ScriptableObject {

    public new string name;
    public string description;
    public Sprite ingredientIcon;

}