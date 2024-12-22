using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Shared;
using System.Text.RegularExpressions;

namespace SidDmb.Domain.MasterDataFunction.ModulPrima;

public class KegiatanPrima : Entity<IdKegiatanPrima>, IAuditableEntity
{
    public required string Nama { get; set; }
    public required string Dekripsi { get; set; }
    public required DateOnly TanggalPelaksanaan { get; set; }
    public required TimeSpan Durasi { get; set; }
    public required string Lokasi { get; set; }
    public required JenisKegiatan Jenis { get; set; }
    public required int JumlahPeserta { get; set; }
    public required string Fasilitator { get; set; }
    public required double AnggaranKegiatan { get; set; }
    public required string[] KolaboratorKegiatan { get; set; }
    public required string HasilKegiatan { get; set; }
    public required Uri DokumentasiKegiatan { get; set; }
    public required string FeedbackPeserta { get; set; }
    public required string RekomendasiUntukKegiatanBerikutnya { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }

    public KelompokPrima KelompokPrima { get; set; }
}

public enum JenisKegiatan
{
    Pelatihan, Seminar, PraktikLapangan
}

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

public interface IRepositoriKegiatanPrima
{
    Task<KegiatanPrima?> Get(IdKegiatanPrima id);
    Task<List<KegiatanPrima>> GetAll();

    void Add(KegiatanPrima kegiatanPrima);
    void Update(KegiatanPrima kegiatanPrima);
    void Delete(KegiatanPrima kegiatanPrima);
}