using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.Collaborators.ModulResearchAndDevelopment;

public class RekomendasiDanPengembanganProdukDetailVM
{
    [Display(Name = "Id")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Id { get; set; }

    [Display(Name = "Feedback Kolaborator")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string FeedbackKolaborator { get; set; }
}