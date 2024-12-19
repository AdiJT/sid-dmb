using Microsoft.AspNetCore.Mvc;

namespace SidDmb.Web.Areas.Dashboard.Controllers;
[Area("Dashboard")]
public class PelatihanEdukasiController : Controller
{
    public IActionResult MateriEdukasi()
    {
        return View();
    }
    public IActionResult PeningkatanKapasitas()
    {
        return View();
    }
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult TambahPeningkatanKapasitas()
    {
        return View();
    }
    public IActionResult EditMateriEdukasi()
    {
        return View();
    }
    public IActionResult EditPeningkatanKapasitas()
    {
        return View();
    }
}
