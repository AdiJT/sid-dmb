using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulWisata.LaporanKunjungans;

public class TambahVM
{
    [Display(Name = "Tanggal Kunjungan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public DateOnly TanggalKunjungan { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    [Display(Name = "Jumlah Wisatawan Domestik")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public int JumlahWisatawanDomestik { get; set; }

    [Display(Name = "Jumlah Wisatawan Internasional")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public int JumlahWisatawanInternasional { get; set; }

    [Display(Name = "Durasi Kunjungan")]
	[Required(ErrorMessage = "{0} harus diisi")]
    [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
    public TimeSpan DurasiKunjungan { get; set; }

    [Display(Name = "Tiket Terjual")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public int TiketTerjual { get; set; }

    [Display(Name = "Rating Pengunjung")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public double RatingPengunjung { get; set; }

    [Display(Name = "Komentar Pengunjung")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string KomentarPengunjung { get; set; } = string.Empty;

    [Display(Name = "Destinasi Wisata")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string DestinasiWisataId { get; set; } = string.Empty;

}