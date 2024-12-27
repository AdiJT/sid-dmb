using SidDmb.Domain.MasterDataFunction.ModulPrima.KegiatanPrimas;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulPrima.KegiatanPrimas;

public class EditVM
{
    [Display(Name = "Id")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Id { get; set; }

    [Display(Name = "Nama")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string Nama { get; set; }

    [Display(Name = "Dekripsi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string Dekripsi { get; set; }

	[Display(Name = "Tanggal Pelaksanaan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required DateOnly TanggalPelaksanaan { get; set; }

    [Display(Name = "Durasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
    [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
    public required TimeSpan Durasi { get; set; }

    [Display(Name = "Lokasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string Lokasi { get; set; }

    [Display(Name = "Jenis")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required JenisKegiatan Jenis { get; set; }

    [Display(Name = "Jumlah Peserta")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required int JumlahPeserta { get; set; }

    [Display(Name = "Fasilitator")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string Fasilitator { get; set; }

    [Display(Name = "Anggaran Kegiatan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required double AnggaranKegiatan { get; set; }

    [Display(Name = "Hasil Kegiatan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string HasilKegiatan { get; set; }

    [Display(Name = "Dokumentasi Kegiatan Baru")]
	public IFormFile? DokumentasiKegiatanBaru { get; set; }

    [Display(Name = "Feedback Peserta")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string FeedbackPeserta { get; set; }

    [Display(Name = "Kolaborator Kegiatan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int[] DaftarKolaboratorId { get; set; }

    [Display(Name = "Kelompok Prima")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string KelompokPrimaId { get; set; }
}
