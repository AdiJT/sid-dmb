using SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.SertifikasiDanLegalitas;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulProdukDanInventory.SertifikasiDanLegalitas;

public class TambahVM
{
    [Display(Name = "JenisSertifikasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public JenisSertifikasi JenisSertifikasi { get; set; }

    [Display(Name = "NomorSertifikasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string NomorSertifikasi { get; set; } = string.Empty;

    [Display(Name = "TanggalPenerbitan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public DateOnly TanggalPenerbitan { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    [Display(Name = "TanggalKadaluarsa")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public DateOnly TanggalKadaluarsa { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    [Display(Name = "PemberiSertifikat")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string PemberiSertifikat { get; set; } = string.Empty;

    [Display(Name = "DokumenSertifikat")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public IFormFile DokumenSertifikat { get; set; }

    [Display(Name = "ProsesYangDilalui")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string ProsesYangDilalui { get; set; } = string.Empty;

    [Display(Name = "StatusSertifikasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public StatusSertifikasi StatusSertifikasi { get; set; }

    [Display(Name = "ProdukId")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public string ProdukId { get; set; } = string.Empty;

    [Display(Name = "DaftarKolaboratorId")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public int[] DaftarKolaboratorId { get; set; } = [];

}
