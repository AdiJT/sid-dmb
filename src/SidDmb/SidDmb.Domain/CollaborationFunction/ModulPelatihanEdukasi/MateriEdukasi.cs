using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Shared;
using System.Text.RegularExpressions;

namespace SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi;

public class MateriEdukasiDanPembelajaran : Entity<IdMateri>, IAuditableEntity
{
    public required string JudulMateri { get; set; }
    public required string DekripsiMateri { get; set; }
    public required KategoriMateri KategoriMateri { get; set; }
    public required string PenyediaMateri { get; set; }
    public required TargetAudiens TargetAudiens { get; set; }
    public required TipeMateri TipeMateri { get; set; }
    public required Uri LinkUnduhan { get; set; }
    public required DateOnly TanggalRilis { get; set; }
    public required string FeedBackAudiens { get; set; }
    public required string[] KolaboratorDalamMateri { get; set; }
    public required Uri DokumenPendukung { get; set; }
    public required int JumlahPengguna { get; set; }
    public required StatusMateri StatusMateri { get; set; }
    public required string RekomendasiPembaruanMateri { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }
}

[Flags]
public enum TargetAudiens
{
    Pokdarwis = 0, KelompokBudaya = 2, UMKM = 4, Lainnya = 8
}

[Flags]
public enum KategoriMateri
{
    Praktis = 0, Teoritis = 2, Pelatihan = 4, Lainnya = 8
}

public enum TipeMateri
{
    PDF, Video, Presentasi, Lainnya
}

public enum StatusMateri
{
    Berlaku, Kadaluarsa, PerluPembaruan
}

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

    public static async Task<IdMateri> Generate(IRepositoriMateriEdukasiDanPembelajaran repositoriMateriEdukasiDanPembelajaran)
    {
        var newId = (await repositoriMateriEdukasiDanPembelajaran.GetAll())
            .Select(m => int.Parse(m.Id.Value.Substring(2)))
            .Order()
            .LastOrDefault() + 1;

        return new($"ME{newId:3}");
    }
}

public interface IRepositoriMateriEdukasiDanPembelajaran
{
    Task<MateriEdukasiDanPembelajaran?> Get(IdMateri id);
    Task<List<MateriEdukasiDanPembelajaran>> GetAll();

    void Add(MateriEdukasiDanPembelajaran materiEdukasiDanPembelajaran);
    void Update(MateriEdukasiDanPembelajaran materiEdukasiDanPembelajaran);
    void Delete(MateriEdukasiDanPembelajaran materiEdukasiDanPembelajaran);
}