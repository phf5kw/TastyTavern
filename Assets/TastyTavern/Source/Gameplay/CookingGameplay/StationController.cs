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
        // Debug.Assert(station != null, "Station model is null");
        // for testing
        // this.station = new(stationData,testStock);

        // run initialize view uxml?
    }

    private void Awake(){
        Debug.Log("Making station");
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

    // Move to Ingredient Slot?

    private void AddIngredient(Ingredient ingredient)
    {
        Debug.Log("station ctrller received add "+ ingredient.Data.Name + "ingredient broadcast");
        station.ActiveIngredients.Add(ingredient);

        foreach ( var i in station.ActiveIngredients)
        {
            Debug.Log("station has " + i.Data.Name);
        }
    }

    /// <summary>
    /// Applies a property to all active ingredients on the station
    /// </summary>
    /// <param name="actionProperty"> The property enum being applied </param>
    private void AddProperty(Property actionProperty)
    {
        Debug.Log("manager received add " + actionProperty + " property broadcast");
        foreach (var ingredient in station.ActiveIngredients)
        {
           ingredient.Properties.Add(actionProperty);
        }
    }

    private void LoadStation()
    {
        Debug.Log("Loading Station " + station.Data.StationType);
        cookingUIEventChannel.RaiseOnLoadStationView(station);
    }

}


// Order -> Monobehavior exposedto unity