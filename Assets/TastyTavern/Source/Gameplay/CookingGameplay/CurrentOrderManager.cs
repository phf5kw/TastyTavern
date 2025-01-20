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
    private Order currentOrder; 

    [SerializeField]
    private List<Order> allOrders; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ASSUMING SET ORDER AND STATION FOR NOW
        foreach( var i in currentOrder.CurrentStation.ActiveIngredients)
        {
            Debug.Log("station has " + i.Data.Name);
        }
    }

    private void OnEnable()
    {
        cookingUIEventChannel.OnOpenOrder += handleOpenOrder;
        cookingUIEventChannel.OnSubmitOrder += handleSubmitOrder;
    }

    private void OnDisable()
    {
        cookingUIEventChannel.OnOpenOrder -= handleOpenOrder;
        cookingUIEventChannel.OnSubmitOrder -= handleSubmitOrder;
    }


    /// <summary>
    /// Changes the current order to the newly selected order.
    /// </summary>
    /// <param name="orderData"></param>
    private void SelectOrder(Order selectedOrder)
    {
        Debug.Log("Selected Order " + selectedOrder);
        currentOrder = selectedOrder;
        LoadStation(currentOrder.CurrentStation.Data);
    }

    private void LoadStation(StationData station)
    {
        Debug.Log("Loading Station " + station.StationType);
        // all station logic is updated on station object
        // update menu where? how does it know the data
    }

    public void handleOpenOrder(Order order)
    {
        allOrders.Add(order);
    }
    public void handleSubmitOrder(Order order)
    {
        if (order.isComplete())
            allOrders.Remove(order);
            // other things can happen here like money? etc. like playerMoney += order.Recipe.Price; or something like that
    }
}
