using SidDmb.Domain.MasterDataFunction.ModulPreneur.UnitUsahas;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulPreneur.UnitUsahas;

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
	public required KategoriUnitUsaha Kategori { get; set; }

    [Display(Name = "Alamat")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string Alamat { get; set; }

    [Display(Name = "Titik Koordinat (Lat)")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required double Lat { get; set; }
	
	[Display(Name = "Titik Koordinat (Lng)")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required double Lng { get; set; }

    [Display(Name = "Pemilik Usaha")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string PemilikUsaha { get; set; }

    [Display(Name = "Jumlah Karyawan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required int JumlahKaryawan { get; set; }

    [Display(Name = "Legalitas")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required LegalitasUsaha Legalitas { get; set; }

	[Display(Name = "Tanggal Berdiri")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required DateOnly TanggalBerdiri { get; set; }

    [Display(Name = "Kontak Informasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string KontakInformasi { get; set; }

    [Display(Name = "Media PromosiBaru")]
	public IFormFile? MediaPromosiBaru { get; set; }

}
