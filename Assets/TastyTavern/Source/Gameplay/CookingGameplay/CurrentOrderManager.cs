using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CurrentOrderManager : MonoBehaviour
{
    [SerializeField]
    private CookingUIEventChannel cookingUIEventChannel;

    [SerializeField]
    private OrderData currentOrder; 
    
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
    }

    private void OnDisable() 
    {
        cookingUIEventChannel.OnAddIngredient -= AddIngredient;
    }

    private void AddIngredient(IngredientData ingredientData)
    {
        Debug.Log("manager received add "+ ingredientData.Name + "ingredient broadcast");
        currentStation.ActiveIngredients.Add(ingredientData);

        foreach( var i in currentStation.ActiveIngredients)
        {
            Debug.Log("station has " + i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
