using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Shared;
using System.Text.RegularExpressions;

namespace SidDmb.Domain.MasterDataFunction.ModulPrima;

public class KelompokPrima : Entity<IdKelompok>, IAuditableEntity
{
    public required string Nama { get; set; }
    public required string Dekripsi { get; set; }
    public required int JumlahAnggota { get; set; }
    public required string KetuaKelompok { get; set; }
    public required int TahunBerdiri { get; set; }
    public required FokusKegiatanKelompokPrima FokusKegiatan { get; set; }
    public required string ProgramUnggulan { get; set; }
    public required string Alamat { get; set; }
    public required string KontakInformasi { get; set; }
    public required Uri MediaPromosi { get; set; }
    public required int JumlahProgramDilaksanakan { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }

    public List<KelompokPrima> DaftarKelompokPrima { get; set; } = [];
}

public enum FokusKegiatanKelompokPrima
{
    Kerajinan, Pendidikan, Kuliner
}

public class IdKelompok : ValueObject, IEquatable<IdKelompok>
{
    public const string ValidPattern = "^KP[0-9]{3}$";

    public string Value { get; set; }

    private IdKelompok(string value)
    {
        Value = value;
    }

    public bool Equals(IdKelompok? other) => base.Equals(other);

    public override bool Equals(object? obj) => base.Equals(obj);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public override int GetHashCode() => base.GetHashCode();

    public static Result<IdKelompok> Create(string value)
    {
        if (!Regex.IsMatch(value, ValidPattern))
            return new Error("IdKelompok.TidakValid", "Id valid dimulai KP dan diikuti 3 angka. Contoh KP001");

        return new IdKelompok(value);
    }

    public static async Task<IdKelompok> Generate(IRepositoriKelompokPrima repositoriKelompokPrima)
    {
        var newId = (await repositoriKelompokPrima.GetAll())
            .Select(k => int.Parse(k.Id.Value.Substring(2)))
            .Order()
            .LastOrDefault() + 1;

        return new($"KP{newId:D3}");
    }
}

public interface IRepositoriKelompokPrima
{
    Task<KelompokPrima?> Get(IdKelompok id);
    Task<List<KelompokPrima>> GetAll();

    void Add(KelompokPrima kelompokPrima);
    void Update(KelompokPrima kelompokPrima);
    void Delete(KelompokPrima kelompokPrima);
}