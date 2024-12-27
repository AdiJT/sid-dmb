using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulManajemenEvent.PelaporanDanDokumentasi;

public class TambahVM
{
    [Display(Name = "Tanggal Pelaporan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public DateOnly TanggalPelaporan { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    [Display(Name = "Pendapatan Event")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public double PendapatanEvent { get; set; }
	
	[Display(Name = "Pengeluaran Event")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public double PengeluaranEvent { get; set; }

    [Display(Name = "Jumlah Peserta")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public int JumlahPeserta { get; set; }

    [Display(Name = "Ulasan Singkat Event")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string UlasanSingkatEvent { get; set; } = string.Empty;

    [Display(Name = "Feedback Peserta")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string FeedbackPeserta { get; set; } = string.Empty;

    [Display(Name = "Foto Dokumentasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public IFormFile FotoDokumentasi { get; set; }

    [Display(Name = "Video Dokumentasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public IFormFile VideoDokumentasi { get; set; }

    [Display(Name = "Laporan Detail")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public IFormFile LaporanDetail { get; set; }

    [Display(Name = "Event")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string EventId { get; set; } = string.Empty;
}