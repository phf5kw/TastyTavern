using System;
using UnityEngine;

/// <summary>
/// Handles any actions on the in-progress Order
/// </summary>
[CreateAssetMenu(fileName = "CookingUIEventChannel", menuName = "ScriptableObjects/EventChannels/OrderEventChannel", order = 0)]
public class CookingUIEventChannel : ScriptableObject {
    /// <summary>
    /// Callback when an ingredient is added to the current order
    /// </summary>
    public Action<IngredientData> OnAddIngredient;

    public void RaiseOnAddIngredient(IngredientData ingredientData){
        Debug.Log("Raise on " + ingredientData.Name + "broadcasted from event channel.");
        OnAddIngredient?.Invoke(ingredientData);
    }
}