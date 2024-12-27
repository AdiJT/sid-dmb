using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulWisata.LaporanKunjungans;

public class EditVM
{
    [Display(Name = "Id")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Id { get; set; }

    [Display(Name = "Tanggal Kunjungan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required DateOnly TanggalKunjungan { get; set; }

    [Display(Name = "Jumlah Wisatawan Domestik")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required int JumlahWisatawanDomestik { get; set; }

    [Display(Name = "Jumlah Wisatawan Internasional")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required int JumlahWisatawanInternasional { get; set; }

    [Display(Name = "Durasi Kunjungan")]
	[Required(ErrorMessage = "{0} harus diisi")]
    [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
    public required TimeSpan DurasiKunjungan { get; set; }

    [Display(Name = "Tiket Terjual")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required int TiketTerjual { get; set; }

    [Display(Name = "Rating Pengunjung")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required double RatingPengunjung { get; set; }

    [Display(Name = "Komentar Pengunjung")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string KomentarPengunjung { get; set; }

    [Display(Name = "Destinasi Wisata")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string DestinasiWisataId { get; set; }

}