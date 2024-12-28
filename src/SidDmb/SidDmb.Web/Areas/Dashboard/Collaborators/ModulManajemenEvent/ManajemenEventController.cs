using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Authentication;

namespace SidDmb.Web.Areas.Dashboard.Collaborators.ModulManajemenEvent;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.KOLABORATOR)]
public class ManajemenEventController : Controller
{
    public IActionResult PengelolaanEvent()
    {
        return View();
    }

    public IActionResult PelaporanDanDokumentasi()
    {
        return View(); 
    }
}