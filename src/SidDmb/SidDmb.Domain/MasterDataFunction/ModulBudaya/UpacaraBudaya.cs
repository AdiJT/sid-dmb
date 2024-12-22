using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Shared;
using System.Text.RegularExpressions;

namespace SidDmb.Domain.MasterDataFunction.ModulBudaya;

public class UpacaraBudaya : Entity<IdUpacara>, IAuditableEntity
{
    public required string Nama { get; set; }
    public required string Dekripsi { get; set; }
    public required KategoriUpacara Kategori { get; set; }
    public required string LokasiPelaksanaan { get; set; }
    public required DateTime WaktuPelaksanaan { get; set; }
    public required TimeSpan Durasi { get; set; }
    public required string PihakTerlibat { get; set; }
    public required string RangkaianAcara { get; set; }
    public required int JumlahUpacara { get; set; }
    public required string[] FasilitasPendukung { get; set; }
    public required Uri MediaPromosi { get; set; }
    public required double RatingPeserta { get; set; }
    public required string KomentarPeserta { get; set; }
    public required string PeraturanKhusus { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }
}

public enum KategoriUpacara
{
    Keagamaan, Adat, Sosial, Lainnya
}

public class IdUpacara : ValueObject, IEquatable<IdUpacara>
{
    private const string ValidPattern = "^UB[0-9]{3}$";

    public string Value { get; }

    private IdUpacara(string value)
    {
        Value = value;
    }

    public bool Equals(IdUpacara? other) => base.Equals(other);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public override int GetHashCode() => base.GetHashCode();

    public override bool Equals(object? obj) => obj is not null && obj is IdUpacara other && base.Equals(other);

    public static Result<IdUpacara> Create(string value)
    {
        if (!Regex.IsMatch(value, ValidPattern))
            return new Error("IdUpacara.TidakValid", "Id valid dimulai UB dan 3 angka. Contoh UB001");

        return new IdUpacara(value);
    }

    public static async Task<IdUpacara> Generate(IRepositoriUpacaraBudaya repositoriUpacaraBudaya)
    {
        var newId = (await repositoriUpacaraBudaya.GetAll())
            .Select(u => int.Parse(u.Id.Value.Substring(2)))
            .Order()
            .LastOrDefault() + 1;

        return new($"UB{newId:D3}");
    }
}

public interface IRepositoriUpacaraBudaya
{
    Task<UpacaraBudaya?> Get(IdUpacara id);
    Task<List<UpacaraBudaya>> GetAll();

    void Add(UpacaraBudaya upacaraBudaya);
    void Update(UpacaraBudaya upacaraBudaya);
    void Delete(UpacaraBudaya upacaraBudaya);
}