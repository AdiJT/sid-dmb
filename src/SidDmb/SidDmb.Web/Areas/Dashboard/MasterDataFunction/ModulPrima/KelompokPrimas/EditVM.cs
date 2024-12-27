using SidDmb.Domain.MasterDataFunction.ModulPrima.KelompokPrimas;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulPrima.KelompokPrimas;

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

    [Display(Name = "Jumlah Anggota")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required int JumlahAnggota { get; set; }

    [Display(Name = "Ketua Kelompok")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string KetuaKelompok { get; set; }

    [Display(Name = "Tahun Berdiri")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required int TahunBerdiri { get; set; }

    [Display(Name = "Fokus Kegiatan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required FokusKegiatanKelompokPrima[] FokusKegiatan { get; set; }

    [Display(Name = "Program Unggulan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string ProgramUnggulan { get; set; }

    [Display(Name = "Alamat")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string Alamat { get; set; }

    [Display(Name = "Kontak Informasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string KontakInformasi { get; set; }

    [Display(Name = "Media Promosi Baru")]
	public IFormFile? MediaPromosiBaru { get; set; }

    [Display(Name = "Jumlah Program Dilaksanakan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required int JumlahProgramDilaksanakan { get; set; }

}