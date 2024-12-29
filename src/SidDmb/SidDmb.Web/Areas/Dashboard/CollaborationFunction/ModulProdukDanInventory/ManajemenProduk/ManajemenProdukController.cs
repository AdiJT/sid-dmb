using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Authentication;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulProdukDanInventory.ManajemenProduk;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.ADMIN)]
public class ManajemenProdukController : Controller
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
