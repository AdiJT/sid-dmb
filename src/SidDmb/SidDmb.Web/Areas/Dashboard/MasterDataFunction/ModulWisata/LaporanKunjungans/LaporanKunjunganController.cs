using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Authentication;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulWisata.LaporanKunjungans;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.ADMIN)]
public class LaporanKunjunganController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
