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
}
