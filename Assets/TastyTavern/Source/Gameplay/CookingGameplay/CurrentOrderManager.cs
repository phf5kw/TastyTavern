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
    private Station currentStation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ASSUMING SET ORDER AND STATION FOR NOW
        foreach( var i in currentStation.ActiveIngredients)
        {
            Debug.Log("station has " + i.Name);
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
