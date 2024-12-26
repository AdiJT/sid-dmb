using SidDmb.Domain.MasterDataFunction.ModulBudaya.UpacaraBudayas;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulBudaya.UpacaraBudayas;

public class TambahVM
{
    [Display(Name = "Nama")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string Nama { get; set; } = string.Empty;

    [Display(Name = "Dekripsi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string Dekripsi { get; set; } = string.Empty;

    [Display(Name = "Kategori")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public KategoriUpacara Kategori { get; set; }

    [Display(Name = "Lokasi Pelaksanaan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string LokasiPelaksanaan { get; set; } = string.Empty;

    [Display(Name = "Waktu Pelaksanaan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public DateTime WaktuPelaksanaan { get; set; }

    [Display(Name = "Durasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
    [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
    public TimeSpan Durasi { get; set; }

    [Display(Name = "Pihak Terlibat")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string PihakTerlibat { get; set; } = string.Empty;

    [Display(Name = "Rangkaian Acara")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string RangkaianAcara { get; set; } = string.Empty;

    [Display(Name = "Jumlah Peserta")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public int JumlahPeserta { get; set; }

    [Display(Name = "Media Promosi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public IFormFile MediaPromosi { get; set; }

    [Display(Name = "Peraturan Khusus")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string PeraturanKhusus { get; set; } = string.Empty;

	[Display(Name = "Fasilitas Pendukung")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string[] FasilitasPendukung { get; set; } = [];

}