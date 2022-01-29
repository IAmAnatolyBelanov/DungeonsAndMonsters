public class Deck
{
    public ICollectibleCharacter[] Characters { get; }

    public bool IsActive { get; set; }

    public Deck()
    {
        // 3 is maximum count of characters in user's deck
        Characters = new ICollectibleCharacter[3];
    }
}
