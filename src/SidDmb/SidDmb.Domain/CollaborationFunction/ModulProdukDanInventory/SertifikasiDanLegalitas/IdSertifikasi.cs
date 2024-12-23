using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Shared;
using System.Text.RegularExpressions;

namespace SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.SertifikasiDanLegalitas;

public class IdSertifikasi : ValueObject, IEquatable<IdSertifikasi>
{
    public const string ValidPattern = "^SL[0-9]{3}$";

    public string Value { get; set; }

    private IdSertifikasi(string value)
    {
        Value = value;
    }

    public bool Equals(IdSertifikasi? other) => base.Equals(other);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public override bool Equals(object? obj) => base.Equals(obj);

    public override int GetHashCode() => base.GetHashCode();

    public static Result<IdSertifikasi> Create(string value)
    {
        if (!Regex.IsMatch(value, ValidPattern))
            return new Error("IdSertifikasi.TidakValid", "Id valid dimulai oleh SL dan diikuti 3 angka. Contoh SL001");

        return new IdSertifikasi(value);
    }

    public static async Task<IdSertifikasi> Generate(IRepositoriSertifikasi repositoriSertifikasi)
    {
        var newId = (await repositoriSertifikasi.GetAll())
            .Select(s => int.Parse(s.Id.Value.Substring(2)))
            .Order()
            .LastOrDefault() + 1;

        return new($"SL{newId:D3}");
    }
}
