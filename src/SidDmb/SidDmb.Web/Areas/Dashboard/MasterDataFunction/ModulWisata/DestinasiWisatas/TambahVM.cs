using SidDmb.Domain.MasterDataFunction.ModulWisata.DestinasiWisatas;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulWisata.DestinasiWisatas;

public class TambahVM
{
    [Display(Name = "Nama")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string Nama { get; set; } = string.Empty;

    [Display(Name = "Deskripsi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string Deskripsi { get; set; } = string.Empty;

    [Display(Name = "Kategori")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public KategoriDestinasi Kategori { get; set; }

    [Display(Name = "Alamat")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string Alamat { get; set; } = string.Empty;

    [Display(Name = "Lat")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public double Lat { get; set; }

    [Display(Name = "Lng")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public double Lng { get; set; }

    [Display(Name = "Harga Tiket Masuk")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public double HargaTiketMasuk { get; set; }

    [Display(Name = "Jam Operasional")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string JamOperasional { get; set; } = string.Empty;

    [Display(Name = "Informasi Kontak")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string InformasiKontak { get; set; } = string.Empty;

    [Display(Name = "Pengelola Destinasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string PengelolaDestinasi { get; set; } = string.Empty;

    [Display(Name = "Status Operasional")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public StatusOperasional StatusOperasional { get; set; }

    [Display(Name = "Foto")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public IFormFile Foto { get; set; }

    [Display(Name = "Rating")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public double Rating { get; set; }

    [Display(Name = "Fasilitas")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string[] DaftarFasilitas { get; set; } = [];

    [Display(Name = "Aktivitas")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string[] DaftarAktivitas { get; set; } = [];
}
