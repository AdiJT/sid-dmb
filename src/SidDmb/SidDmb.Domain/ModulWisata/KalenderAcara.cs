using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Shared;
using System.Text.RegularExpressions;

namespace SidDmb.Domain.ModulWisata;

public class KalenderAcara : Entity<IdAcara>, IAuditableEntity
{
    public required string NamaAcara { get; set; }
    public required string DekripsiAcara { get; set; }
    public required KategoriAcara Kategori { get; set; }
    public required DateTime TanggalDanWaktu { get; set; }
    public required string LokasiAcara { get; set; }
    public required string PenanggungJawab { get; set; }
    public required string KontakInformasi { get; set; }
    public required double HargaTiketAcara { get; set; }
    public required TargetPesertaAcara TargetPesertaAcara { get; set; }
    public required int BatasKuotaPeserta { get; set; }
    public required StatusPendaftaran StatusPendaftaran { get; set; }
    public required Uri MediaPromosi { get; set; }
    public required string SponsorAcara { get; set; }
    public required Uri TautanPendaftaran { get; set; }
    public required double RatingAcara { get; set; }

    public required DateTime TanggalDiinputkan { get; set; }
    public required DateTime TanggalPembaruanData { get; set; }
}

public class IdAcara : ValueObject, IEquatable<IdAcara>
{
    public const string ValidPattern = "^AC[0-9]{3}$";

    public string Value { get; }

    private IdAcara(string value)
    {
        Value = value;
    }

    public bool Equals(IdAcara? other) => base.Equals(other);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static Result<IdAcara> Create(string value)
    {
        if (!Regex.IsMatch(value, ValidPattern))
            return new Error("IdAcara.TidakValid", "Id valid dimulai AC dan diikuti 3 angka. Contoh : AC001");

        return new IdAcara(value);
    }

    public static async Task<IdAcara> Generate(IRepositoriKalenderAcara repositoriKalenderAcara)
    {
        var lastId = (await repositoriKalenderAcara.GetAll())
            .Select(k => int.Parse(k.Id.Value.Substring(2)))
            .Order()
            .LastOrDefault();

        return new($"AC{lastId + 1:D3}");
    }

    public override bool Equals(object? obj) => base.Equals(obj);

    public override int GetHashCode() => base.GetHashCode();
}

public enum KategoriAcara
{
    Budaya, Olahraga, Edukasi, Lainnya
}

public enum TargetPesertaAcara
{
    Umum, AnakAnak, Pelajar, Dewasa, Lainnya
}

public enum StatusPendaftaran
{
    Dibuka, Ditutup, Penuh
}

public interface IRepositoriKalenderAcara
{
    Task<KalenderAcara?> Get(IdAcara id);
    Task<List<KalenderAcara>> GetAll();

    void Add(KalenderAcara kalenderAcara);
    void Update(KalenderAcara kalenderAcara);
    void Delete(KalenderAcara kalenderAcara);
}