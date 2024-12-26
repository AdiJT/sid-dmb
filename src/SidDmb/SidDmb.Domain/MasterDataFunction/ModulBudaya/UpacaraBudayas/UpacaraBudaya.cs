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
    public required int JumlahPeserta { get; set; }
    public required Uri MediaPromosi { get; set; }
    public required string PeraturanKhusus { get; set; }
    public required string[] FasilitasPendukung { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }

    public double Rating => DaftarKomentar.Count > 0 ? DaftarKomentar.Average(k => k.Rating) : 0;

    public List<Komentar> DaftarKomentar { get; set; } = [];
}