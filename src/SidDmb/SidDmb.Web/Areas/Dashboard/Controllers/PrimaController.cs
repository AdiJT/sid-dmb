using Microsoft.AspNetCore.Mvc;

namespace SidDmb.Web.Areas.Dashboard.Controllers;
[Area("Dashboard")]
public class PrimaController : Controller
{
    public IActionResult KegiatanPrima()
    {
        return View();
    }
}
