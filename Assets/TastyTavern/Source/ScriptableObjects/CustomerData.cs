using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

[CreateAssetMenu(fileName = "CustomerData", menuName = "ScriptableObjects/CustomerData", order = 0)]
public class CustomerData : ScriptableObject {
    
    [field: SerializeField]
    public string Name { get; set; }

    [field: SerializeField]
    public List<Sprite> Appearance { get; set; } = new List<Sprite>();

    [field: SerializeField]
    public List<string> Dialogue { get; set; } = new List<string>();

    [field: SerializeField]
    public int Patience { get; set; }

    [field: SerializeField]
    public OrderData Order { get; set; }
}
