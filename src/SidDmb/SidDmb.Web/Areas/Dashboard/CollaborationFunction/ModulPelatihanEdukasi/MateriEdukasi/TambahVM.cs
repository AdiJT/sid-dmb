using SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi.MateriEdukasiDanPembelajaran;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulPelatihanEdukasi.MateriEdukasi;

public class TambahVM
{
    [Display(Name = "Judul Materi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string JudulMateri { get; set; } = string.Empty;

    [Display(Name = "Dekripsi Materi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string DekripsiMateri { get; set; } = string.Empty;

    [Display(Name = "Kategori Materi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public KategoriMateri KategoriMateri { get; set; }

    [Display(Name = "Penyedia Materi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string PenyediaMateri { get; set; } = string.Empty;

	[Display(Name = "Target Audiens")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public TargetAudiens[] TargetAudiens { get; set; } = [];

    [Display(Name = "Tipe Materi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public TipeMateri TipeMateri { get; set; }

    [Display(Name = "Link Unduhan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public IFormFile LinkUnduhan { get; set; }

    [Display(Name = "Tanggal Rilis")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public DateOnly TanggalRilis { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    [Display(Name = "FeedBack Audiens")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string FeedBackAudiens { get; set; } = string.Empty;

    [Display(Name = "Dokumen Pendukung")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public IFormFile DokumenPendukung { get; set; }

    [Display(Name = "Jumlah Pengguna")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public int JumlahPengguna { get; set; }

    [Display(Name = "Status Materi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public StatusMateri StatusMateri { get; set; }

	[Display(Name = "Kolaborator")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public int[] DaftarKolaboratorId { get; set; } = [];
}
