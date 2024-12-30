using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulProdukDanInventory.ManajemenDistribusi;

public class TambahVM
{
    [Display(Name = "Jumlah Produk")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public int JumlahProduk { get; set; }

    [Display(Name = "Tanggal Pengiriman")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public DateOnly TanggalPengiriman { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    [Display(Name = "Alamat Tujuan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string AlamatTujuan { get; set; } = string.Empty;

    [Display(Name = "Nama Distributor")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string NamaDistributor { get; set; } = string.Empty;

    [Display(Name = "Kontak Distributor")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string KontakDistributor { get; set; } = string.Empty;

    [Display(Name = "Biaya Pengiriman")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public double BiayaPengiriman { get; set; }

    [Display(Name = "Dokumen Pengiriman")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public IFormFile DokumenPengiriman { get; set; }

	[Display(Name = "Produk")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string ProdukId { get; set; } = string.Empty;

    [Display(Name = "Kolaborator")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public int[] DaftarKolaboratorId { get; set; } = [];
}