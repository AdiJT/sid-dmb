using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Shared;
using System.Text.RegularExpressions;

namespace SidDmb.Domain.ModulWisata;

public class LaporanKunjungan : Entity<IdKunjungan>, IAuditableEntity
{
    public required DateTime TanggalKunjungan { get; set; }
    public required int JumlahWisatawanDomestik { get; set; }
    public required int JumlahWisatawanInternasional { get; set; }
    public required TimeSpan DurasiKunjungan { get; set; }
    public required int TiketTerjual { get; set; }
    public required double RatingPengunjung { get; set; }
    public required string KomentarPengunjung { get; set; }

    public double PendapatanTiket => TiketTerjual * DestinasiWisata.HargaTiketMasuk;

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }

    public DestinasiWisata DestinasiWisata { get; set; }
}

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

public interface IRepositoriLaporanKunjungan
{
    Task<LaporanKunjungan?> Get(IdKunjungan id);
    Task<List<LaporanKunjungan>> GetAll();

    void Add(LaporanKunjungan laporanKunjungan);
    void Update(LaporanKunjungan laporanKunjungan);
    void Delete(LaporanKunjungan laporanKunjungan);
}