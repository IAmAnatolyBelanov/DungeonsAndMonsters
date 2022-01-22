using System.Collections.Generic;

public interface IBaseCharacter
{
    float MaxHealth { get; }
    float CurrentHealth { get; }

    IEnumerable<IDefence> Defences { get; }

    void TakeDamage(IHit hit);
}
