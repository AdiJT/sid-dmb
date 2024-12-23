using NetTopologySuite.Geometries;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.MasterDataFunction.ModulPreneur.ProdukLokals;

namespace SidDmb.Domain.MasterDataFunction.ModulPreneur.UnitUsahas;

public class UnitUsaha : Entity<IdUnitUsaha>, IAuditableEntity
{
    public required string Nama { get; set; }
    public required string Dekripsi { get; set; }
    public required KategoriUnitUsaha Kategori { get; set; }
    public required string Alamat { get; set; }
    public required Point TitikKoordinat { get; set; }
    public required string PemilikUsaha { get; set; }
    public required int JumlahKaryawan { get; set; }
    public required LegalitasUsaha Legalitas { get; set; }
    public required DateOnly TanggalBerdiri { get; set; }
    public required string KontakInformasi { get; set; }
    public required Uri MediaPromosi { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }

    public List<ProdukLokal> DaftarProduk { get; set; } = [];
}