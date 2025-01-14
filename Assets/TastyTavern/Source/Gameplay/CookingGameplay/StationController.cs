using UnityEngine;

public class StationController
{
    // One station per order, start off on first station data
    [SerializeField]
    private Station station;

    [SerializeField]
    private CookingUIEventChannel cookingUIEventChannel;

    // the view?

    public StationController(Station station){
        Debug.Assert(station != null, "Station model is null");
        this.station = station;

        // run initialize view uxml?
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

    private void AddIngredient(IngredientData ingredientData)
    {
        Debug.Log("station ctrller received add "+ ingredientData.Name + "ingredient broadcast");
        station.ActiveIngredients.Add(ingredientData);

        foreach ( var i in station.ActiveIngredients)
        {
            Debug.Log("station has " + i);
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


}


// Order -> Monobehavior exposedto unity