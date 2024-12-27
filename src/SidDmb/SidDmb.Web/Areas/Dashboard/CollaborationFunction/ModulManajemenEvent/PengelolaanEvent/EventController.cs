using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Authentication;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulManajemenEvent.PengelolaanEvent;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.ADMIN)]
public class EventController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
