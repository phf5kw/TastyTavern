using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

// TODO: Organize references and use Event Channels
public abstract class MenuView : MonoBehaviour
{
    public Slot[] Slots;

    [SerializeField]
    protected UIDocument document;

    protected VisualElement root;

    IEnumerator Start(){
        yield return StartCoroutine(InitializeView());
    }

    public abstract IEnumerator InitializeView(); // int size = 6?

}
