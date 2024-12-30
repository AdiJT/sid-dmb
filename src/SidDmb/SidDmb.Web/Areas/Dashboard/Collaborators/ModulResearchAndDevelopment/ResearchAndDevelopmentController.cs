using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Authentication;
using SidDmb.Domain.CollaborationFunction.ModulResearchAndDevelopment.ManajemenDataRiset;
using SidDmb.Domain.CollaborationFunction.ModulResearchAndDevelopment.RekomendasiDanPengembanganProduk;
using SidDmb.Web.Authentication;

namespace SidDmb.Web.Areas.Dashboard.Collaborators.ModulResearchAndDevelopment;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.KOLABORATOR)]
public class ResearchAndDevelopmentController : Controller
{
    private readonly IRepositoriDataRiset _repositoriDataRiset;
    private readonly IRepositoriRekomendasi _repositoriRekomendasi;
    private readonly IJoinEntityRepository<KolaboratorDataRiset> _repositoriKolaboratorDataRiset;
    private readonly IJoinEntityRepository<KolaboratorRekomendasi> _repositoriKolaboratorRekomendasi;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISignInManager _signInManager;

    public ResearchAndDevelopmentController(
        IRepositoriDataRiset repositoriDataRiset,
        IRepositoriRekomendasi repositoriRekomendasi,
        IJoinEntityRepository<KolaboratorDataRiset> repositoriKolaboratorDataRiset,
        IJoinEntityRepository<KolaboratorRekomendasi> repositoriKolaboratorRekomendasi,
        IUnitOfWork unitOfWork,
        ISignInManager signInManager)
    {
        _repositoriDataRiset = repositoriDataRiset;
        _repositoriRekomendasi = repositoriRekomendasi;
        _repositoriKolaboratorDataRiset = repositoriKolaboratorDataRiset;
        _repositoriKolaboratorRekomendasi = repositoriKolaboratorRekomendasi;
        _unitOfWork = unitOfWork;
        _signInManager = signInManager;
    }

    public async Task<IActionResult> ManajemenDataRiset()
    {
        var appUser = await _signInManager.GetUser();
        if (appUser is null || appUser.Role != UserRoles.KOLABORATOR || appUser.Kolaborator is null)
            return StatusCode(StatusCodes.Status403Forbidden);

        return View((await _repositoriDataRiset.GetAll()).Where(x => x.DaftarKolaboratorPenelitian.Contains(appUser.Kolaborator)).ToList());
    }

    public async Task<IActionResult> ManajemenDataRisetDetail(string id)
    {
        var appUser = await _signInManager.GetUser();
        if (appUser is null || appUser.Role != UserRoles.KOLABORATOR || appUser.Kolaborator is null)
            return StatusCode(StatusCodes.Status403Forbidden);

        var resultId = IdDataRiset.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var dataRiset = await _repositoriDataRiset.Get(resultId.Value);
        if (dataRiset is null) return NotFound();

        var kolaboratorDataRiset = dataRiset.DaftarKolaboratorDataRiset.FirstOrDefault(x => x.Entity2 == appUser.Kolaborator);
        if (kolaboratorDataRiset is null) return NotFound();

        return View(new ManajemenDataRisetDetailVM
        {
            Id = id,
            FeedbackKolaborator = kolaboratorDataRiset.FeedbackKolaborator
        });
    }

    [HttpPost]
    public async Task<IActionResult> ManajemenDataRisetDetail(ManajemenDataRisetDetailVM vm)
    {
        var appUser = await _signInManager.GetUser();
        if (appUser is null || appUser.Role != UserRoles.KOLABORATOR || appUser.Kolaborator is null)
            return StatusCode(StatusCodes.Status403Forbidden);

        var resultId = IdDataRiset.Create(vm.Id);
        if (resultId.IsFailure) return BadRequest();

        var dataRiset = await _repositoriDataRiset.Get(resultId.Value);
        if (dataRiset is null) return NotFound();

        var kolaboratorDataRiset = dataRiset.DaftarKolaboratorDataRiset.FirstOrDefault(x => x.Entity2 == appUser.Kolaborator);
        if (kolaboratorDataRiset is null) return NotFound();

        kolaboratorDataRiset.FeedbackKolaborator = vm.FeedbackKolaborator;
        _repositoriKolaboratorDataRiset.Update(kolaboratorDataRiset);
        var result = await _unitOfWork.SaveChangesAsync();
        if(result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, result.Error.Message);
            return View(vm);
        }

        return RedirectToAction(nameof(ManajemenDataRisetDetail));
    }

    public async Task<IActionResult> RekomendasiDanPengembanganProduk()
    {
        var appUser = await _signInManager.GetUser();
        if (appUser is null || appUser.Role != UserRoles.KOLABORATOR || appUser.Kolaborator is null)
            return StatusCode(StatusCodes.Status403Forbidden);

        return View((await _repositoriRekomendasi.GetAll()).Where(x => x.DaftarKolaborator.Contains(appUser.Kolaborator)).ToList());
    }

    public async Task<IActionResult> RekomendasiDanPengembanganProdukDetail(string id)
    {
        var appUser = await _signInManager.GetUser();
        if (appUser is null || appUser.Role != UserRoles.KOLABORATOR || appUser.Kolaborator is null)
            return StatusCode(StatusCodes.Status403Forbidden);

        var resultId = IdRekomendasi.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var rekomendasi = await _repositoriRekomendasi.Get(resultId.Value);
        if (rekomendasi is null) return NotFound();

        var kolaboratorRekomendasi = rekomendasi.DaftarKolaboratorRekomendasi.FirstOrDefault(x => x.Entity2 == appUser.Kolaborator);
        if (kolaboratorRekomendasi is null) return NotFound();

        return View(new RekomendasiDanPengembanganProdukDetailVM
        {
            Id = id,
            FeedbackKolaborator = kolaboratorRekomendasi.FeedbackKolaborator
        });
    }

    [HttpPost]
    public async Task<IActionResult> RekomendasiDanPengembanganProdukDetail(RekomendasiDanPengembanganProdukDetailVM vm)
    {
        var appUser = await _signInManager.GetUser();
        if (appUser is null || appUser.Role != UserRoles.KOLABORATOR || appUser.Kolaborator is null)
            return StatusCode(StatusCodes.Status403Forbidden);

        var resultId = IdRekomendasi.Create(vm.Id);
        if (resultId.IsFailure) return BadRequest();

        var rekomendasi = await _repositoriRekomendasi.Get(resultId.Value);
        if (rekomendasi is null) return NotFound();

        var kolaboratorRekomendasi = rekomendasi.DaftarKolaboratorRekomendasi.FirstOrDefault(x => x.Entity2 == appUser.Kolaborator);
        if (kolaboratorRekomendasi is null) return NotFound();

        kolaboratorRekomendasi.FeedbackKolaborator = vm.FeedbackKolaborator;
        _repositoriKolaboratorRekomendasi.Update(kolaboratorRekomendasi);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, result.Error.Message);
            return View(vm);
        }

        return RedirectToAction(nameof(RekomendasiDanPengembanganProdukDetail));
    }
}