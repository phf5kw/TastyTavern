using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipeData", menuName = "ScriptableObjects/RecipeData")]
public class RecipeData : ScriptableObject {

    [field: SerializeField]
    public string Name { get; set; }

    [field: SerializeField]
    public string Description { get; set; }

    [field: SerializeField]
    public int Price { get; set; }

    [field: SerializeField]
    public Sprite Icon { get; set; }

    [field: SerializeField]
    public List<IngredientData> Ingredients { get; set; }

    [field: SerializeField]
    public StationType[] StationSequence { get; set; }
    // TODO: Add Biome, Station details, maybe NPC
    // Does the Recipe need to know which NPC is associated with it?
}

public enum StationType{
    CuttingBoard,
    Pan,
    Pot,
    Serving,
}
