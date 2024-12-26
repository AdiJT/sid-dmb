using SidDmb.Domain.MasterDataFunction.ModulBudaya.SeniBudayas;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulBudaya.SeniBudayas;

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
	public KategoriSeni Kategori { get; set; }

    [Display(Name = "Nama Pelaku Seni")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string NamaPelakuSeni { get; set; } = string.Empty;

    [Display(Name = "Lokasi Pertunjukan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string LokasiPertunjukan { get; set; } = string.Empty;

    [Display(Name = "Waktu Pertunjukan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string WaktuPertunjukan { get; set; } = string.Empty;

    [Display(Name = "Durasi Pentunjukan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	[DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
	public TimeSpan DurasiPentunjukan { get; set; }

    [Display(Name = "Harga Tiket")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public double HargaTiket { get; set; }

    [Display(Name = "Peraturan Khusus")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string PeraturanKhusus { get; set; } = string.Empty;

    [Display(Name = "Media Promosi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public IFormFile MediaPromosi { get; set; }

	[Display(Name = "Fasilitas Pertunjukan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string[] FasilitasPertunjukan { get; set; } = [];

}