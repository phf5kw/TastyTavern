using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OrderData", menuName = "ScriptableObjects/OrderData", order = 0)]
public class OrderData : ScriptableObject {
    public CustomerData customer;
    public RecipeData recipe;
    public List<IngredientData> selectedIngredients;
}
