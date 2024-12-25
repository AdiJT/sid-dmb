using NetTopologySuite.Geometries;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.MasterDataFunction.ModulWisata.LaporanKunjungans;

namespace SidDmb.Domain.MasterDataFunction.ModulWisata.DestinasiWisatas;

public class DestinasiWisata : Entity<IdDestinasi>, IAuditableEntity
{
    public required string Nama { get; set; }
    public required string Deskripsi { get; set; }
    public required KategoriDestinasi Kategori { get; set; }
    public required string Alamat { get; set; }
    public required Point TitikKoordinat { get; set; }
    public required double HargaTiketMasuk { get; set; }
    public required string JamOperasional { get; set; }
    public required string InformasiKontak { get; set; }
    public required string PengelolaDestinasi { get; set; }
    public required StatusOperasional StatusOperasional { get; set; }
    public required Uri Foto { get; set; }
    public required string[] DaftarFasilitas { get; set; }
    public required string[] DaftarAktivitas { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }

    public List<LaporanKunjungan> DaftarLaporanKunjungan { get; set; } = [];
}