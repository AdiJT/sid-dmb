using SidDmb.Domain.MasterDataFunction.ModulPreneur.UnitUsahas;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulPreneur.UnitUsahas;

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
	public KategoriUnitUsaha Kategori { get; set; }

    [Display(Name = "Alamat")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string Alamat { get; set; } = string.Empty;

    [Display(Name = "Titik Koordinat (Lat)")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public double Lat { get; set; }
	
	[Display(Name = "Titik Koordinat (Lng)")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public double Lng { get; set; }

    [Display(Name = "Pemilik Usaha")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string PemilikUsaha { get; set; } = string.Empty;

    [Display(Name = "Jumlah Karyawan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public int JumlahKaryawan { get; set; }

    [Display(Name = "Legalitas")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public LegalitasUsaha Legalitas { get; set; }

	[Display(Name = "Tanggal Berdiri")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public DateOnly TanggalBerdiri { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    [Display(Name = "Kontak Informasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string KontakInformasi { get; set; } = string.Empty;

    [Display(Name = "Media Promosi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public IFormFile MediaPromosi { get; set; }

}
