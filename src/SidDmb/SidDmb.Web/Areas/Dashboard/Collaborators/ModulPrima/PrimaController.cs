using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Authentication;

namespace SidDmb.Web.Areas.Dashboard.Collaborators.ModulPrima;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.KOLABORATOR)]
public class PrimaController : Controller
{
    public IActionResult KegiatanPrima()
    {
        return View();
    }
}