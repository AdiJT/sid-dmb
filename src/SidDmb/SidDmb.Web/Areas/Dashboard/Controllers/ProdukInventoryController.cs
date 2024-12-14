using Microsoft.AspNetCore.Mvc;

namespace SidDmb.Web.Areas.Dashboard.Controllers;
[Area("Dashboard")]
public class ProdukInventoryController : Controller
{
    public IActionResult ManajemenDistribusi()
    {
        return View();
    }
    public IActionResult ManajemenProduk()
    {
        return View();
    }
    public IActionResult Sertifikasi()
    {
        return View();
    }
}
