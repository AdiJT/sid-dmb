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
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult TambahManajemenProduk()
    {
        return View();
    }
    public IActionResult TambahSertifikasi()
    {
        return View();
    }
    public IActionResult EditManajemenDistribusi()
    {
        return View();
    }
    public IActionResult EditManajemenProduk()
    {
        return View();
    }
    public IActionResult EditSertifikasi()
    {
        return View();
    }
}
