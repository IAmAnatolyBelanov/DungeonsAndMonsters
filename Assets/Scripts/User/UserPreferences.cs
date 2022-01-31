using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

public static class UserPreferences
{
    public static int Money { get; private set; }

    public static IEnumerable<Deck> Decks { get; private set; }

    public static Deck ActiveDeck => Decks.FirstOrDefault(x => x.IsActive)
        ?? Decks.FirstOrDefault()
        ?? throw new NullReferenceException($"{nameof(Decks)} is empty!");

    private static string _path = Path.Combine(Application.persistentDataPath, "userPreferences.json");

    static UserPreferences()
    {
        if (File.Exists(_path))
            Load();
        else
            CreateDefaultPreferences();
    }

    public static void Load()
    {
        // TODO - decrypt data
        // TODO - load preferences from GooglePlayService

        if (!File.Exists(_path))
            throw new FileNotFoundException("Can't find file", _path);

        var preferencesDtoJson = File.ReadAllText(_path);

        var preferencesDto = JsonConvert.DeserializeObject<UserPreferencesDto>(preferencesDtoJson);

        FillPropertiesFromDto(preferencesDto);
    }

    public static void Save()
    {
        // TODO - encrypt data

        var dto = new UserPreferencesDto()
        {
            Decks = Decks,
            Money = Money
        };

        var dtoJson = JsonConvert.SerializeObject(dto);

        File.WriteAllText(_path, dtoJson);
    }

    private static void FillPropertiesFromDto(UserPreferencesDto dto)
    {
        // TODO - using reflection or automapper

        Money = dto.Money;
        Decks = dto.Decks;
    }

    private static void CreateDefaultPreferences()
    {
        Money = 30;

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
}
