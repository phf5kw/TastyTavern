using UnityEngine;
using UnityEngine.UIElements;

public class Slot : VisualElement{
    public Image Icon;
    public Sprite BaseSprite
    public Label Label;
    public Button button;
    public int Index => parent.IndexOf(this);
    

    public Slot()
    {
        Icon = this.CreateChild<Image>("slotIcon");

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

