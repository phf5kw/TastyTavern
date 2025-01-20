using System.Collections.Generic;
using UnityEngine;

public class StationController : MonoBehaviour
{
    // One station per order, start off on first station data
    [SerializeField]
    private Station station;

    public StationData stationData;
    public List<IngredientData> testStock;

    [SerializeField]
    private CookingUIEventChannel cookingUIEventChannel;

    public StationController(){
        // for testing
        // this.station = new(stationData,testStock);

        // run initialize view uxml?
    }

    private void Awake(){
        this.station = new(stationData,testStock);
        LoadStation();
    }

    // handle other logic

    // subscribe to view evt, model evt, refresh
    // REFRESH VIEW HERE 7:34

    private void OnEnable()
    {
        cookingUIEventChannel.OnAddIngredient += AddIngredient;
        cookingUIEventChannel.OnAddProperty += AddProperty;
    }

    private void OnDisable() 
    {
        cookingUIEventChannel.OnAddIngredient -= AddIngredient;
        cookingUIEventChannel.OnAddProperty -= AddProperty;
    }


    /// Adds ingredient to current active workspace (from stock)
    private void AddIngredient(Ingredient ingredient)
    {
        station.ActiveIngredients.Add(ingredient);
        station.StockIngredients.Remove(ingredient);
        station.PrintContents();
    }

    /// Applies a property to all active ingredients on the station
    private void AddProperty(Property actionProperty)
    {
        foreach (var ingredient in station.ActiveIngredients)
        {
            if(!ingredient.Properties.Contains(actionProperty)){
                ingredient.Properties.Add(actionProperty);
            }
        }

        station.PrintContents();
    }

    private void LoadStation()
    {
        Debug.Log("Loading Station " + station.Data.StationType);
        cookingUIEventChannel.RaiseOnLoadStationView(station);
    }

}