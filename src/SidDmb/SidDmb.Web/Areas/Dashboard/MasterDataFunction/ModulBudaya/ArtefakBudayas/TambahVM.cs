using SidDmb.Domain.MasterDataFunction.ModulBudaya.ArtefakBudayas;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulBudaya.ArtefakBudayas;

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
	public KategoriArtefak Kategori { get; set; }

    [Display(Name = "Lokasi Penyimpanan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string LokasiPenyimpanan { get; set; } = string.Empty;

    [Display(Name = "Kondisi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public KondisiArtefak Kondisi { get; set; }

    [Display(Name = "Usia")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string Usia { get; set; } = string.Empty;

    [Display(Name = "Bahan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string Bahan { get; set; } = string.Empty;

    [Display(Name = "Dimensi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string Dimensi { get; set; } = string.Empty;

    [Display(Name = "Pengelola")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string Pengelola { get; set; } = string.Empty;

    [Display(Name = "Nilai Historis")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string NilaiHistoris { get; set; } = string.Empty;

    [Display(Name = "Foto")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public IFormFile Foto { get; set; }

    [Display(Name = "Ketersediaan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public KetersediaanPameran Ketersediaan { get; set; }
}