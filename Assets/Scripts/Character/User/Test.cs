using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public UserCharacter User;

    public bool Flag = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        if (!Flag)
            return;
 
        Flag = false;

        var userMaxHealth = User.MaxHealth;
        var currentHealth = User.CurrentHealth;

        var hit = new Hit()
        {
            DamageType = DamageType.Physic,
            Value = 5,
        };

        User.TakeDamage(hit);
    }
}
