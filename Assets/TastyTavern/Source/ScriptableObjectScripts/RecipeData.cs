using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipeData", menuName = "ScriptableObjects/RecipeData")]
public class RecipeData : ScriptableObject {
    public new string name;
    public string description;
    public int price = 20;
    public Sprite artwork;
    public List<IngredientData> ingredients;
    public Station[] stationOrder;
    // TODO: Add Biome, Station details, maybe NPC
    // Does the Recipe need to know which NPC is associated with it?
}

public enum Station{
    CuttingBoard,
    Pan,
    Pot,
    Serving,
}
