using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Authentication;

namespace SidDmb.Web.Areas.Dashboard.Collaborators.ModulPelatihanEdukasi;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.KOLABORATOR)]
public class PelatihanEdukasiController : Controller
{
    public IActionResult MateriEdukasi()
    {
        return View();
    }

    public IActionResult MateriEdukasiDetail()
    {
        return View();
    }

    public IActionResult PeningkatanEdukasi()
    {
        return View();
    }

    public IActionResult PeningkatanEdukasiDetail()
    {
        return View();
    }
}