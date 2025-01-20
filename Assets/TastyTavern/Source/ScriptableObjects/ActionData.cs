using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "ActionData", menuName = "ScriptableObjects/ActionData")]

public class ActionData : ScriptableObject
{
    [field:SerializeField]
    public double ActionTime { get; set; }

    [field: SerializeField]
    public string Name { get; set; }

    [field: SerializeField]
    public Sprite Sprite { get; set; }
}
