using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Shared;
using System.Text.RegularExpressions;

namespace SidDmb.Domain.MasterDataFunction.ModulBudaya.SeniBudayas;

public class IdSeni : ValueObject, IEquatable<IdSeni>
{
    private const string ValidPattern = "^SB[0-9]{3}$";

    public string Value { get; }

    private IdSeni(string value)
    {
        Value = value;
    }

    public bool Equals(IdSeni? other) => base.Equals(other);

    public override bool Equals(object? obj) => base.Equals(obj);

    public override int GetHashCode() => base.GetHashCode();

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static Result<IdSeni> Create(string value)
    {
        if (!Regex.IsMatch(value, ValidPattern))
            return new Error("IdSeni.TidakValid", "Id valid dimulai oleh SB dan diikuti 3 angka. Contoh SB001");

        return new IdSeni(value);
    }

    public static async Task<IdSeni> Generate(IRepositoriSeniBudaya repositoriSeniBudaya)
    {
        var newId = (await repositoriSeniBudaya.GetAll())
            .Select(s => int.Parse(s.Id.Value.Substring(2)))
            .Order()
            .LastOrDefault() + 1;

        return new($"SB{newId:D3}");
    }
}
