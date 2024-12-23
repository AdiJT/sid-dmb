using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Shared;
using System.Text.RegularExpressions;

namespace SidDmb.Domain.CollaborationFunction.ModulResearchAndDevelopment.RekomendasiDanPengembanganProduk;

public class IdRekomendasi : ValueObject, IEquatable<IdRekomendasi>
{
    public const string ValidPattern = "^RP[0-9]{3}$";

    public string Value { get; set; }

    private IdRekomendasi(string value)
    {
        Value = value;
    }

    public bool Equals(IdRekomendasi? other) => base.Equals(other);

    public override bool Equals(object? obj) => base.Equals(obj);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public override int GetHashCode() => base.GetHashCode();

    public static Result<IdRekomendasi> Create(string value)
    {
        if (!Regex.IsMatch(value, ValidPattern))
            return new Error("IdRekomendasi.TidakValid", "Id valid dimulai oleh RD dan diikuti 3 angka");

        return new IdRekomendasi(value);
    }

    public static async Task<IdRekomendasi> Generate(IRepositoriRekomendasi repositoriRekomendasi)
    {
        var newId = (await repositoriRekomendasi.GetAll())
            .Select(a => int.Parse(a.Id.Value.Substring(2)))
            .Order()
            .LastOrDefault() + 1;

        return new($"RP{newId:3}");
    }
}
