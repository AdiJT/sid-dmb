using SidDmb.Domain.Abstracts;

namespace SidDmb.Domain.ValueObjects;

public class IdDestinasi : ValueObject, IEquatable<IdDestinasi>
{
    public string Value { get; }

    public IdDestinasi(string value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public bool Equals(IdDestinasi? other) => base.Equals(other);
}
