using System.Collections.Generic;
using Newtonsoft.Json;

public class CollectibleCharacter : ICollectibleCharacter
{
    public string Id { get; set; }

    public string Name { get; set; }

    public float MaxHealth { get; set; }

    public string PrefabPath { get; set; }

    public IEnumerable<IDefence> Defences { get; set; }


    public CollectibleCharacter()
    {

    }

    [JsonConstructor]
    public CollectibleCharacter(string id, string name, float maxHealth, string prefabPath, IEnumerable<Defence> defences)
    {
        Id = id;
        Name = name;
        MaxHealth = maxHealth;
        PrefabPath = prefabPath;
        Defences = defences;
    }
}
