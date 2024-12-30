using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Authentication;
using SidDmb.Domain.MasterDataFunction.ModulPrima.KegiatanPrimas;
using SidDmb.Web.Authentication;

namespace SidDmb.Web.Areas.Dashboard.Collaborators.ModulPrima;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.KOLABORATOR)]
public class PrimaController : Controller
{
    private readonly IRepositoriKegiatanPrima _repositoriKegiatanPrima;
    private readonly IJoinEntityRepository<KolaboratorKegiatanPrima> _joinEntityRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISignInManager _signInManager;

    public PrimaController(
        IRepositoriKegiatanPrima repositoriKegiatanPrima,
        IJoinEntityRepository<KolaboratorKegiatanPrima> joinEntityRepository,
        IUnitOfWork unitOfWork,
        ISignInManager signInManager)
    {
        _repositoriKegiatanPrima = repositoriKegiatanPrima;
        _joinEntityRepository = joinEntityRepository;
        _unitOfWork = unitOfWork;
        _signInManager = signInManager;
    }

    public async Task<IActionResult> KegiatanPrima()
    {
        var appUser = await _signInManager.GetUser();
        if (appUser is null || appUser.Role != UserRoles.KOLABORATOR || appUser.Kolaborator is null)
            return StatusCode(StatusCodes.Status403Forbidden);

        return View((await _repositoriKegiatanPrima.GetAll()).Where(x => x.DaftarKolabolator.Contains(appUser.Kolaborator)).ToList());
    }

    public async Task<IActionResult> KegiatanPrimaDetail(string id)
    {
        var appUser = await _signInManager.GetUser();
        if (appUser is null || appUser.Role != UserRoles.KOLABORATOR || appUser.Kolaborator is null)
            return StatusCode(StatusCodes.Status403Forbidden);

        var resultId = IdKegiatanPrima.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var kegiatanPrima = await _repositoriKegiatanPrima.Get(resultId.Value);
        if (kegiatanPrima is null) return NotFound();

        var kolaboratorKegiatan = kegiatanPrima.DaftarKolaboratorKegiatan.FirstOrDefault(x => x.Entity2 == appUser.Kolaborator);
        if (kolaboratorKegiatan is null) return NotFound();

        return View(new KegiatanPrimaDetailVM
        {
            Id = id,
            RekomendasiBerikutnya = kolaboratorKegiatan.RekomendasiBerikutnya
        });
    }

    [HttpPost]
    public async Task<IActionResult> KegiatanPrimaDetail(KegiatanPrimaDetailVM vm)
    {
        if(!ModelState.IsValid) return View(vm);

        var appUser = await _signInManager.GetUser();
        if (appUser is null || appUser.Role != UserRoles.KOLABORATOR || appUser.Kolaborator is null)
            return StatusCode(StatusCodes.Status403Forbidden);

        var resultId = IdKegiatanPrima.Create(vm.Id);
        if (resultId.IsFailure) return BadRequest();

        var kegiatanPrima = await _repositoriKegiatanPrima.Get(resultId.Value);
        if (kegiatanPrima is null) return NotFound();

        var kolaboratorKegiatan = kegiatanPrima.DaftarKolaboratorKegiatan.FirstOrDefault(x => x.Entity2 == appUser.Kolaborator);
        if (kolaboratorKegiatan is null) return NotFound();

        kolaboratorKegiatan.RekomendasiBerikutnya = vm.RekomendasiBerikutnya;
        _joinEntityRepository.Update(kolaboratorKegiatan);

        var result = await _unitOfWork.SaveChangesAsync();
        if(result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, result.Error.Message);
            return View(vm);
        }

        return RedirectToAction(nameof(KegiatanPrima));
    }
}