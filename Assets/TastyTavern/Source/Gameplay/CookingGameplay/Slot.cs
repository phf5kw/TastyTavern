using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Slot : Button {
    public Image Icon;
    // public Sprite BaseSprite;
    public Label Label = new();
    public int Index => parent.IndexOf(this);

    public Ingredient Ingredient { get; set; }
    

    public event Action<Slot> OnClickIngredient = delegate { };

    public Slot(Ingredient ingredient)
    {
        Ingredient = ingredient;

        //fill elements with ingredient info
        Icon = new()
        {
            image = Ingredient.Data.Sprite.texture
        };
        Icon.AddToClassList("ingredient-icon");

        Label.text = Ingredient.Data.Name;
        Label.AddToClassList("ingredient-label");

        // set as children, add styles?
        this.Add(Icon);
        this.Add(Label);

        this.clicked += OnClick;
        // this.RegisterCallback<ClickEvent>(OnClick);
    }

    private void OnClick() {
        Debug.Log("Clicked " + Ingredient.Data.Name + " Ingredient");
        OnClickIngredient.Invoke(this);
        // cookingUIEventChannel.RaiseOnAddIngredient(Ingredient);
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

