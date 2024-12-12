using Microsoft.AspNetCore.Mvc;

namespace SidDmb.Web.Areas.Dashboard.Controllers;
[Area("Dashboard")]
public class ManajemenEventController : Controller
{
    public IActionResult PelaporanDokumentasi()
    {
        return View();
    }
}
