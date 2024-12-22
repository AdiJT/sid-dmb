using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Shared;
using System.Text.RegularExpressions;

namespace SidDmb.Domain.MasterDataFunction.ModulPrima.KegiatanPrimas;

public class IdKegiatanPrima : ValueObject, IEquatable<IdKegiatanPrima>
{
    public const string ValidPattern = "^KP[0-9]{3}$";

    public string Value { get; set; }

    private IdKegiatanPrima(string value)
    {
        Value = value;
    }

    public bool Equals(IdKegiatanPrima? other) => base.Equals(other);

    public override bool Equals(object? obj) => base.Equals(obj);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public override int GetHashCode() => base.GetHashCode();

    public static Result<IdKegiatanPrima> Create(string value)
    {
        if (!Regex.IsMatch(value, ValidPattern))
            return new Error("IdKegiatanPrima.TidakValid", "Id valid dimulai KP dan diikuti 3 angka. Contoh KP001");

        return new IdKegiatanPrima(value);
    }

    public static async Task<IdKegiatanPrima> Generate(IRepositoriKegiatanPrima repositoriKegiatanPrima)
    {
        var newId = (await repositoriKegiatanPrima.GetAll())
            .Select(k => int.Parse(k.Id.Value.Substring(2)))
            .Order()
            .LastOrDefault() + 1;

        return new($"KP{newId:D3}");
    }
}
