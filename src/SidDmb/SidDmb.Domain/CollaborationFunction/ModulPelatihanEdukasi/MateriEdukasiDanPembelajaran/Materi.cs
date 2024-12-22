using SidDmb.Domain.Abstracts;

namespace SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi.MateriEdukasiDanPembelajaran;

public class Materi : Entity<IdMateri>, IAuditableEntity
{
    public required string JudulMateri { get; set; }
    public required string DekripsiMateri { get; set; }
    public required KategoriMateri KategoriMateri { get; set; }
    public required string PenyediaMateri { get; set; }
    public required TargetAudiens TargetAudiens { get; set; }
    public required TipeMateri TipeMateri { get; set; }
    public required Uri LinkUnduhan { get; set; }
    public required DateOnly TanggalRilis { get; set; }
    public required string FeedBackAudiens { get; set; }
    public required Uri DokumenPendukung { get; set; }
    public required int JumlahPengguna { get; set; }
    public required StatusMateri StatusMateri { get; set; }
    public required string RekomendasiPembaruanMateri { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }

    public List<KolabolatorMateri> DaftarKolaborator { get; set; } = [];
}