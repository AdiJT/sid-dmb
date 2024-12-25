using NetTopologySuite.Geometries;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.MasterDataFunction.ModulWisata.DestinasiWisatas;

namespace SidDmb.Domain.MasterDataFunction.ModulBudaya.SitusBudayas;

public class SitusBudaya : Entity<IdSitus>, IAuditableEntity
{
    public required string Nama { get; set; }
    public required string Dekripsi { get; set; }
    public required KategoriSitus Kategori { get; set; }
    public required string Alamat { get; set; }
    public required Point KoordinatLokasi { get; set; }
    public required double HargaTiketMasuk { get; set; }
    public required string JamOperasional { get; set; }
    public required string KontakInformasi { get; set; }
    public required Uri FotoPromosi { get; set; }
    public required string PengelolaSitus { get; set; }
    public required StatusOperasional Status { get; set; }
    public required string PeraturanKhusus { get; set; }
    public required string[] DaftarFasilitas { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }

    public double Rating => DaftarKomentar.Count > 0 ? DaftarKomentar.Average(k => k.Rating) : 0;

    public List<Komentar> DaftarKomentar { get; set; } = [];
}