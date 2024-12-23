using SidDmb.Domain.Abstracts;
using SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.ManajemenProduk;

namespace SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.ManajemenDistribusi;

public class Distribusi : Entity<IdDistribusi>, IAuditableEntity
{
    public required int JumlahProduk { get; set; }
    public required DateOnly TanggalPengiriman { get; set; }
    public required string AlamatTujuan { get; set; }
    public required string NamaDistributor { get; set; }
    public required string KontakDistributor { get; set; }
    public required double BiayaPengiriman { get; set; }
    public required Uri DokumenPengiriman { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }

    public Produk Produk { get; set; }
    public List<Kolaborator> DaftarKolaborator { get; set; } = [];
}