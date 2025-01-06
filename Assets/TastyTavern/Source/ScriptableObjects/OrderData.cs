using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OrderData", menuName = "ScriptableObjects/OrderData", order = 0)]
public class OrderData : ScriptableObject {

    [field: SerializeField]
    public CustomerData Customer { get; set; }

    [field: SerializeField]
    public RecipeData Recipe { get; set; }

    [field: SerializeField]
    public List<IngredientData> SelectedIngredients { get; set; }

    [field: SerializeField]
    public Station CurrentStation { get; set; }

    [field: SerializeField]
    public List<IngredientData> CurrentIngredients { get; set; }

    [field: SerializeField]
    public bool Served { get; set; }
}
