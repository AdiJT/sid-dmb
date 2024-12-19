using Microsoft.AspNetCore.Mvc;

namespace SidDmb.Web.Areas.Dashboard.Controllers;
[Area("Dashboard")]
public class PreneurController : Controller
{
    public IActionResult ProdukLokal()
    {
        return View();
    }
    public IActionResult UnitUsaha()
    {
        return View();
    }
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult TambahUnitUsaha()
    {
        return View();
    }
    public IActionResult EditProdukLokal()
    {
        return View();
    }
    public IActionResult EditUnitUsaha()
    {
        return View();
    }
}
