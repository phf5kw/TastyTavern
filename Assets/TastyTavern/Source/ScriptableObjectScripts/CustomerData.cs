using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

[CreateAssetMenu(fileName = "CustomerData", menuName = "ScriptableObjects/CustomerData", order = 0)]
public class CustomerData : ScriptableObject {
    public new string name;
    public List<Sprite> appearance;
    public List<string> dialogue;
    public int patience;
    public OrderData order;
}
