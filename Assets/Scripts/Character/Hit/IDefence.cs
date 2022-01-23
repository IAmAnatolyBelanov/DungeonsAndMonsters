public interface IDefence
{
    public DamageType DamageType { get; }
    
    /// <summary>
    /// How much relative damage will be absorbed by the defense.<para\>
    /// If damage equals 500 and RelativeDefence equals 0.1, then it would be absorbed 50 damage
    /// </summary>
    /// <value></value>
    public float RelativeDefence { get; }
}
