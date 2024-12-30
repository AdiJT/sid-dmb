using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.Collaborators.ModulPelatihanEdukasi;

public class PeningkatanEdukasiDetailVM
{
    [Display(Name = "Id")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Id { get; set; }

    [Display(Name = "Rekomendasi Pelatihan Berikutnya")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string RekomendasiUntukPelatihanBerikutnya { get; set; }
}