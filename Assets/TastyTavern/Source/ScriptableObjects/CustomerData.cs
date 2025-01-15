using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

public class Customer { // change to class?
    
    [field: SerializeField]
    public string Name { get; set; }

    // This will be the eyes, clothes, hair for a character that's randomized
    [field: SerializeField]
    public List<Sprite> Appearance { get; set; } = new List<Sprite>();

    // expressions for neutral, satisfied, and disappointed
    [field: SerializeField]
    public List<Sprite> Faces { get; set; } = new List<Sprite>();

    [field: SerializeField]
    public List<string> Dialogue { get; set; } = new List<string>();

    [field: SerializeField]
    public int Patience { get; set; }

    [field: SerializeField]
    public Order Order { get; set; }

    [field: SerializeField]
    public Biome Biome { get; set; } // biome... scriptable object or enum
}
