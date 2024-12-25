using System.ComponentModel.DataAnnotations;

namespace SidDmb.Web.Areas.Dashboard.Models.HomeModels;

public class LoginVM
{
    [Display(Name = "User Name")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public string UserName { get; set; } = string.Empty;

    [Display(Name = "Password")]
    [Required(ErrorMessage = "{0} harus diisi")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [Display(Name = "Ingat Saya")]
    [Required(ErrorMessage = "{0} harus diisi")]
    public bool RememberMe { get; set; }

    [Required(ErrorMessage = "{0} harus ada")]
    public required string ReturnUrl { get; set; }
}