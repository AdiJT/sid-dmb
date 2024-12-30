using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.Collaborators.ModulPelatihanEdukasi;

public class MateriEdukasiDetailVM
{
    [Display(Name = "Id")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Id { get; set; }

    [Display(Name = "Rekomendasi Pembaruan Materi")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string RekomendasiPembaruanMateri { get; set; }
}
