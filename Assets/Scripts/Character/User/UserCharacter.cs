using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UserCharacter : MonoBehaviour, IBaseCharacter
{
    public float MaxHealth { get; private set; }

    public float CurrentHealth { get; private set; }

    public IEnumerable<IDefence> Defences => _defences;


    private List<IDefence> _defences { get; set; }

    private bool _isInitialized { get; set; }


    public void Initialize(ICollectibleCharacter collectibleCharacter)
    {
        if (_isInitialized)
            throw new Exception($"Character is initialized before!");

        MaxHealth = collectibleCharacter.MaxHealth;
        CurrentHealth = MaxHealth;

        _defences = collectibleCharacter.Defences.ToList();
    }

    public void TakeDamage(IHit hit)
    {
        var suitableDefences = _defences.Where(x => x.DamageType == hit.DamageType);

        var finalDamage = hit.Value - hit.Value * suitableDefences.Select(x => x.RelativeDefence).Sum();

        CurrentHealth -= finalDamage;
    }

}
