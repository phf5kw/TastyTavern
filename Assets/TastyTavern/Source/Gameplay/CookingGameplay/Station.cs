using System.Collections.Generic;
using UnityEngine;
/// Stock ingreityEngine;

/// <summary>
/// This station is a live tracker of the current station and ingredient process of the current order. 
/// It will rodients for each proper station are added on instantiation/station change.
public class Station {

    public StationData Data { get; set; }

    [field: SerializeField]
    public List<Ingredient> StockIngredients { get; set; } = new List<Ingredient>();

    [field: SerializeField]
    public List<Ingredient> ActiveIngredients { get; set; } = new List<Ingredient>();

    [field: SerializeField]
    public List<Ingredient> StoredIngredients { get; set; } = new List<Ingredient>();

    public Station(StationData data, List<IngredientData> stock){
        this.Data = data;
        foreach (var ingredientData in stock){
            StockIngredients.Add(ingredientData.Create());
        }
    }

    // Why not just make Station using normal constructor outside of the Data class? Pass in as Ingredient instead perhaps?

    // "SET ASIDE" FUNCTION
    public void MoveActiveToStored(){
        StoredIngredients.AddRange(ActiveIngredients);
        ActiveIngredients.Clear();
    }

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
        StoredIngredients.Clear();
    }

    
}

