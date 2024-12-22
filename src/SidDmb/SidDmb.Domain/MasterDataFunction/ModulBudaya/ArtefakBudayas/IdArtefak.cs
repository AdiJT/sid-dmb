using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Shared;
using System.Text.RegularExpressions;

namespace SidDmb.Domain.MasterDataFunction.ModulBudaya.ArtefakBudayas;

public class IdArtefak : ValueObject, IEquatable<IdArtefak>
{
    private const string ValidPattern = "^AR[0-9]{3}$";

    public string Value { get; }

    private IdArtefak(string value)
    {
        Value = value;
    }

    public bool Equals(IdArtefak? other) => base.Equals(other);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static Result<IdArtefak> Create(string value)
    {
        if (!Regex.IsMatch(value, ValidPattern))
            return new Error("IdArtefak.TidakValid", "Id valid dimulai AR dan diikuti 3 angka");

        return new IdArtefak(value);
    }

    public static async Task<IdArtefak> Generate(IRepositoriArtefakBudaya repositoriArtefakBudaya)
    {
        var newId = (await repositoriArtefakBudaya.GetAll())
            .Select(a => int.Parse(a.Id.Value.Substring(2)))
            .Order()
            .LastOrDefault() + 1;

        return new($"AC{newId:D3}");
    }

    public override bool Equals(object? obj) => base.Equals(obj);

    public override int GetHashCode() => base.GetHashCode();
}
