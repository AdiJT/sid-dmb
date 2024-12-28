using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Authentication;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulPelatihanEdukasi.PeningkatanKapasitas;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.ADMIN)]
public class PeningkatanKapasitasController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}