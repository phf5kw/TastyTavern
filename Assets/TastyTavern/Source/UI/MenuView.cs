using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// TODO: Organize references and use Event Channels
public abstract class MenuView : MonoBehaviour
{
    public Slot[] Slots;

    [SerializeField] string PanelName { get; set; }

    [SerializeField]
    protected UIDocument document;

    protected VisualElement root;

    // Filling a menu component with items
    public abstract void LoadMenu(List<Object> dataList);

    // IEnumerator Start(){
    //     yield return StartCoroutine(InitializeView());
    // }

    // public abstract IEnumerator InitializeView(); // int size = 6?

}
