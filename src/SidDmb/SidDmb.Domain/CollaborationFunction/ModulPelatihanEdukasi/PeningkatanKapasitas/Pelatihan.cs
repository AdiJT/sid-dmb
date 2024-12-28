using SidDmb.Domain.Abstracts;

namespace SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi.PeningkatanKapasitas;

public class Pelatihan : Entity<IdPelatihan>, IAuditableEntity
{
    public required string Nama { get; set; }
    public required string Dekripsi { get; set; }
    public required KategoriPelatihan Kategori { get; set; }
    public required string Penyelenggara { get; set; }
    public required DateOnly TanggalPelaksanaan { get; set; }
    public required TimeSpan Durasi { get; set; }
    public required string Lokasi { get; set; }
    public required TargetPeserta TargetPeserta { get; set; }
    public required int JumlahPeserta { get; set; }
    public required string Fasilitator { get; set; }
    public required string Materi { get; set; }
    public required string EvaluasiPeserta { get; set; }
    public required Uri DokumenDanMedia { get; set; }
    public required string FeedbackPeserta { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }
    public List<Kolaborator> DaftarKolaborator { get; set; } = [];
    public List<KolaboratorPelatihan> DaftarKolaboratorPelatihan { get; set; } = [];
}