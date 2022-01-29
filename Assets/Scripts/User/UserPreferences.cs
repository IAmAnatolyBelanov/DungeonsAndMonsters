using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class UserPreferences
{
    static UserPreferences()
    {
        // TODO - getting preferences from DB and google play games

        Money = 1000;

        var decks = new List<Deck>
        {
            new Deck()
        };

        decks[0].Characters[0] = new CollectibleCharacter() 
        {
            Id = Guid.NewGuid().ToString(),
            MaxHealth = 300,
            Name = "Blue mage",
            PrefabPath = Constant.ResourcePath.BlueMagePath,
            Defences = new List<Defence>()
            {
                new Defence() 
                {
                    DamageType = DamageType.Air,
                    RelativeDefence = 0.05f
                },
                new Defence()
                {
                    DamageType = DamageType.Mind,
                    RelativeDefence = 0.02f
                }
            }
        };
        decks[0].Characters[1] = new CollectibleCharacter() 
        {
            Id = Guid.NewGuid().ToString(),
            MaxHealth = 600,
            Name = "Brown mage",
            PrefabPath = Constant.ResourcePath.BrownMagePath,
            Defences = new List<Defence>()
            {
                new Defence() 
                {
                    DamageType = DamageType.Earth,
                    RelativeDefence = 0.30f
                }
            }
        };
        decks[0].Characters[2] = new CollectibleCharacter() 
        {
            Id = Guid.NewGuid().ToString(),
            MaxHealth = 200,
            Name = "Purple mage",
            PrefabPath = Constant.ResourcePath.PurpleMagePath,
            Defences = new List<Defence>()
            {
                new Defence() 
                {
                    DamageType = DamageType.Physic,
                    RelativeDefence = 0.8f
                }
            }
        };

        Decks = decks;
    }

    public static int Money { get; private set; }

    public static IEnumerable<Deck> Decks { get; private set; }

    public static Deck ActiveDeck => Decks.FirstOrDefault(x => x.IsActive)
        ?? Decks.FirstOrDefault()
        ?? throw new NullReferenceException($"{nameof(Decks)} is empty!");
}
