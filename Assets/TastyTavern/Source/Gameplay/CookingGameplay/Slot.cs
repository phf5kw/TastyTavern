using UnityEngine;
using UnityEngine.UIElements;

public class Slot : VisualElement{
    public Image Icon;
    public Sprite BaseSprite;
    public Label Label;
    public Button button;
    public int Index => parent.IndexOf(this);

    public Ingredient Ingredient { get; set; }

    public Slot(Ingredient ingredient)
    {
        // assign sprite, img, label
        
        // TemplateContainer ingredientButtonContainer = buttonTemplate.Instantiate()
        Ingredient = ingredient;
    }

    // private void OnEnable(){
    //     button.clicked += OnClick;
    // }

    // private void OnDisable(){
    //     button.clicked -= OnClick;
    // }

    // private void OnClick()
    // {
    //     Debug.Log("Created button clicked");
    //     // event channel stuff
    // }

}

