using SidDmb.Domain.MasterDataFunction.ModulWisata.DestinasiWisatas;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulWisata.DestinasiWisatas;

public class EditVM
{
    [Display(Name = "Id")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string Id { get; set; }

    [Display(Name = "Nama")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Nama { get; set; }

    [Display(Name = "Deskripsi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string Deskripsi { get; set; }

    [Display(Name = "Kategori")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required KategoriDestinasi Kategori { get; set; }

    [Display(Name = "Alamat")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string Alamat { get; set; }

    [Display(Name = "Titik Koordinat (Lat)")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required double Lat { get; set; }

    [Display(Name = "Titik Koordinat (Lng)")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required double Lng { get; set; }

    [Display(Name = "Harga Tiket Masuk")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required double HargaTiketMasuk { get; set; }

    [Display(Name = "Jam Operasional")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string JamOperasional { get; set; }

    [Display(Name = "Informasi Kontak")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string InformasiKontak { get; set; }

    [Display(Name = "Pengelola Destinasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string PengelolaDestinasi { get; set; }

    [Display(Name = "Status Operasional")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required StatusOperasional StatusOperasional { get; set; }

    [Display(Name = "Foto")]
	public IFormFile? Foto { get; set; }

    [Display(Name = "Rating")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required double Rating { get; set; }

    [Display(Name = "Fasilitas")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string[] DaftarFasilitas { get; set; }

    [Display(Name = "Aktivitas")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string[] DaftarAktivitas { get; set; }
}
