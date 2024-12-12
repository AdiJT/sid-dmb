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
}
