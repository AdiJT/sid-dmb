using SidDmb.Domain.MasterDataFunction.ModulBudaya.UpacaraBudayas;
using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulBudaya.UpacaraBudayas;

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
    public required KategoriUpacara Kategori { get; set; }

    [Display(Name = "Lokasi Pelaksanaan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string LokasiPelaksanaan { get; set; }

    [Display(Name = "Waktu Pelaksanaan")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required DateTime WaktuPelaksanaan { get; set; }

    [Display(Name = "Durasi")]
    [Required(ErrorMessage = "{0} harus diisi")]
    [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
    public required TimeSpan Durasi { get; set; }

    [Display(Name = "Pihak Terlibat")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string PihakTerlibat { get; set; }

    [Display(Name = "Rangkaian Acara")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string RangkaianAcara { get; set; }

    [Display(Name = "Jumlah Peserta")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required int JumlahPeserta { get; set; }

    [Display(Name = "Media Promosi Baru")]
    public IFormFile? MediaPromosiBaru { get; set; }

    [Display(Name = "Peraturan Khusus")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string PeraturanKhusus { get; set; }

    [Display(Name = "Fasilitas Pendukung")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string[] FasilitasPendukung { get; set; }} 