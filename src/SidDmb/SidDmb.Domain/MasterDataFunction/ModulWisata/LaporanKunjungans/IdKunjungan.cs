using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Shared;
using System.Text.RegularExpressions;

namespace SidDmb.Domain.MasterDataFunction.ModulWisata.LaporanKunjungans;

public class IdKunjungan : ValueObject, IEquatable<IdKunjungan>
{
    public const string ValidPattern = "^LK[0-9]{3}$";

    public string Value { get; }

    private IdKunjungan(string value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public bool Equals(IdKunjungan? other) => base.Equals(other);

    public static Result<IdKunjungan> Create(string value)
    {
        if (!Regex.IsMatch(value, ValidPattern))
            return new Error("IdKunjungan.TidakValid", "ID valid dimulai oleh LK dan diikuti 3 angka");

        return new IdKunjungan(value);
    }

    public static async Task<IdKunjungan> Generate(IRepositoriLaporanKunjungan repositoriLaporanKunjungan)
    {
        var lastId = (await repositoriLaporanKunjungan.GetAll())
            .Select(d => int.Parse(d.Id.Value.Substring(2)))
            .OrderBy(i => i)
            .LastOrDefault();

        return new($"LK{lastId + 1:D3}");
    }

    public override bool Equals(object? obj) => base.Equals(obj);

    public override int GetHashCode() => base.GetHashCode();
}
