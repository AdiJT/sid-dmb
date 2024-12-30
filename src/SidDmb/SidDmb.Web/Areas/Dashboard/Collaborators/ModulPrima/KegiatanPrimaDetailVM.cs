using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.Collaborators.ModulPrima;

public class KegiatanPrimaDetailVM
{
    [Display(Name = "Id")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Id { get; set; }

    [Display(Name = "Rekomendasi Kegiatan Berikutnya")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string RekomendasiBerikutnya { get; set; }
}