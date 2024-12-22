using NetTopologySuite.Geometries;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Shared;
using System.Text.RegularExpressions;

namespace SidDmb.Domain.MasterDataFunction.ModulWisata;

public class DestinasiWisata : Entity<IdDestinasi>, IAuditableEntity
{
    public string Nama { get; set; } = string.Empty;
    public string Deskripsi { get; set; } = string.Empty;
    public KategoriDestinasi Kategori { get; set; }
    public string Alamat { get; set; } = string.Empty;
    public Point TitikKoordinat { get; set; } = Point.Empty;
    public string[] DaftarFasilitas { get; set; } = [];
    public double HargaTiketMasuk { get; set; }
    public string JamOperasional { get; set; } = string.Empty;
    public string InformasiKontak { get; set; } = string.Empty;
    public string PengelolaDestinasi { get; set; } = string.Empty;
    public string[] DaftarAktivitas { get; set; } = [];
    public StatusOperasional StatusOperasional { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }

    public List<LaporanKunjungan> DaftarLaporanKunjungan { get; set; } = [];
}

public class IdDestinasi : ValueObject, IEquatable<IdDestinasi>
{
    private const string ValidPattern = "^DW[0-9]{3}$";

    public string Value { get; }

    private IdDestinasi(string value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public bool Equals(IdDestinasi? other) => base.Equals(other);

    public static Result<IdDestinasi> Create(string value)
    {
        if (!Regex.IsMatch(value, ValidPattern))
            return new Error("IdDestinasi.TidakValid", "ID valid dimulai oleh DW dan diikuti 3 angka");

        return new IdDestinasi(value);
    }

    public static async Task<IdDestinasi> Generate(IRepositoriDestinasiWisata repositoriDestinasiWisata)
    {
        var lastId = (await repositoriDestinasiWisata.GetAll())
            .Select(d => int.Parse(d.Id.Value.Substring(2)))
            .OrderBy(i => i)
            .LastOrDefault();

        return new($"DW{lastId + 1:D3}");
    }

    public override bool Equals(object? obj) => base.Equals(obj);

    public override int GetHashCode() => base.GetHashCode();
}

public enum StatusOperasional
{
    Buka, TutupSementara, Ditutup
}

public enum KategoriDestinasi
{
    Alam, Budaya, Sejarah
}

public interface IRepositoriDestinasiWisata
{
    Task<DestinasiWisata?> Get(IdDestinasi id);
    Task<List<DestinasiWisata>> GetAll();

    void Add(DestinasiWisata destinasi);
    void Update(DestinasiWisata destinasi);
    void Delete(DestinasiWisata destinasi);
}