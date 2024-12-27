using SidDmb.Domain.MasterDataFunction.ModulWisata.KalenderAcaras;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulWisata.KalenderAcaras;

public class TambahVM
{
    [Display(Name = "Nama Acara")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string NamaAcara { get; set; } = string.Empty;

    [Display(Name = "Dekripsi Acara")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string DekripsiAcara { get; set; } = string.Empty;

    [Display(Name = "Kategori")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public KategoriAcara Kategori { get; set; }

    [Display(Name = "Tanggal Dan Waktu")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public DateTime TanggalDanWaktu { get; set; } = DateTime.Now;

    [Display(Name = "Lokasi Acara")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string LokasiAcara { get; set; } = string.Empty;

    [Display(Name = "Penanggung Jawab")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string PenanggungJawab { get; set; } = string.Empty;

    [Display(Name = "Kontak Informasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string KontakInformasi { get; set; } = string.Empty;

    [Display(Name = "Harga Tiket Acara")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public double HargaTiketAcara { get; set; }

    [Display(Name = "Target Peserta Acara")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public TargetPesertaAcara TargetPesertaAcara { get; set; }

    [Display(Name = "Batas Kuota Peserta")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public int BatasKuotaPeserta { get; set; }

    [Display(Name = "Status Pendaftaran")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public StatusPendaftaran StatusPendaftaran { get; set; }

    [Display(Name = "Media Promosi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public IFormFile MediaPromosi { get; set; }

    [Display(Name = "Sponsor Acara")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string SponsorAcara { get; set; } = string.Empty;

    [Display(Name = "Tautan Pendaftaran")]
	[Required(ErrorMessage = "{0} harus diisi")]
	[Url(ErrorMessage = "{0} bukan URL Valid")]
	public Uri TautanPendaftaran { get; set; }

    [Display(Name = "Rating Acara")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public double RatingAcara { get; set; }

}