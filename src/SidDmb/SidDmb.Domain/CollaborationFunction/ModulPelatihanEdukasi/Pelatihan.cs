using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Shared;
using System.Text.RegularExpressions;

namespace SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi;

public class Pelatihan : Entity<IdPelatihan>, IAuditableEntity
{
    public required string Nama { get; set; }
    public required string Dekripsi { get; set; }
    public required KategoriPelatihan Kategori { get; set; }
    public required string Penyelenggara { get; set; }
    public required DateOnly TanggalPelaksanaan { get; set; }
    public required TimeSpan Durasi { get; set; }
    public required string Lokasi { get; set; }
    public required TargetPeserta TargetPeserta { get; set; }
    public required int JumlahPeserta { get; set; }
    public required string Fasilitator { get; set; }
    public required string Materi { get; set; }
    public required string EvaluasiPeserta { get; set; }
    public required Uri DokumenDanMedia { get; set; }
    public required string FeedbackPeserta { get; set; }
    public required KolaboratorPelatihan KolaboratorPelatihan { get; set; }
    public required string RekomendasiUntukPelatihanBerikutnya { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }
}

public enum KategoriPelatihan
{
    Kewirausahaan, Manajemen, Motivasi
}

[Flags]
public enum TargetPeserta
{
    Pokdarwis = 0, KelompokWisata = 2, KelompokBudaya = 4
}

[Flags]
public enum KolaboratorPelatihan
{
    Akedemisi = 0, DinasParawisata = 2
}

public class IdPelatihan : ValueObject, IEquatable<IdPelatihan>
{
    public const string ValidPattern = "^PC[0-9]{3}$";

    public string Value { get; }

    private IdPelatihan(string value)
    {
        Value = value;
    }

    public bool Equals(IdPelatihan? other) => base.Equals(other);

    public override bool Equals(object? obj) => base.Equals(obj);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public override int GetHashCode() => base.GetHashCode();

    public static Result<IdPelatihan> Create(string value)
    {
        if (!Regex.IsMatch(value, ValidPattern))
            return new Error("IdPelatihan.TidakValid", "Id valid dimulai PC dan diikuti 3 angka. Contoh ME001");

        return new IdPelatihan(value);
    }

    public static async Task<IdPelatihan> Generate(IRepositoriPelatihan repositoriPelatihan)
    {
        var newId = (await repositoriPelatihan.GetAll())
            .Select(m => int.Parse(m.Id.Value.Substring(2)))
            .Order()
            .LastOrDefault() + 1;

        return new($"PC{newId:3}");
    }
}

public interface IRepositoriPelatihan
{
    Task<Pelatihan?> Get(IdPelatihan id);
    Task<List<Pelatihan>> GetAll();

    void Add(Pelatihan Pelatihan);
    void Update(Pelatihan Pelatihan);
    void Delete(Pelatihan Pelatihan);
}