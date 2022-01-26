using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectibleCharacter
{
    public string Name { get; }

    public float MaxHealth { get; }

    public IEnumerable<IDefence> Defences { get; }
}
