using UnityEngine;
using UnityEngine.UIElements;

public class IngredientSlot 
{
    public Button button;
    public IngredientData ingredientData;

    public IngredientSlot(IngredientData ingredientData, VisualTreeAsset ingredientTemplate)
    {
        this.ingredientData = ingredientData;

        TemplateContainer ingredientButtonContainer = ingredientTemplate.Instantiate();
        button = ingredientButtonContainer.Q<Button>();

    }

    private void OnEnable(){
        button.clicked += OnClick;
    }

    private void OnDisable(){
        button.clicked -= OnClick;
    }

    private void OnClick()
    {
        Debug.Log("Created button clicked");
        // event channel stuff
    }

}

