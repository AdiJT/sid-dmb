using SidDmb.Domain.Abstracts;
using SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.ManajemenProduk;

namespace SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.SertifikasiDanLegalitas;

public class Sertifikasi : Entity<IdSertifikasi>, IAuditableEntity
{
    public required JenisSertifikasi JenisSertifikasi { get; set; }
    public required string NomorSertifikasi { get; set; }
    public required DateOnly TanggalPenerbitan { get; set; }
    public required DateOnly TanggalKadaluarsa { get; set; }
    public required string PemberiSertifikat { get; set; }
    public required Uri DokumenSertifikat { get; set; }
    public required string ProsesYangDilalui { get; set; }
    public required StatusSertifikasi StatusSertifikasi { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }

    public Produk Produk { get; set; }
    public List<Kolaborator> DaftarKolaborator { get; set; } = [];
    public List<KolaboratorSertifikasi> DaftarKolaboratorSertifikasi { get; set; } = [];
}