using NetTopologySuite.Geometries;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Enums;
using SidDmb.Domain.ValueObjects;

namespace SidDmb.Domain.Entities;

public class DestinasiWisata : Entity<IdDestinasi>, IAuditableEntity
{
    public string Nama { get; set; } = string.Empty;
    public string Deskripsi { get; set; } = string.Empty;
    public KategoriDestinasi Kategori { get; set; }
    public string Alamat { get; set; } = string.Empty;
    public Point TitikKoordinat { get; set; } = Point.Empty;
    public string[] DaftarFasilitas { get; set; } = [];
    public double HargaTiketMasuk { get; set; }
    public string JamOperasional { get; set; } = string.Empty;
    public string InformasiKontak { get; set; } = string.Empty;
    public string PengelolaDestinasi { get; set; } = string.Empty;
    public string[] DaftarAktivitas { get; set; } = [];
    public StatusOperasional StatusOperasional { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }
}
