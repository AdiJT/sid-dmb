using SidDmb.Domain.Abstracts;

namespace SidDmb.Domain.MasterDataFunction.ModulBudaya.SeniBudayas;

public class SeniBudaya : Entity<IdSeni>, IAuditableEntity
{
    public required string Nama { get; set; }
    public required string Dekripsi { get; set; }
    public required KategoriSeni Kategori { get; set; }
    public required string NamaPelakuSeni { get; set; }
    public required string LokasiPertunjukan { get; set; }
    public required string WaktuPertunjukan { get; set; }
    public required TimeSpan DurasiPentunjukan { get; set; }
    public required double HargaTiket { get; set; }
    public required string PeraturanKhusus { get; set; }
    public required Uri MediaPromosi { get; set; }
    public required string[] FasilitasPertunjukan { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }

    public double Rating => DaftarKomentar.Count > 0 ? DaftarKomentar.Average(k => k.Rating) : 0;

    public List<Komentar> DaftarKomentar { get; set; } = [];
}