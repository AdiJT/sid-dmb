using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulManajemenEvent.PelaporanDanDokumentasi;

public class EditVM
{
    [Display(Name = "Id")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Id { get; set; }

    [Display(Name = "Tanggal Pelaporan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required DateOnly TanggalPelaporan { get; set; }

    [Display(Name = "Pendapatan Event")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required double PendapatanEvent { get; set; }

    [Display(Name = "Pengeluaran Event")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required double PengeluaranEvent { get; set; }

    [Display(Name = "Jumlah Peserta")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required int JumlahPeserta { get; set; }

    [Display(Name = "Ulasan Singkat Event")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string UlasanSingkatEvent { get; set; }

    [Display(Name = "Feedback Peserta")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string FeedbackPeserta { get; set; }

    [Display(Name = "Foto Dokumentasi")]
	public IFormFile? FotoDokumentasi { get; set; }

    [Display(Name = "Video Dokumentasi")]
	public IFormFile? VideoDokumentasi { get; set; }

    [Display(Name = "Laporan Detail")]
	public IFormFile? LaporanDetail { get; set; }

    [Display(Name = "Event")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string EventId { get; set; }
}