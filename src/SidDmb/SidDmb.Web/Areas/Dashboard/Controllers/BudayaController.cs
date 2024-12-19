using Microsoft.AspNetCore.Mvc;

namespace SidDmb.Web.Areas.Dashboard.Controllers;
[Area("Dashboard")]
public class BudayaController : Controller
{
    public IActionResult ArtefakBudaya()
    {
        return View();
    }
    public IActionResult SeniBudaya()
    {
        return View();
    }
    public IActionResult SitusBudaya()
    {
        return View();
    }
    public IActionResult UpacaraBudaya()
    {
        return View();
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult TambahSeniBudaya()
    {
        return View();
    }
    public IActionResult TambahSitusBudaya()
    {
        return View();
    }
    public IActionResult TambahUpacaraBudaya()
    {
        return View();
    }
    public IActionResult EditArtefakBudaya()
    {
        return View();
    }
    public IActionResult EditSeniBudaya()
    {
        return View();
    }
    public IActionResult EditSitusBudaya()
    {
        return View();
    }
    public IActionResult EditUpacaraBudaya()
    {
        return View();
    }
}
