using SidDmb.Domain.MasterDataFunction.ModulPreneur.ProdukLokals;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulPreneur.ProdukLokals;

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

    [Display(Name = "Harga")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public double Harga { get; set; }

    [Display(Name = "Bahan Utama")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string BahanUtama { get; set; } = string.Empty;

    [Display(Name = "Status Ketersediaan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public StatusKetersediaanProduk StatusKetersediaan { get; set; }

    [Display(Name = "Tanggal Produksi Terakhir")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public DateTime TanggalProduksiTerakhir { get; set; } = DateTime.Now;

    [Display(Name = "Tanggal Kadaluarsa")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public DateTime TanggalKadaluarsa { get; set; } = DateTime.Now;

    [Display(Name = "Legalitas Dan Sertifikat")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string LegalitasDanSertifikat { get; set; } = string.Empty;

    [Display(Name = "Kontak Informasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string KontakInformasi { get; set; } = string.Empty;

    [Display(Name = "Media Promosi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public IFormFile MediaPromosi { get; set; }

	[Display(Name = "Unit Usaha")]
	[Required(ErrorMessage = "{0} harus dipilih")]
	public string UnitUsahaId { get; set; } = string.Empty;
}