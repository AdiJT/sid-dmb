using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Authentication;

namespace SidDmb.Web.Areas.Dashboard.Collaborators.ModulProdukDanInventory;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.KOLABORATOR)]
public class ProdukDanInventoryController : Controller
{
    public IActionResult ManajemenDistribusi()
    {
        return View();
    }

    public IActionResult ManajemenProduk()
    {
        return View();
    }

    public IActionResult SertifikasiDanLegalitas()
    {
        return View();
    }
}