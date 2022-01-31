using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserPreferencesDto
{
    public int Money { get; set; }

    public IEnumerable<Deck> Decks { get; set; }

}
