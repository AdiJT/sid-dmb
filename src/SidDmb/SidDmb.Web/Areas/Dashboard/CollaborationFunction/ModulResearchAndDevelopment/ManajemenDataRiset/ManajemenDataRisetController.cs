using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Authentication;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulResearchAndDevelopment.ManajemenDataRiset;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.ADMIN)]
public class ManajemenDataRisetController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Tambah()
    {
        return View();
    }

    public IActionResult Edit()
    {
        return View();
    }
}
