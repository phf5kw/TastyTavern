using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OrderData", menuName = "ScriptableObjects/OrderData", order = 0)]
public class OrderData : ScriptableObject 
{
    [field: SerializeField]
    public int OrderSlot { get; set; }

    [field: SerializeField]
    public CustomerData Customer { get; set; }

    [field: SerializeField]
    public RecipeData Recipe { get; set; }

    [field: SerializeField]
    public IngredientData[] SelectedIngredients { get; set; } 

    // Fields below this point are modified during gameplay after initialization //

    [field: SerializeField]
    public StationData CurrentStation { get; set; }

    [field: SerializeField]
    public List<StationData> Stations { get; set; } = new List<StationData>();

    [field: SerializeField]
    public bool Served { get; set; }
}
