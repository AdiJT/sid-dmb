using SidDmb.Domain.MasterDataFunction.ModulBudaya.SitusBudayas;
using SidDmb.Domain.MasterDataFunction.ModulWisata.DestinasiWisatas;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulBudaya.SitusBudayas;

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
	public required KategoriSitus Kategori { get; set; }

    [Display(Name = "Alamat")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string Alamat { get; set; }

    [Display(Name = "Koordinat Lokasi (Lat)")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required double Lat { get; set; }

    [Display(Name = "Koordinat Lokasi (Lng)")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required double Lng { get; set; }

    [Display(Name = "Harga Tiket Masuk")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required double HargaTiketMasuk { get; set; }

    [Display(Name = "Jam Operasional")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string JamOperasional { get; set; }

    [Display(Name = "Kontak Informasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string KontakInformasi { get; set; }

    [Display(Name = "Foto Promosi Baru")]
	public IFormFile? FotoPromosiBaru { get; set; }

    [Display(Name = "Pengelola Situs")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string PengelolaSitus { get; set; }

    [Display(Name = "Status")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required StatusOperasional Status { get; set; }

    [Display(Name = "Peraturan Khusus")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string PeraturanKhusus { get; set; }

    [Display(Name = "Daftar Fasilitas")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string[] DaftarFasilitas { get; set; }

}
