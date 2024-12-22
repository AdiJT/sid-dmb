using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Shared;
using System.Text.RegularExpressions;

namespace SidDmb.Domain.MasterDataFunction.ModulPreneur.UnitUsahas;

public class IdUnitUsaha : ValueObject, IEquatable<IdUnitUsaha>
{
    public const string ValidPattern = "^UU[0-9]{3}$";

    public string Value { get; set; }

    private IdUnitUsaha(string value)
    {
        Value = value;
    }

    public bool Equals(IdUnitUsaha? other) => base.Equals(other);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public override bool Equals(object? obj) => base.Equals(obj);

    public override int GetHashCode() => base.GetHashCode();

    public static Result<IdUnitUsaha> Create(string value)
    {
        if (!Regex.IsMatch(value, ValidPattern))
            return new Error("IdUnitUsaha.TidakValid", "Id valid dimulai oleh UU diikuti 3 angka. Contoh UU001");

        return new IdUnitUsaha(value);
    }

    public static async Task<IdUnitUsaha> Generate(IRepositoriUnitUsaha repositoriUnitUsaha)
    {
        var newId = (await repositoriUnitUsaha.GetAll())
            .Select(u => int.Parse(u.Id.Value.Substring(2)))
            .Order()
            .LastOrDefault() + 1;

        return new($"UU{newId:D3}");
    }
}
