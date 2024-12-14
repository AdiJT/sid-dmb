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
}
