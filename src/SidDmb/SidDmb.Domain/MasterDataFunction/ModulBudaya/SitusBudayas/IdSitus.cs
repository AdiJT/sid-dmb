using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Shared;
using System.Text.RegularExpressions;

namespace SidDmb.Domain.MasterDataFunction.ModulBudaya.SitusBudayas;

public class IdSitus : ValueObject, IEquatable<IdSitus>
{
    public const string ValidPattern = "^SB[0-9]{3}$";

    public string Value { get; set; }

    private IdSitus(string value)
    {
        Value = value;
    }

    public bool Equals(IdSitus? other) => base.Equals(other);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public override bool Equals(object? obj) => base.Equals(obj);

    public override int GetHashCode() => Value.GetHashCode();

    public static Result<IdSitus> Create(string value)
    {
        if (!Regex.IsMatch(value, ValidPattern))
            return new Error("IdSitus.TidakValid", "Id valid dimulai oleh SB dan diikuti 3 angka. Contoh SB001");

        return new IdSitus(value);
    }

    public static async Task<IdSitus> Generate(IRepositoriSitusBudaya repositoriSitusBudaya)
    {
        var newId = (await repositoriSitusBudaya.GetAll())
            .Select(s => int.Parse(s.Id.Value.Substring(2)))
            .Order()
            .LastOrDefault() + 1;

        return new($"SB{newId:D3}");
    }
}
