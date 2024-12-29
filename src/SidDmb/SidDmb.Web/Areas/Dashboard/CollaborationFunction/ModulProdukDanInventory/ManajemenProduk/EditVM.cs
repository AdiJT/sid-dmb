using SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.ManajemenProduk;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulProdukDanInventory.ManajemenProduk;

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

    [Display(Name = "Kategori")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required KategoriProduk Kategori { get; set; }

    [Display(Name = "Unit Usaha Terkait")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string UnitUsahaTerkait { get; set; }

    [Display(Name = "Harga Produk")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required double HargaProduk { get; set; }

    [Display(Name = "Stok Awal")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required int StokAwal { get; set; }

    [Display(Name = "Stok Saat Ini")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required int StokSaatIni { get; set; }

    [Display(Name = "Status Ketersediaan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required StatusKetersediaan StatusKetersediaan { get; set; }

    [Display(Name = "Tanggal Produksi Terakhir")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required DateOnly TanggalProduksiTerakhir { get; set; }

    [Display(Name = "Tanggal Kadaluarsa")]
	public DateOnly? TanggalKadaluarsa { get; set; }

    [Display(Name = "Media Promosi")]
	public IFormFile? MediaPromosi { get; set; }

	[Display(Name = "Kolaborator")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required int[] DaftarKolaboratorId { get; set; }
}