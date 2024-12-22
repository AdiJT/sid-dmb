using Microsoft.AspNetCore.Mvc;

namespace SidDmb.Web.Controllers
{
    public class AtraksiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Destinasi()
        {
            return View();
        }
    }
}
