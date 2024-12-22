using NetTopologySuite.Geometries;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Shared;
using System.Text.RegularExpressions;

namespace SidDmb.Domain.ModulPreneur;

public class UnitUsaha : Entity<IdUnitUsaha>, IAuditableEntity
{
    public required string Nama { get; set; }
    public required string Dekripsi { get; set; }
    public required KategoriUnitUsaha Kategori { get; set; }
    public required string Alamat { get; set; }
    public required Point TitikKoordinat { get; set; }
    public required string PemilikUsaha { get; set; }
    public required int JumlahKaryawan { get; set; }
    public required string[] DaftarProdukJasa { get; set; }
    public required LegalitasUsaha Legalitas { get; set; }
    public required DateOnly TanggalBerdiri { get; set; }
    public required string KontakInformasi { get; set; }
    public required Uri MediaPromosi { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }
}

public enum KategoriUnitUsaha 
{
    Produksi, Jasa, Distribusi, Lainnya
}

public enum LegalitasUsaha
{
    MemilikiIzin, DalamProsen, TidakAda
}

public class IdUnitUsaha : ValueObject, IEquatable<IdUnitUsaha>
{
    public const string ValidPattern = "^UU[0-9]{3}$";

    public string Value { get; set; }

    private IdUnitUsaha(string value)
    {
        Value = value;
    }

    public bool Equals(IdUnitUsaha? other) => base.Equals(other);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public override bool Equals(object? obj) => base.Equals(obj);

    public override int GetHashCode() => base.GetHashCode();

    public static Result<IdUnitUsaha> Create(string value)
    {
        if (!Regex.IsMatch(value, ValidPattern))
            return new Error("IdUnitUsaha.TidakValid", "Id valid dimulai oleh UU diikuti 3 angka. Contoh UU001");

        return new IdUnitUsaha(value);
    }

    public static async Task<IdUnitUsaha> Generate(IRepositoriUnitUsaha repositoriUnitUsaha)
    {
        var newId = (await repositoriUnitUsaha.GetAll())
            .Select(u => int.Parse(u.Id.Value.Substring(2)))
            .Order()
            .LastOrDefault() + 1;

        return new($"UU{newId:D3}");
    }
}

public interface IRepositoriUnitUsaha
{
    Task<UnitUsaha?> Get(IdUnitUsaha id);
    Task<List<UnitUsaha>> GetAll();

    void Add(UnitUsaha unitUsaha);
    void Update(UnitUsaha unitUsaha);
    void Delete(UnitUsaha unitUsaha);
}