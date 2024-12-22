using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Shared;
using System.Text.RegularExpressions;

namespace SidDmb.Domain.MasterDataFunction.ModulPrima.KelompokPrimas;

public class IdKelompok : ValueObject, IEquatable<IdKelompok>
{
    public const string ValidPattern = "^KP[0-9]{3}$";

    public string Value { get; set; }

    private IdKelompok(string value)
    {
        Value = value;
    }

    public bool Equals(IdKelompok? other) => base.Equals(other);

    public override bool Equals(object? obj) => base.Equals(obj);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public override int GetHashCode() => base.GetHashCode();

    public static Result<IdKelompok> Create(string value)
    {
        if (!Regex.IsMatch(value, ValidPattern))
            return new Error("IdKelompok.TidakValid", "Id valid dimulai KP dan diikuti 3 angka. Contoh KP001");

        return new IdKelompok(value);
    }

    public static async Task<IdKelompok> Generate(IRepositoriKelompokPrima repositoriKelompokPrima)
    {
        var newId = (await repositoriKelompokPrima.GetAll())
            .Select(k => int.Parse(k.Id.Value.Substring(2)))
            .Order()
            .LastOrDefault() + 1;

        return new($"KP{newId:D3}");
    }
}
