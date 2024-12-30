using SidDmb.Domain.CollaborationFunction.ModulResearchAndDevelopment.ManajemenDataRiset;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulResearchAndDevelopment.ManajemenDataRiset;

public class TambahVM
{
    [Display(Name = "Judul Penelitian")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string JudulPenelitian { get; set; } = string.Empty;

    [Display(Name = "Dekripsi Penelitian")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string DekripsiPenelitian { get; set; } = string.Empty;

    [Display(Name = "Kategori Penelitian")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public KategoriPenelitian KategoriPenelitian { get; set; }

    [Display(Name = "Entitas Penelitian")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string EntitasPeneliti { get; set; } = string.Empty;

    [Display(Name = "Tanggal Mulai Penelitian")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public DateOnly TanggalMulaiPenelitian { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    [Display(Name = "Tanggal Selesai Penelitian")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public DateOnly TanggalSelesaiPenelitian { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    [Display(Name = "Metode Pengumpulan Data")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string MetodePengumpulanData { get; set; } = string.Empty;

    [Display(Name = "Hasil Penelitian")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string HasilPenelitian { get; set; } = string.Empty;

    [Display(Name = "Dokumen Penelitian")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public IFormFile DokumenPenelitian { get; set; }

    [Display(Name = "Manfaat Penelitian")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string ManfaatPenelitian { get; set; } = string.Empty;

    [Display(Name = "Status Penelitian")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public StatusPenelitian StatusPenelitian { get; set; }

    [Display(Name = "Jenis Data Riset")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string[] DaftarJenisDataRiset { get; set; } = [];

    [Display(Name = "Kolaborator")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public int[] DaftarKolaboratorId { get; set; } = [];

}