using SidDmb.Domain.Abstracts;
using SidDmb.Domain.MasterDataFunction.ModulPrima.KelompokPrimas;

namespace SidDmb.Domain.MasterDataFunction.ModulPrima.KegiatanPrimas;

public class KegiatanPrima : Entity<IdKegiatanPrima>, IAuditableEntity
{
    public required string Nama { get; set; }
    public required string Dekripsi { get; set; }
    public required DateOnly TanggalPelaksanaan { get; set; }
    public required TimeSpan Durasi { get; set; }
    public required string Lokasi { get; set; }
    public required JenisKegiatan Jenis { get; set; }
    public required int JumlahPeserta { get; set; }
    public required string Fasilitator { get; set; }
    public required double AnggaranKegiatan { get; set; }
    public required string HasilKegiatan { get; set; }
    public required Uri DokumentasiKegiatan { get; set; }
    public required string FeedbackPeserta { get; set; }
    public required string RekomendasiUntukKegiatanBerikutnya { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }

    public KelompokPrima KelompokPrima { get; set; }
    public List<KolaboratorKegiatanPrima> KolaboratorKegiatan { get; set; } = [];
}