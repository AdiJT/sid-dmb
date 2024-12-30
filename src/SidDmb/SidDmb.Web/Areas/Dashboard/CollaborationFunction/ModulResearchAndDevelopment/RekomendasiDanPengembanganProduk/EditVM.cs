using SidDmb.Domain.CollaborationFunction.ModulResearchAndDevelopment.RekomendasiDanPengembanganProduk;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulResearchAndDevelopment.RekomendasiDanPengembanganProduk;

public class EditVM
{
    [Display(Name = "Id")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Id { get; set; }

    [Display(Name = "Judul")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string Judul { get; set; }

    [Display(Name = "Dekripsi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string Dekripsi { get; set; }

    [Display(Name = "Tujuan Pengembangan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string TujuanPengembangan { get; set; }

    [Display(Name = "Pemberi Rekomendasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string PemberiRekomendasi { get; set; }

    [Display(Name = "Kategori Pengembangan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required KategoriPengembangan KategoriPengembangan { get; set; }

    [Display(Name = "Strategi Yang Direkomendasikan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string StrategiYangDirekomendasikan { get; set; }

    [Display(Name = "Timeline Rekomendasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string TimelineRekomendasi { get; set; }

    [Display(Name = "Anggaran")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required double Anggaran { get; set; }

    [Display(Name = "Hasil Yang Diharapkan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string HasilYangDiharapkan { get; set; }

    [Display(Name = "Status Implementasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required StatusImplementasi StatusImplementasi { get; set; }

    [Display(Name = "Dokumen Pendukung")]
	public IFormFile? DokumenPendukung { get; set; }

    [Display(Name = "Produk Terkait")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string ProdukId { get; set; }

    [Display(Name = "Kolaborator")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required int[] DaftarKolaboratorId { get; set; }

}