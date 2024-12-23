using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Shared;
using System.Text.RegularExpressions;

namespace SidDmb.Domain.CollaborationFunction.ModulResearchAndDevelopment.ManajemenDataRiset;

public class IdDataRiset : ValueObject, IEquatable<IdDataRiset>
{
    public const string ValidPattern = "^RD[0-9]{3}$";
    public string Value { get; set; }

    private IdDataRiset(string value)
    {
        Value = value;
    }

    public override bool Equals(object? obj) => base.Equals(obj);

    public override int GetHashCode() => base.GetHashCode();

    public bool Equals(IdDataRiset? other) => base.Equals(other);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static Result<IdDataRiset> Create(string value)
    {
        if (!Regex.IsMatch(value, ValidPattern))
            return new Error("IdDataRiset.Tidakvalid", "Id valid dimulai oleh RD dan diikuti 3 angka");

        return new IdDataRiset(value);
    }

    public static async Task<IdDataRiset> Generate(IRepositoriDataRiset repositoriDataRiset)
    {
        var newId = (await repositoriDataRiset.GetAll())
            .Select(d => int.Parse(d.Id.Value.Substring(2)))
            .Order()
            .LastOrDefault() + 1;

        return new($"RD{newId:D3}");
    }
}
