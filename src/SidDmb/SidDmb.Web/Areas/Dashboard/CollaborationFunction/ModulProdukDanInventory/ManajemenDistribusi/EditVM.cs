using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulProdukDanInventory.ManajemenDistribusi;

public class EditVM
{
    [Display(Name = "Id")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Id { get; set; }

    [Display(Name = "Jumlah Produk")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required int JumlahProduk { get; set; }

    [Display(Name = "Tanggal Pengiriman")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required DateOnly TanggalPengiriman { get; set; }

    [Display(Name = "Alamat Tujuan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string AlamatTujuan { get; set; }

    [Display(Name = "Nama Distributor")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string NamaDistributor { get; set; }

    [Display(Name = "Kontak Distributor")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string KontakDistributor { get; set; }

    [Display(Name = "Biaya Pengiriman")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required double BiayaPengiriman { get; set; }

    [Display(Name = "Dokumen Pengiriman")]
	public IFormFile? DokumenPengiriman { get; set; }

	[Display(Name = "Produk")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string ProdukId { get; set; }

    [Display(Name = "Kolaborator")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int[] DaftarKolaboratorId { get; set; }
}