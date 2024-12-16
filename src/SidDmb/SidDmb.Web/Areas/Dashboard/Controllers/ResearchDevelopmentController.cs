using Microsoft.AspNetCore.Mvc;

namespace SidDmb.Web.Areas.Dashboard.Controllers;
[Area("Dashboard")]
public class ResearchDevelopmentController : Controller
{
    public IActionResult ManajemenDataRiset()
    {
        return View();
    }
    public IActionResult RekomendasiProduk()
    {
        return View();
    }
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult TambahRekomendasiProduk()
    {
        return View();
    }
}
