using SidDmb.Domain.CollaborationFunction.ModulResearchAndDevelopment.RekomendasiDanPengembanganProduk;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulResearchAndDevelopment.RekomendasiDanPengembanganProduk;

public class TambahVM
{
    [Display(Name = "Judul")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string Judul { get; set; } = string.Empty;

    [Display(Name = "Dekripsi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string Dekripsi { get; set; } = string.Empty;

    [Display(Name = "Tujuan Pengembangan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string TujuanPengembangan { get; set; } = string.Empty;

    [Display(Name = "Pemberi Rekomendasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string PemberiRekomendasi { get; set; } = string.Empty;

    [Display(Name = "Kategori Pengembangan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public KategoriPengembangan KategoriPengembangan { get; set; }

    [Display(Name = "Strategi Yang Direkomendasikan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string StrategiYangDirekomendasikan { get; set; } = string.Empty;

    [Display(Name = "Timeline Rekomendasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string TimelineRekomendasi { get; set; } = string.Empty;

    [Display(Name = "Anggaran")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public double Anggaran { get; set; }

    [Display(Name = "Hasil Yang Diharapkan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string HasilYangDiharapkan { get; set; } = string.Empty;

    [Display(Name = "Status Implementasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public StatusImplementasi StatusImplementasi { get; set; }

    [Display(Name = "Dokumen Pendukung")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public IFormFile DokumenPendukung { get; set; }

    [Display(Name = "Produk Terkait")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string ProdukId { get; set; } = string.Empty;

    [Display(Name = "Kolaborator")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public int[] DaftarKolaboratorId { get; set; } = [];

}