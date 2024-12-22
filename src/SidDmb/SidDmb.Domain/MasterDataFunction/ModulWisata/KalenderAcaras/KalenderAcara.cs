using SidDmb.Domain.Abstracts;

namespace SidDmb.Domain.MasterDataFunction.ModulWisata.KalenderAcaras;

public class KalenderAcara : Entity<IdAcara>, IAuditableEntity
{
    public required string NamaAcara { get; set; }
    public required string DekripsiAcara { get; set; }
    public required KategoriAcara Kategori { get; set; }
    public required DateTime TanggalDanWaktu { get; set; }
    public required string LokasiAcara { get; set; }
    public required string PenanggungJawab { get; set; }
    public required string KontakInformasi { get; set; }
    public required double HargaTiketAcara { get; set; }
    public required TargetPesertaAcara TargetPesertaAcara { get; set; }
    public required int BatasKuotaPeserta { get; set; }
    public required StatusPendaftaran StatusPendaftaran { get; set; }
    public required Uri MediaPromosi { get; set; }
    public required string SponsorAcara { get; set; }
    public required Uri TautanPendaftaran { get; set; }
    public required double RatingAcara { get; set; }

    public required DateTime TanggalDiinputkan { get; set; }
    public required DateTime TanggalPembaruanData { get; set; }
}