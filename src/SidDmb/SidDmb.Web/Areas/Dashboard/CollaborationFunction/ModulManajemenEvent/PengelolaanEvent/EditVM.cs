using SidDmb.Domain.CollaborationFunction.ModulManajemenEvent.PengelolaanEvent;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulManajemenEvent.PengelolaanEvent;

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
    public required KategoriEvent Kategori { get; set; }

    [Display(Name = "Tanggal Waktu")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required DateTime TanggalWaktu { get; set; }

    [Display(Name = "Lokasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string Lokasi { get; set; }

    [Display(Name = "Penyelenggara")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string Penyelenggara { get; set; }

    [Display(Name = "Kontak Informasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string KontakInformasi { get; set; }

    [Display(Name = "Target Peserta")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required TargetPeserta TargetPeserta { get; set; }

    [Display(Name = "Jumlah Peserta Maksimal")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required int JumlahPesertaMaksimal { get; set; }

    [Display(Name = "Status Pendaftaran")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required StatusPendaftaran StatusPendaftaran { get; set; }

    [Display(Name = "Sponsor")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string Sponsor { get; set; }

    [Display(Name = "Anggaran")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required double Anggaran { get; set; }

    [Display(Name = "Media Promosi")]
	public IFormFile? MediaPromosi { get; set; }

    [Display(Name = "Daftar Kolaborator")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int[] DaftarKolaboratorId { get; set; }

}