using Unity.VisualScripting;
using UnityEngine;

public class CurrentOrderManager : MonoBehaviour
{
    [SerializeField]
    private CookingUIEventChannel cookingUIEventChannel;

    [SerializeField]
    private OrderData currentOrder; // order vs live order? if SO, doesn't need to be saved on reload.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnEnable()
    {
        cookingUIEventChannel.OnAddIngredient += AddIngredient;
    }

    private void OnDisable() {
        cookingUIEventChannel.OnAddIngredient -= AddIngredient;
    }

    private void AddIngredient(IngredientData ingredientData) {
        // TODO
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
