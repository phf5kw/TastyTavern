using System;
using UnityEngine;

/// <summary>
/// Event Channel to communicate any actions on the Cooking UI to the in-progress Order
/// </summary>
[CreateAssetMenu(fileName = "CookingUIEventChannel", menuName = "ScriptableObjects/EventChannels/OrderEventChannel", order = 0)]
public class CookingUIEventChannel : ScriptableObject {
    
    /// <summary> Callback when an ingredient is added to the working station of the current order </summary>
    public Action<IngredientData> OnAddIngredient;

    /// <summary> Callback when a property is added to the ingredients on the working station of the current order </summary>
    public Action<Property> OnAddProperty;

    public void RaiseOnAddIngredient(IngredientData ingredientData){
        Debug.Log("Raise on " + ingredientData.Name + " broadcasted from event channel.");
        OnAddIngredient?.Invoke(ingredientData);
    }

    public void RaiseOnAddProperty(Property actionProperty){
        Debug.Log("Raise adding " + actionProperty + " broadcasted from event channel.");
        OnAddProperty?.Invoke(actionProperty);
    }

}