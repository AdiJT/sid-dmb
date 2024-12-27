using SidDmb.Domain.MasterDataFunction.ModulPrima.KegiatanPrimas;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulPrima.KegiatanPrimas;

public class TambahVM
{
    [Display(Name = "Nama")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string Nama { get; set; } = string.Empty;

    [Display(Name = "Dekripsi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string Dekripsi { get; set; } = string.Empty;

	[Display(Name = "Tanggal Pelaksanaan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public DateOnly TanggalPelaksanaan { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    [Display(Name = "Durasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
    [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
    public TimeSpan Durasi { get; set; }

    [Display(Name = "Lokasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string Lokasi { get; set; } = string.Empty;

    [Display(Name = "Jenis")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public JenisKegiatan Jenis { get; set; }

    [Display(Name = "Jumlah Peserta")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public int JumlahPeserta { get; set; }

    [Display(Name = "Fasilitator")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string Fasilitator { get; set; } = string.Empty;

    [Display(Name = "Anggaran Kegiatan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public double AnggaranKegiatan { get; set; }

    [Display(Name = "Hasil Kegiatan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string HasilKegiatan { get; set; } = string.Empty;

    [Display(Name = "Dokumentasi Kegiatan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public IFormFile DokumentasiKegiatan { get; set; }

    [Display(Name = "Feedback Peserta")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string FeedbackPeserta { get; set; } = string.Empty;

	[Display(Name = "Kolaborator Kegiatan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public int[] DaftarKolaboratorId { get; set; } = [];

    [Display(Name = "Kelompok Prima")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string KelompokPrimaId { get; set; } = string.Empty;
}
