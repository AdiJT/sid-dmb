using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Authentication;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulProdukDanInventory.SertifikasiDanLegalitas;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.ADMIN)]
public class SertifikasiController : Controller
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
