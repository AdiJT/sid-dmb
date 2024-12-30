using SidDmb.Domain.CollaborationFunction.ModulResearchAndDevelopment.ManajemenDataRiset;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulResearchAndDevelopment.ManajemenDataRiset;

public class EditVM
{
    [Display(Name = "Id")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Id { get; set; }

    [Display(Name = "Judul Penelitian")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string JudulPenelitian { get; set; }

    [Display(Name = "Dekripsi Penelitian")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string DekripsiPenelitian { get; set; }

    [Display(Name = "Kategori Penelitian")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required KategoriPenelitian KategoriPenelitian { get; set; }

    [Display(Name = "Entitas Penelitian")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string EntitasPeneliti { get; set; }

    [Display(Name = "Tanggal Mulai Penelitian")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required DateOnly TanggalMulaiPenelitian { get; set; }

    [Display(Name = "Tanggal Selesai Penelitian")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required DateOnly TanggalSelesaiPenelitian { get; set; }

    [Display(Name = "Metode Pengumpulan Data")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string MetodePengumpulanData { get; set; }

    [Display(Name = "Hasil Penelitian")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string HasilPenelitian { get; set; }

    [Display(Name = "Dokumen Penelitian")]
	public IFormFile? DokumenPenelitian { get; set; }

    [Display(Name = "Manfaat Penelitian")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string ManfaatPenelitian { get; set; }

    [Display(Name = "Status Penelitian")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required StatusPenelitian StatusPenelitian { get; set; }

    [Display(Name = "Jenis Data Riset")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string[] DaftarJenisDataRiset { get; set; }

    [Display(Name = "Kolaborator")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required int[] DaftarKolaboratorId { get; set; }

}