using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Shared;
using System.Text.RegularExpressions;

namespace SidDmb.Domain.ModulPreneur;

public class ProdukLokal : Entity<IdProduk>, IAuditableEntity
{
    public required string Nama { get; set; }
    public required string Dekripsi { get; set; }
    public required KategoriProduk Kategori { get; set; }
    public required double Harga { get; set; }
    public required string UnitUsahaTerkait { get; set; }
    public required string BahanUtama { get; set; }
    public required StatusKetersediaanProduk StatusKetersediaan { get; set; }
    public required DateTime TanggalProduksiTerakhir { get; set; }
    public required DateTime TanggalKadaluarsa { get; set; }
    public required string LegalitasDanSertifikat { get; set; }
    public required string KontakInformasi { get; set; }
    public required Uri MediaPromosi { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }
}

public enum KategoriProduk
{
    Kerajinan, Makanan, Minuman, Lainnya
}

public enum StatusKetersediaanProduk
{
    Tersedia, DalamProduksi, Habis
}

public class IdProduk : ValueObject, IEquatable<IdProduk>
{
    public const string ValidPattern = "^PL[0-9]{3}$";

    public string Value { get; set; }

    private IdProduk(string value)
    {
        Value = value;
    }

    public bool Equals(IdProduk? other) => base.Equals(other);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public override bool Equals(object? obj) => base.Equals(obj);

    public override int GetHashCode() => base.GetHashCode();

    public static Result<IdProduk> Create(string value)
    {
        if (!Regex.IsMatch(value, ValidPattern))
            return new Error("IdProduk.TidakValid", "Id valid dimulai oleh PL diikuti 3 angka. Contoh PL001");

        return new IdProduk(value);
    }

    public static async Task<IdProduk> Generate(IRepositoriProdukLokal repositoriProdukLokal)
    {
        var newId = (await repositoriProdukLokal.GetAll())
            .Select(p => int.Parse(p.Id.Value.Substring(2)))
            .Order()
            .LastOrDefault() + 1;

        return new($"PL{newId:D3}");
    }
}

public interface IRepositoriProdukLokal
{
    Task<ProdukLokal?> Get(IdProduk id);
    Task<List<ProdukLokal>> GetAll();

    void Add(ProdukLokal produkLokal);
    void Update(ProdukLokal produkLokal);
    void Delete(ProdukLokal produkLokal);
}