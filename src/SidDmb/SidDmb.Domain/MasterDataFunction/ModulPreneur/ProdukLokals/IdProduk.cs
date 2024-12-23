using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Shared;
using System.Text.RegularExpressions;

namespace SidDmb.Domain.MasterDataFunction.ModulPreneur.ProdukLokals;

public class IdProduk : ValueObject, IEquatable<IdProduk>
{
    public const string ValidPattern = "^PL[0-9]{3}$";

    public string Value { get; set; }

    private IdProduk(string value)
    {
        Value = value;
    }

    public bool Equals(IdProduk? other) => base.Equals(other);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public override bool Equals(object? obj) => base.Equals(obj);

    public override int GetHashCode() => base.GetHashCode();

    public static Result<IdProduk> Create(string value)
    {
        if (!Regex.IsMatch(value, ValidPattern))
            return new Error("IdProduk.TidakValid", "Id valid dimulai oleh PL diikuti 3 angka. Contoh PL001");

        return new IdProduk(value);
    }

    public static async Task<IdProduk> Generate(IRepositoriProdukLokal repositoriProdukLokal)
    {
        var newId = (await repositoriProdukLokal.GetAll())
            .Select(p => int.Parse(p.Id.Value.Substring(2)))
            .Order()
            .LastOrDefault() + 1;

        return new($"PL{newId:D3}");
    }
}
