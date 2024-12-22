using Microsoft.AspNetCore.Mvc;

namespace SidDmb.Web.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
