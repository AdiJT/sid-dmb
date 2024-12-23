using SidDmb.Domain.Abstracts;
using SidDmb.Domain.CollaborationFunction.ModulManajemenEvent.PengelolaanEvent;
using SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi.MateriEdukasiDanPembelajaran;
using SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi.PeningkatanKapasitas;
using SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.ManajemenDistribusi;
using SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.ManajemenProduk;
using SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.SertifikasiDanLegalitas;
using SidDmb.Domain.CollaborationFunction.ModulResearchAndDevelopment.ManajemenDataRiset;
using SidDmb.Domain.CollaborationFunction.ModulResearchAndDevelopment.RekomendasiDanPengembanganProduk;

namespace SidDmb.Domain.CollaborationFunction;

public class Kolaborator : Entity<int>
{
    public required string Nama { get; set; }

    public List<Event> DaftarEvent { get; set; } = [];
    public List<Materi> DaftarMateri { get; set; } = [];
    public List<Pelatihan> DaftarPelatihan { get; set; } = [];
    public List<Distribusi> DaftarDistribusi { get; set; } = [];
    public List<Produk> DaftarProduk { get; set; } = [];
    public List<Sertifikasi> DaftarSertifikasi { get; set; } = [];
    public List<DataRiset> DaftarDataRiset { get; set; } = [];
    public List<Rekomendasi> DaftarRekomendasi { get; set; } = [];
}