using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Authentication;

namespace SidDmb.Web.Areas.Dashboard.Collaborators.ModulResearchAndDevelopment;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.KOLABORATOR)]
public class ResearchAndDevelopmentController : Controller
{
    public IActionResult ManajemenDataRiset()
    {
        return View();
    }

    public IActionResult ManajemenDataRisetDetail()
    {
        return View();
    }

    public IActionResult RekomendasiDanPengembanganProduk()
    {
        return View();
    }
    public IActionResult RekomendasiDanPengembanganProdukDetail()
    {
        return View();
    }
}