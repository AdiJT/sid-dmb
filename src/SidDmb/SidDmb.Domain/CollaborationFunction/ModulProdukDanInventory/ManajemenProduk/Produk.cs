using SidDmb.Domain.Abstracts;
using SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.ManajemenDistribusi;
using SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.SertifikasiDanLegalitas;

namespace SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.ManajemenProduk;

public class Produk : Entity<IdProduk>, IAuditableEntity
{
    public required string Nama { get; set; }
    public required string Dekripsi { get; set; }
    public required KategoriProduk Kategori { get; set; }
    public required string UnitUsahaTerkait { get; set; }
    public required double HargaProduk { get; set; }
    public required int StokAwal { get; set; }
    public required int StokSaatIni { get; set; }
    public required StatusKetersediaan StatusKetersediaan { get; set; }
    public required DateOnly TanggalProduksiTerakhir { get; set; }
    public DateOnly? TanggalKadaluarsa { get; set; }
    public required Uri MediaPromosi { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }

    public string LegalitasProduk => string.Join(", ", DaftarSertifikasi.Select(x => x.NomorSertifikasi));

    public List<Kolaborator> DaftarKolaborator { get; set; } = [];
    public List<Distribusi> DaftarDistribusi { get; set; } = [];
    public List<Sertifikasi> DaftarSertifikasi { get; set; } = [];
}