using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectibleCharacter
{
    public string Id { get; }

    public string Name { get; }

    public float MaxHealth { get; }

    public string PrefabPath { get; }

    public IEnumerable<IDefence> Defences { get; }
}
