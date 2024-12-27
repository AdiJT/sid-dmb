using SidDmb.Domain.Abstracts;
using SidDmb.Domain.CollaborationFunction.ModulManajemenEvent.PelaporanDanDokumentasi;

namespace SidDmb.Domain.CollaborationFunction.ModulManajemenEvent.PengelolaanEvent;

public class Event : Entity<IdEvent>, IAuditableEntity
{
    public required string Nama { get; set; }
    public required string Dekripsi { get; set; }
    public required DateTime TanggalWaktu { get; set; }
    public required string Lokasi { get; set; }
    public required string Penyelenggara { get; set; }
    public required string KontakInformasi { get; set; }
    public required TargetPeserta TargetPeserta { get; set; }
    public required int JumlahPesertaMaksimal { get; set; }
    public required StatusPendaftaran StatusPendaftaran { get; set; }
    public required string Sponsor { get; set; }
    public required double Anggaran { get; set; }
    public required Uri MediaPromosi { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }

    public List<Kolaborator> DaftarKolaborator { get; set; } = [];
    public List<KolaboratorEvent> DaftarKolaboratorEvent { get; set; } = [];
    public LaporanEvent? LaporanEvent { get; set; }
}