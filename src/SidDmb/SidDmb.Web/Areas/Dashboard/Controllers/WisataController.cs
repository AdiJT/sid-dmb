using Microsoft.AspNetCore.Mvc;

namespace SidDmb.Web.Areas.Dashboard.Controllers;
[Area("Dashboard")]
public class WisataController : Controller
{
    public IActionResult DestinasiWisata()
    {
        return View();
    }

    public IActionResult KalenderAcara()
    {
        return View();
    }

    public IActionResult LaporanKunjungan()
    {
        return View();
    }
}
