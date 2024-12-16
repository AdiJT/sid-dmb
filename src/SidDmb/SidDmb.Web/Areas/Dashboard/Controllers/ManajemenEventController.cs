using Microsoft.AspNetCore.Mvc;

namespace SidDmb.Web.Areas.Dashboard.Controllers;
[Area("Dashboard")]
public class ManajemenEventController : Controller
{
    public IActionResult PelaporanDokumentasi()
    {
        return View();
    }
    public IActionResult PengelolaanEvent()
    {
        return View();
    }
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult TambahPengelolaanEvent()
    {
        return View();
    }
}
