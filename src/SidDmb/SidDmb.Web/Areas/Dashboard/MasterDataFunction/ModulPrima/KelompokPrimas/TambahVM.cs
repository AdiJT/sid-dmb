using SidDmb.Domain.MasterDataFunction.ModulPrima.KelompokPrimas;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulPrima.KelompokPrimas;

public class TambahVM
{
    [Display(Name = "Nama")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string Nama { get; set; } = string.Empty;

    [Display(Name = "Dekripsi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string Dekripsi { get; set; } = string.Empty;

    [Display(Name = "Jumlah Anggota")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public int JumlahAnggota { get; set; }

    [Display(Name = "Ketua Kelompok")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string KetuaKelompok { get; set; } = string.Empty;

    [Display(Name = "Tahun Berdiri")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public int TahunBerdiri { get; set; }

	[Display(Name = "Fokus Kegiatan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public FokusKegiatanKelompokPrima[] FokusKegiatan { get; set; } = [];

    [Display(Name = "Program Unggulan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string ProgramUnggulan { get; set; } = string.Empty;

    [Display(Name = "Alamat")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string Alamat { get; set; } = string.Empty;

    [Display(Name = "Kontak Informasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string KontakInformasi { get; set; } = string.Empty;

    [Display(Name = "Media Promosi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public IFormFile MediaPromosi { get; set; }

    [Display(Name = "Jumlah Program Dilaksanakan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public int JumlahProgramDilaksanakan { get; set; }

}