using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCharacter : ICollectibleCharacter
{
    public string Id { get; set; }

    public string Name { get; set; }

    public float MaxHealth { get; set; }

    public string PrefabPath { get; set; }

    public IEnumerable<IDefence> Defences { get; set; }
}
