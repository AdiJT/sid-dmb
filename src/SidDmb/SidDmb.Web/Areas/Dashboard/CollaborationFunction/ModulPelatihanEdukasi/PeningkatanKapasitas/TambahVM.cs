using SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi.MateriEdukasiDanPembelajaran;
using SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi.PeningkatanKapasitas;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulPelatihanEdukasi.PeningkatanKapasitas;

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
	public KategoriPelatihan Kategori { get; set; }

    [Display(Name = "Penyelenggara")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string Penyelenggara { get; set; } = string.Empty;

    [Display(Name = "TanggalPelaksanaan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public DateOnly TanggalPelaksanaan { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    [Display(Name = "Durasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
    [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
    public TimeSpan Durasi { get; set; }

    [Display(Name = "Lokasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string Lokasi { get; set; } = string.Empty;

	[Display(Name = "TargetPeserta")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public TargetPeserta[] TargetPeserta { get; set; } = [];

    [Display(Name = "JumlahPeserta")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public int JumlahPeserta { get; set; }

    [Display(Name = "Fasilitator")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string Fasilitator { get; set; } = string.Empty;

    [Display(Name = "Materi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string Materi { get; set; } = string.Empty;

    [Display(Name = "EvaluasiPeserta")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string EvaluasiPeserta { get; set; } = string.Empty;

    [Display(Name = "DokumenDanMedia")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public IFormFile DokumenDanMedia { get; set; }

    [Display(Name = "FeedbackPeserta")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string FeedbackPeserta { get; set; } = string.Empty;

    [Display(Name = "Kolaborator")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public int[] DaftarKolaboratorId { get; set; } = [];
}
