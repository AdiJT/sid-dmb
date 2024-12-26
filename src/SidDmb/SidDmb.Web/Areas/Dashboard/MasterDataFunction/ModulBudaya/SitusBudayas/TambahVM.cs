using NetTopologySuite.Geometries;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.SitusBudayas;
using SidDmb.Domain.MasterDataFunction.ModulWisata.DestinasiWisatas;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulBudaya.SitusBudayas;

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
	public KategoriSitus Kategori { get; set; }

    [Display(Name = "Alamat")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string Alamat { get; set; } = string.Empty;

    [Display(Name = "Koordinat Lokasi (Lat)")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public double Lat { get; set; }

    [Display(Name = "Koordinat Lokasi (Lng)")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public double Lng { get; set; }

    [Display(Name = "Harga Tiket Masuk")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public double HargaTiketMasuk { get; set; }

    [Display(Name = "Jam Operasional")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string JamOperasional { get; set; } = string.Empty;

    [Display(Name = "Kontak Informasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string KontakInformasi { get; set; } = string.Empty;

    [Display(Name = "Foto Promosi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public IFormFile FotoPromosi { get; set; }

    [Display(Name = "Pengelola Situs")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string PengelolaSitus { get; set; } = string.Empty;

    [Display(Name = "Status")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public StatusOperasional Status { get; set; }

    [Display(Name = "Peraturan Khusus")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string PeraturanKhusus { get; set; } = string.Empty;

    [Display(Name = "Daftar Fasilitas")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string[] DaftarFasilitas { get; set; } = [];

}
