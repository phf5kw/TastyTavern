using System.Collections.Generic;
using UnityEngine;

public class Station {

    public StationData Data { get; set; }

    [field: SerializeField]
    public List<Ingredient> StockIngredients { get; set; } = new List<Ingredient>();

    [field: SerializeField]
    public List<Ingredient> ActiveIngredients { get; set; } = new List<Ingredient>();

    [field: SerializeField]
    public List<Ingredient> StoredIngredients { get; set; } = new List<Ingredient>();

    /// <summary>
    /// This station is a live tracker of the current station and ingredient process of the current order. 
    /// It will rotate StationData and update as the the order advances to different stations.
    /// Stock ingredients for each proper station are added on instantiation/station change.
    /// <param name="data"></param>
    /// <param name="stock"></param>
    public Station(StationData data, List<IngredientData> stock){
        this.Data = data;
        foreach (var ingredientData in stock){
            StockIngredients.Add(ingredientData.Create());
        }
    }

    // Why not just make Station using normal constructor outside of the Data class? Pass in as Ingredient instead perhaps?

    // Change data, move new Stock and ingredients in Active and Stored to Stock
    public void ChangeStation(StationData data, List<IngredientData> stock){
        this.Data = data;

        StockIngredients.Clear();
        foreach (var ingredientData in stock){
            StockIngredients.Add(ingredientData.Create());
        }
        StockIngredients.AddRange(StoredIngredients);
        StockIngredients.AddRange(ActiveIngredients);
        ActiveIngredients.Clear();
    }
}

