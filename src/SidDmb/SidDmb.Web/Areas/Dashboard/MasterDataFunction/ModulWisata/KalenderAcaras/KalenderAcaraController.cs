using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Authentication;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulWisata.KalenderAcaras;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.ADMIN)]
public class KalenderAcaraController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
