using SidDmb.Domain.Abstracts;
using SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.ManajemenProduk;

namespace SidDmb.Domain.CollaborationFunction.ModulResearchAndDevelopment.RekomendasiDanPengembanganProduk;

public class Rekomendasi : Entity<IdRekomendasi>, IAuditableEntity
{
    public required string Judul { get; set; }
    public required string Dekripsi { get; set; }
    public required string TujuanPengembangan { get; set; }
    public required string PemberiRekomendasi { get; set; }
    public required KategoriPengembangan KategoriPengembangan { get; set; }
    public required string StrategiYangDirekomendasikan { get; set; }
    public required string TimelineRekomendasi { get; set; }
    public required double Anggaran { get; set; }
    public required string HasilYangDiharapkan { get; set; }
    public required StatusImplementasi StatusImplementasi { get; set; }
    public required Uri DokumenPendukung { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }

    public Produk ProdukTerkait { get; set; }
    public List<Kolaborator> DaftarKolaborator { get; set; } = [];
    public List<KolaboratorRekomendasi> DaftarKolaboratorRekomendasi { get; set; } = [];
}