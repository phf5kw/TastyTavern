using UnityEngine;

[CreateAssetMenu(fileName = "SpecialCustomerData", menuName = "ScriptableObjects/SpecialCustomerData", order = 0)]
public class SpecialCustomerData : CustomerData {

    [field: SerializeField]
    public RecipeData UnlockedRecipe { get; set; }

    [field: SerializeField]
    public int Stars { get; set; }

    [field: SerializeField]
    public int StarsCompleted { get; set; }
}