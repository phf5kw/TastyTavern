using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StationData", menuName = "ScriptableObjects/StationData", order = 0)]
public class StationData : ScriptableObject 
{
    
    /// <summary>
    /// The enum describing what type of station this is
    /// </summary>
    [field: SerializeField]
    public StationType StationType { get; set; }

    /// <summary>
    /// The list of ingredients currently active on this station. These should be visible when live.
    /// </summary>
    [field: SerializeField]
    public List<IngredientData> ActiveIngredients { get; set; } = new List<IngredientData>();

    /// <summary>
    /// The list of ingredients in the current order's storage. The progress of the order.
    /// </summary>
    [field: SerializeField]
    public List<IngredientData> StoredIngredients { get; set; } = new List<IngredientData>();

    /// <summary>
    /// The time it takes to do the cooking action. If this is not a timed action, set to 0.
    /// </summary>
    [field: SerializeField]
    public int ActionTime { get; set; } //maybe make action into data too?
}

public enum StationType
{
    CuttingBoard,
    Pan,
    Pot,
    Serving,
}