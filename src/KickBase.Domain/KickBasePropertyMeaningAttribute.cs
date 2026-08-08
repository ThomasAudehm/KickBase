namespace KickBase.Domain;

[AttributeUsage(AttributeTargets.Class)]
public class KickBaseApi : Attribute;

[AttributeUsage(AttributeTargets.Property)]
public class KickBasePropertyMeaningAttribute : Attribute
{
    public KickbasePropertyMeaning Meaning { get; init; }
    public KickBasePropertyMeaningAttribute(KickbasePropertyMeaning meaning) =>  Meaning = meaning;
}

public enum KickbasePropertyMeaning
{
    Unknown,
    Guess,
    Verified
} 