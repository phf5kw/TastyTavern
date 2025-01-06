using UnityEngine;

[CreateAssetMenu(fileName = "SpecialCustomerData", menuName = "ScriptableObjects/SpecialCustomerData", order = 0)]
public class SpecialCustomerData : CustomerData {
    public RecipeData offeredRecipe;
    public int stars;
    public int starsSatisfied;
}