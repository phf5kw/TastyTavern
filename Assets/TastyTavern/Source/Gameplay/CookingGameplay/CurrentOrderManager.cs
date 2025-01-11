using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class CurrentOrderManager : MonoBehaviour
{
    [SerializeField]
    private CookingUIEventChannel cookingUIEventChannel;

    [SerializeField]
    private OrderData currentOrder; 

    [SerializeField]
    private List<OrderData> allOrders; 
    
    [SerializeField]
    private StationData currentStation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ASSUMING SET ORDER AND STATION FOR NOW
        foreach( var i in currentStation.ActiveIngredients)
        {
            Debug.Log("station has " + i.Name);
        }
    }

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

    private void AddIngredient(IngredientData ingredientData)
    {
        Debug.Log("manager received add "+ ingredientData.Name + "ingredient broadcast");
        currentStation.ActiveIngredients.Add(ingredientData);

        foreach ( var i in currentStation.ActiveIngredients)
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
        foreach (var ingredient in currentStation.ActiveIngredients)
        {
           ingredient.Properties.Add(actionProperty);
        }
    }

    /// <summary>
    /// Changes the current order to the newly selected order.
    /// </summary>
    /// <param name="orderData"></param>
    private void SelectOrder(OrderData selectedOrder)
    {
        Debug.Log("Selected Order " + selectedOrder);
        currentOrder = selectedOrder;
        currentStation = currentOrder.CurrentStation;
        LoadStation(currentStation);
    }

    private void LoadStation(StationData station)
    {
        Debug.Log("Loading Station " + station.StationType);
        // all station logic is updated on station object
        // update menu where? how does it know the data
    }
}
