using SidDmb.Domain.Abstracts;

namespace SidDmb.Domain.MasterDataFunction.ModulBudaya.ArtefakBudayas;

public class ArtefakBudaya : Entity<IdArtefak>, IAuditableEntity
{
    public required string Nama { get; set; }
    public required string Dekripsi { get; set; }
    public required KategoriArtefak Kategori { get; set; }
    public required string LokasiPenyimpanan { get; set; }
    public required KondisiArtefak Kondisi { get; set; }
    public required string Usia { get; set; }
    public required string Bahan { get; set; }
    public required string Dimensi { get; set; }
    public required string Pengelola { get; set; }
    public required string NilaiHistoris { get; set; }
    public required Uri Foto { get; set; }
    public required KetersediaanPameran Ketersediaan { get; set; }
    public required double RatingPengunjung { get; set; }
    public required string KomentarPengunjung { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }
}