using SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi.MateriEdukasiDanPembelajaran;
using SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi.PeningkatanKapasitas;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulPelatihanEdukasi.PeningkatanKapasitas;

public class EditVM
{
    [Display(Name = "Id")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Id { get; set; }

    [Display(Name = "Nama")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Nama { get; set; }

    [Display(Name = "Dekripsi")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Dekripsi { get; set; }

    [Display(Name = "Kategori")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required KategoriPelatihan Kategori { get; set; }

    [Display(Name = "Penyelenggara")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Penyelenggara { get; set; }

    [Display(Name = "TanggalPelaksanaan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required DateOnly TanggalPelaksanaan { get; set; }

    [Display(Name = "Durasi")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required TimeSpan Durasi { get; set; }

    [Display(Name = "Lokasi")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Lokasi { get; set; }

    [Display(Name = "TargetPeserta")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required TargetPeserta[] TargetPeserta { get; set; }

    [Display(Name = "JumlahPeserta")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int JumlahPeserta { get; set; }

    [Display(Name = "Fasilitator")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Fasilitator { get; set; }

    [Display(Name = "Materi")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Materi { get; set; }

    [Display(Name = "EvaluasiPeserta")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string EvaluasiPeserta { get; set; }

    [Display(Name = "DokumenDanMedia")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public IFormFile? DokumenDanMedia { get; set; }

    [Display(Name = "FeedbackPeserta")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string FeedbackPeserta { get; set; }

    [Display(Name = "Kolaborator")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required int[] DaftarKolaboratorId { get; set; }
}
