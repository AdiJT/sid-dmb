using SidDmb.Domain.MasterDataFunction.ModulBudaya.ArtefakBudayas;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulBudaya.ArtefakBudayas;

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
    public required KategoriArtefak Kategori { get; set; }

    [Display(Name = "Lokasi Penyimpanan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string LokasiPenyimpanan { get; set; }

    [Display(Name = "Kondisi")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required KondisiArtefak Kondisi { get; set; }

    [Display(Name = "Usia")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Usia { get; set; }

    [Display(Name = "Bahan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Bahan { get; set; }

    [Display(Name = "Dimensi")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Dimensi { get; set; }

    [Display(Name = "Pengelola")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Pengelola { get; set; }

    [Display(Name = "Nilai Historis")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string NilaiHistoris { get; set; }

    [Display(Name = "Foto Baru")]
    public IFormFile? FotoBaru { get; set; }

    [Display(Name = "Ketersediaan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required KetersediaanPameran Ketersediaan { get; set; }

    public required Uri Foto { get; set; }
}