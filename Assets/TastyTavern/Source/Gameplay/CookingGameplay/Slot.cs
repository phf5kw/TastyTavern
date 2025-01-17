using UnityEngine;
using UnityEngine.UIElements;

public class Slot : VisualElement{
    public Image Icon;
    public Sprite BaseSprite;
    public Label Label = new();
    public int Index => parent.IndexOf(this);

    public Ingredient Ingredient { get; set; }

    public Slot(Ingredient ingredient)
    {
        // assign sprite, img, label
        
        // TemplateContainer ingredientButtonContainer = buttonTemplate.Instantiate()
        Ingredient = ingredient;

        //fill elements with ingredient info
        BaseSprite = Ingredient.Data.Sprite;
        Icon = new()
        {
            image = BaseSprite.texture
        };
        Label.text = Ingredient.Data.Name;

        // set as children, add styles?
        this.Add(Icon);
        this.Add(Label);
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

