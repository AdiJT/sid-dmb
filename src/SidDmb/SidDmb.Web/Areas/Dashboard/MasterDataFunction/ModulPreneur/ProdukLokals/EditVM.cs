using SidDmb.Domain.MasterDataFunction.ModulPreneur.ProdukLokals;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulPreneur.ProdukLokals;

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
    public required KategoriProduk Kategori { get; set; }

    [Display(Name = "Harga")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required double Harga { get; set; }

    [Display(Name = "Bahan Utama")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string BahanUtama { get; set; }

    [Display(Name = "Status Ketersediaan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required StatusKetersediaanProduk StatusKetersediaan { get; set; }

    [Display(Name = "Tanggal Produksi Terakhir")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required DateTime TanggalProduksiTerakhir { get; set; }

    [Display(Name = "Tanggal Kadaluarsa")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required DateTime TanggalKadaluarsa { get; set; }

    [Display(Name = "Legalitas Dan Sertifikat")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string LegalitasDanSertifikat { get; set; }

    [Display(Name = "Kontak Informasi")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string KontakInformasi { get; set; }

    [Display(Name = "Media Promosi Baru")]
    public IFormFile? MediaPromosiBaru { get; set; }

    [Display(Name = "Unit Usaha")]
    [Required(ErrorMessage = "{0} harus dipilih")]
    public required string UnitUsahaId { get; set; }
}
