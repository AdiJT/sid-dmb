using SidDmb.Domain.Abstracts;
using SidDmb.Domain.MasterDataFunction.ModulPreneur.UnitUsahas;

namespace SidDmb.Domain.MasterDataFunction.ModulPreneur.ProdukLokals;

public class ProdukLokal : Entity<IdProduk>, IAuditableEntity
{
    public required string Nama { get; set; }
    public required string Dekripsi { get; set; }
    public required KategoriProduk Kategori { get; set; }
    public required double Harga { get; set; }
    public required string BahanUtama { get; set; }
    public required StatusKetersediaanProduk StatusKetersediaan { get; set; }
    public required DateTime TanggalProduksiTerakhir { get; set; }
    public required DateTime TanggalKadaluarsa { get; set; }
    public required string LegalitasDanSertifikat { get; set; }
    public required string KontakInformasi { get; set; }
    public required Uri MediaPromosi { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }

    public UnitUsaha UnitUsaha { get; set; }
}