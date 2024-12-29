using SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.ManajemenProduk;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulProdukDanInventory.ManajemenProduk;

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
	public KategoriProduk Kategori { get; set; }

    [Display(Name = "Unit Usaha Terkait")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string UnitUsahaTerkait { get; set; } = string.Empty;

    [Display(Name = "Harga Produk")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public double HargaProduk { get; set; }

    [Display(Name = "Stok Awal")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public int StokAwal { get; set; }

    [Display(Name = "Stok Saat Ini")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public int StokSaatIni { get; set; }

    [Display(Name = "Status Ketersediaan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public StatusKetersediaan StatusKetersediaan { get; set; }

    [Display(Name = "Tanggal Produksi Terakhir")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public DateOnly TanggalProduksiTerakhir { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    [Display(Name = "Tanggal Kadaluarsa")]
	public DateOnly? TanggalKadaluarsa { get; set; }

    [Display(Name = "Media Promosi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public IFormFile MediaPromosi { get; set; }

	[Display(Name = "Kolaborator")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public int[] DaftarKolaboratorId { get; set; } = [];
}