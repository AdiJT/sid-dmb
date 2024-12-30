using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.Collaborators.ModulProdukDanInventory;

public class SertifikasiDanLegalitasDetailVM
{
    [Display(Name = "Id")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Id { get; set; }

    [Display(Name = "Komentar")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public required string Komentar { get; set; }
}