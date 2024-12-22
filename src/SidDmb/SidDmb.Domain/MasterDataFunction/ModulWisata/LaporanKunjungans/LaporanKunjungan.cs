using SidDmb.Domain.Abstracts;
using SidDmb.Domain.MasterDataFunction.ModulWisata.DestinasiWisatas;

namespace SidDmb.Domain.MasterDataFunction.ModulWisata.LaporanKunjungans;

public class LaporanKunjungan : Entity<IdKunjungan>, IAuditableEntity
{
    public required DateTime TanggalKunjungan { get; set; }
    public required int JumlahWisatawanDomestik { get; set; }
    public required int JumlahWisatawanInternasional { get; set; }
    public required TimeSpan DurasiKunjungan { get; set; }
    public required int TiketTerjual { get; set; }
    public required double RatingPengunjung { get; set; }
    public required string KomentarPengunjung { get; set; }

    public double PendapatanTiket => TiketTerjual * DestinasiWisata.HargaTiketMasuk;

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }

    public DestinasiWisata DestinasiWisata { get; set; }
}