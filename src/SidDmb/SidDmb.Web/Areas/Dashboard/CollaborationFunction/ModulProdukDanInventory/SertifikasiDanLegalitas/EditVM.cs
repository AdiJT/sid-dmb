using SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.SertifikasiDanLegalitas;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulProdukDanInventory.SertifikasiDanLegalitas;

public class EditVM
{
    [Display(Name = "Id")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Id { get; set; }

    [Display(Name = "Jenis Sertifikasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required JenisSertifikasi JenisSertifikasi { get; set; }

    [Display(Name = "Nomor Sertifikasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string NomorSertifikasi { get; set; }

    [Display(Name = "Tanggal Penerbitan")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required DateOnly TanggalPenerbitan { get; set; }

    [Display(Name = "Tanggal Kadaluarsa")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required DateOnly TanggalKadaluarsa { get; set; }

    [Display(Name = "Pemberi Sertifikat")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string PemberiSertifikat { get; set; }

    [Display(Name = "Dokumen Sertifikat")]
	public IFormFile? DokumenSertifikat { get; set; }

    [Display(Name = "Proses Yang Dilalui")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string ProsesYangDilalui { get; set; }

    [Display(Name = "Status Sertifikasi")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required StatusSertifikasi StatusSertifikasi { get; set; }

    [Display(Name = "Produk")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required string ProdukId { get; set; }

    [Display(Name = "Kolaborator")]
	[Required(ErrorMessage = "{0} harus diisi")]
	public required int[] DaftarKolaboratorId { get; set; }

}
