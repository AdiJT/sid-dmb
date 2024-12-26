using SidDmb.Domain.MasterDataFunction.ModulBudaya.SeniBudayas;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulBudaya.SeniBudayas;

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
    public required KategoriSeni Kategori { get; set; }

    [Display(Name = "Nama Pelaku Seni")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string NamaPelakuSeni { get; set; }

    [Display(Name = "Lokasi Pertunjukan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string LokasiPertunjukan { get; set; }

    [Display(Name = "Waktu Pertunjukan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string WaktuPertunjukan { get; set; }

    [Display(Name = "Durasi Pentunjukan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
    public required TimeSpan DurasiPentunjukan { get; set; }

    [Display(Name = "Harga Tiket")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required double HargaTiket { get; set; }

    [Display(Name = "Peraturan Khusus")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string PeraturanKhusus { get; set; }

    [Display(Name = "Media Promosi Baru")]
    public IFormFile? MediaPromosiBaru { get; set; }

    [Display(Name = "Fasilitas Pertunjukan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string[] FasilitasPertunjukan { get; set; } = [];
}
