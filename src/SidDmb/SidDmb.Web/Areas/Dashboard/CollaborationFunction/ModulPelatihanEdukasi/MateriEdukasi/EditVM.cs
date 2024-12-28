using SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi.MateriEdukasiDanPembelajaran;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulPelatihanEdukasi.MateriEdukasi;

public class EditVM
{
    [Display(Name = "Id")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Id { get; set; }

    [Display(Name = "Judul Materi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string JudulMateri { get; set; }

    [Display(Name = "Dekripsi Materi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string DekripsiMateri { get; set; }

    [Display(Name = "Kategori Materi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required KategoriMateri KategoriMateri { get; set; }

    [Display(Name = "Penyedia Materi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string PenyediaMateri { get; set; }

    [Display(Name = "Target Audiens")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required TargetAudiens[] TargetAudiens { get; set; }

    [Display(Name = "Tipe Materi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required TipeMateri TipeMateri { get; set; }

    [Display(Name = "Link Unduhan")]
	public IFormFile? LinkUnduhan { get; set; }

    [Display(Name = "Tanggal Rilis")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required DateOnly TanggalRilis { get; set; }

    [Display(Name = "FeedBack Audiens")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string FeedBackAudiens { get; set; }

    [Display(Name = "Dokumen Pendukung")]
	public IFormFile? DokumenPendukung { get; set; }

    [Display(Name = "Jumlah Pengguna")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required int JumlahPengguna { get; set; }

    [Display(Name = "Status Materi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required StatusMateri StatusMateri { get; set; }

	[Display(Name = "Kolaborator")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required int[] DaftarKolaboratorId { get; set; }
}
