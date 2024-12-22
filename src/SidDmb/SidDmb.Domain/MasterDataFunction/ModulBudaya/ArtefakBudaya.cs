using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Shared;
using System.Text.RegularExpressions;

namespace SidDmb.Domain.MasterDataFunction.ModulBudaya;

public class ArtefakBudaya : Entity<IdArtefak>, IAuditableEntity
{
    public required string Nama { get; set; }
    public required string Dekripsi { get; set; }
    public required KategoriArtefak Kategori { get; set; }
    public required string LokasiPenyimpanan { get; set; }
    public required KondisiArtefak Kondisi { get; set; }
    public required string Usia { get; set; }
    public required string Bahan { get; set; }
    public required string Dimensi { get; set; }
    public required string Pengelola { get; set; }
    public required string NilaiHistoris { get; set; }
    public required Uri Foto { get; set; }
    public required KetersediaanPameran Ketersediaan { get; set; }
    public required double RatingPengunjung { get; set; }
    public required string KomentarPengunjung { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }
}

public interface IRepositoriArtefakBudaya
{
    Task<ArtefakBudaya?> Get(IdArtefak id);
    Task<List<ArtefakBudaya>> GetAll();
}

public class IdArtefak : ValueObject, IEquatable<IdArtefak>
{
    private const string ValidPattern = "^AR[0-9]{3}$";

    public string Value { get; }

    private IdArtefak(string value)
    {
        Value = value;
    }

    public bool Equals(IdArtefak? other) => base.Equals(other);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static Result<IdArtefak> Create(string value)
    {
        if (!Regex.IsMatch(value, ValidPattern))
            return new Error("IdArtefak.TidakValid", "Id valid dimulai AR dan diikuti 3 angka");

        return new IdArtefak(value);
    }

    public static async Task<IdArtefak> Generate(IRepositoriArtefakBudaya repositoriArtefakBudaya)
    {
        var newId = (await repositoriArtefakBudaya.GetAll())
            .Select(a => int.Parse(a.Id.Value.Substring(2)))
            .Order()
            .LastOrDefault() + 1;

        return new($"AC{newId:D3}");
    }

    public override bool Equals(object? obj) => base.Equals(obj);

    public override int GetHashCode() => base.GetHashCode();
}

public enum KategoriArtefak
{
    Ritual, Seni, Artefak, Lainnya
}

public enum KondisiArtefak
{
    Baik, MemerlukanPerawatan, Rusak
}

public enum KetersediaanPameran
{
    Ya, Tidak
}