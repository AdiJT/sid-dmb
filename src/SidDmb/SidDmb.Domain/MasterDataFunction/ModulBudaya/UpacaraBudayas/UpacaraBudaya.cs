using SidDmb.Domain.Abstracts;

namespace SidDmb.Domain.MasterDataFunction.ModulBudaya.UpacaraBudayas;

public class UpacaraBudaya : Entity<IdUpacara>, IAuditableEntity
{
    public required string Nama { get; set; }
    public required string Dekripsi { get; set; }
    public required KategoriUpacara Kategori { get; set; }
    public required string LokasiPelaksanaan { get; set; }
    public required DateTime WaktuPelaksanaan { get; set; }
    public required TimeSpan Durasi { get; set; }
    public required string PihakTerlibat { get; set; }
    public required string RangkaianAcara { get; set; }
    public required int JumlahUpacara { get; set; }
    public required Uri MediaPromosi { get; set; }
    public required double RatingPeserta { get; set; }
    public required string KomentarPeserta { get; set; }
    public required string PeraturanKhusus { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }

    public List<FasilitasUpacaraBudaya> FasilitasPendukung { get; set; } = [];
}