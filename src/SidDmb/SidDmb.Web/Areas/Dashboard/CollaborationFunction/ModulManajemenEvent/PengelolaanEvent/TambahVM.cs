using SidDmb.Domain.CollaborationFunction.ModulManajemenEvent.PengelolaanEvent;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulManajemenEvent.PengelolaanEvent;

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
    public KategoriEvent Kategori { get; set; }

    [Display(Name = "Tanggal Waktu")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public DateTime TanggalWaktu { get; set; } = DateTime.Now;

    [Display(Name = "Lokasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string Lokasi { get; set; } = string.Empty;

    [Display(Name = "Penyelenggara")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string Penyelenggara { get; set; } = string.Empty;

    [Display(Name = "Kontak Informasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string KontakInformasi { get; set; } = string.Empty;

    [Display(Name = "Target Peserta")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public TargetPeserta TargetPeserta { get; set; }

    [Display(Name = "Jumlah Peserta Maksimal")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public int JumlahPesertaMaksimal { get; set; }

    [Display(Name = "Status Pendaftaran")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public StatusPendaftaran StatusPendaftaran { get; set; }

    [Display(Name = "Sponsor")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string Sponsor { get; set; } = string.Empty;

    [Display(Name = "Anggaran")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public double Anggaran { get; set; }

    [Display(Name = "Media Promosi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public IFormFile MediaPromosi { get; set; }

	[Display(Name = "Daftar Kolaborator")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public int[] DaftarKolaboratorId { get; set; } = [];
}