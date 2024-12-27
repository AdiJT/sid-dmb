using SidDmb.Domain.MasterDataFunction.ModulWisata.KalenderAcaras;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulWisata.KalenderAcaras;

public class EditVM
{
    [Display(Name = "Id")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string Id { get; set; }

    [Display(Name = "Nama Acara")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string NamaAcara { get; set; }

    [Display(Name = "Dekripsi Acara")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string DekripsiAcara { get; set; }

    [Display(Name = "Kategori")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required KategoriAcara Kategori { get; set; }

    [Display(Name = "Tanggal Dan Waktu")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required DateTime TanggalDanWaktu { get; set; }

    [Display(Name = "Lokasi Acara")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string LokasiAcara { get; set; }

    [Display(Name = "Penanggung Jawab")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string PenanggungJawab { get; set; }

    [Display(Name = "Kontak Informasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string KontakInformasi { get; set; }

    [Display(Name = "Harga Tiket Acara")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required double HargaTiketAcara { get; set; }

    [Display(Name = "Target Peserta Acara")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required TargetPesertaAcara TargetPesertaAcara { get; set; }

    [Display(Name = "Batas Kuota Peserta")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required int BatasKuotaPeserta { get; set; }

    [Display(Name = "Status Pendaftaran")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required StatusPendaftaran StatusPendaftaran { get; set; }

    [Display(Name = "Media Promosi")]
	public IFormFile? MediaPromosi { get; set; }

    [Display(Name = "Sponsor Acara")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string SponsorAcara { get; set; }

    [Display(Name = "Tautan Pendaftaran")]
	[Required(ErrorMessage = "{0} harus diisi")]
    public required Uri TautanPendaftaran { get; set; }

    [Display(Name = "Rating Acara")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required double RatingAcara { get; set; }

}