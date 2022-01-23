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


    private void Start()
    {
        Initialize();
    }


    public void TakeDamage(IHit hit)
    {
        var suitableDefences = _defences.Where(x => x.DamageType == hit.DamageType);

        var finalDamage = hit.Value - hit.Value * suitableDefences.Select(x => x.RelativeDefence).Sum();

        CurrentHealth -= finalDamage;
    }

    // TODO - calculate values from user's preferences
    private void Initialize()
    {
        MaxHealth = 1000;
        CurrentHealth = MaxHealth;

        _defences = new List<IDefence>
        {
            new Defence()
            {
                DamageType = DamageType.Physic,
                RelativeDefence = 0.2f
            }
        };
    }
}
