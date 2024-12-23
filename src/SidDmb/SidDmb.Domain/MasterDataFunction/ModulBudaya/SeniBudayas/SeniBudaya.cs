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
    public required double RatingPenonton { get; set; }
    public required string KomentarPenonton { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }

    public List<Fasilitas> FasilitasPertunjukan { get; set; } = [];
}