using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Shared;
using System.Text.RegularExpressions;

namespace SidDmb.Domain.MasterDataFunction.ModulBudaya;

public class SeniBudaya : Entity<IdSeni>, IAuditableEntity
{
    public required string Nama { get; set; }
    public required string Dekripsi { get; set; }
    public required KategoriSeni Kategori { get; set; }
    public required string NamaPelakuSeni { get; set; }
    public required string LokasiPertunjukan { get; set; }
    public required string WaktuPertunjukan { get; set; }
    public required string[] FasilitasPertunjukan { get; set; } = [];
    public required TimeSpan DurasiPentunjukan { get; set; }
    public required double HargaTiket { get; set; }
    public required string PeraturanKhusus { get; set; }
    public required Uri MediaPromosi { get; set; }
    public required double RatingPenonton { get; set; }
    public required string KomentarPenonton { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }
}

public enum KategoriSeni
{
    Tari, Musik, Drama, Lukisan, Lainnya
}

public class IdSeni : ValueObject, IEquatable<IdSeni>
{
    private const string ValidPattern = "^SB[0-9]{3}$";

    public string Value { get; }

    private IdSeni(string value)
    {
        Value = value;
    }

    public bool Equals(IdSeni? other) => base.Equals(other);

    public override bool Equals(object? obj) => base.Equals(obj);

    public override int GetHashCode() => base.GetHashCode();

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static Result<IdSeni> Create(string value)
    {
        if (!Regex.IsMatch(value, ValidPattern))
            return new Error("IdSeni.TidakValid", "Id valid dimulai oleh SB dan diikuti 3 angka. Contoh SB001");

        return new IdSeni(value);
    }

    public static async Task<IdSeni> Generate(IRepositoriSeniBudaya repositoriSeniBudaya)
    {
        var newId = (await repositoriSeniBudaya.GetAll())
            .Select(s => int.Parse(s.Id.Value.Substring(2)))
            .Order()
            .LastOrDefault() + 1;

        return new($"SB{newId:D3}");
    }
}

public interface IRepositoriSeniBudaya
{
    Task<SeniBudaya?> Get(IdSeni id);
    Task<List<SeniBudaya>> GetAll();

    void Add(SeniBudaya seniBudaya);
    void Update(SeniBudaya seniBudaya);
    void Delete(SeniBudaya seniBudaya);
}