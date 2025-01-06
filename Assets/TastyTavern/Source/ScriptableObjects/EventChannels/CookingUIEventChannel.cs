using System;
using UnityEngine;

/// <summary>
/// Handles any actions on the in-progress Order
/// </summary>
[CreateAssetMenu(fileName = "OrderEventChannel", menuName = "ScriptableObjects/EventChannels/OrderEventChannel", order = 0)]
public class CookingUIEventChannel : ScriptableObject {
    /// <summary>
    /// Callback when an ingredient is added to the current order
    /// </summary>
    public Action<IngredientData> OnAddIngredient;

    public void RaiseOnAddIngredient(IngredientData ingredientData) => OnAddIngredient?.Invoke(ingredientData);

}