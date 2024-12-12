using Microsoft.AspNetCore.Mvc;

namespace SidDmb.Web.Areas.Dashboard.Controllers;
[Area("Dashboard")]
public class BudayaController : Controller
{
    public IActionResult ArtefakBudaya()
    {
        return View();
    }
}
