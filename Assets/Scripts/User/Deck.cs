using System.Linq;
using Newtonsoft.Json;

public class Deck
{
    public ICollectibleCharacter[] Characters { get; }

    public bool IsActive { get; set; }

    public Deck()
    {
        // 3 is maximum count of characters in user's deck
        Characters = new ICollectibleCharacter[3];
    }

    [JsonConstructor]
    public Deck(CollectibleCharacter[] characters, bool isActive)
    {
        Characters = characters.ToArray();
        IsActive = isActive;
    }
}
