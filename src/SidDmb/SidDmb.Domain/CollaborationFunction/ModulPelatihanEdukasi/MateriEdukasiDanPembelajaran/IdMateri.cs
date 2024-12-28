using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Shared;
using System.Text.RegularExpressions;

namespace SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi.MateriEdukasiDanPembelajaran;

public class IdMateri : ValueObject, IEquatable<IdMateri>
{
    public const string ValidPattern = "^ME[0-9]{3}$";

    public string Value { get; }

    private IdMateri(string value)
    {
        Value = value;
    }

    public bool Equals(IdMateri? other) => base.Equals(other);

    public override bool Equals(object? obj) => base.Equals(obj);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public override int GetHashCode() => base.GetHashCode();

    public static Result<IdMateri> Create(string value)
    {
        if (!Regex.IsMatch(value, ValidPattern))
            return new Error("IdMateri.TidakValid", "Id valid dimulai ME dan diikuti 3 angka. Contoh ME001");

        return new IdMateri(value);
    }

    public static async Task<IdMateri> Generate(IRepositoriMateri repositoriMateriEdukasiDanPembelajaran)
    {
        var newId = (await repositoriMateriEdukasiDanPembelajaran.GetAll())
            .Select(m => int.Parse(m.Id.Value.Substring(2)))
            .Order()
            .LastOrDefault() + 1;

        return new($"ME{newId:D3}");
    }
}
