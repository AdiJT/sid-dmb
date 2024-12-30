using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Authentication;
using SidDmb.Domain.CollaborationFunction.ModulManajemenEvent.PelaporanDanDokumentasi;
using SidDmb.Domain.CollaborationFunction.ModulManajemenEvent.PengelolaanEvent;
using SidDmb.Web.Authentication;

namespace SidDmb.Web.Areas.Dashboard.Collaborators.ModulManajemenEvent;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.KOLABORATOR)]
public class ManajemenEventController : Controller
{
    private readonly IRepositoriEvent _repositoriEvent;
    private readonly IRepositoriLaporanEvent _repositoriLaporanEvent;
    private readonly IJoinEntityRepository<KolaboratorEvent> _joinEntityRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISignInManager _signInManager;

    public ManajemenEventController(
        IRepositoriEvent repositoriEvent,
        IRepositoriLaporanEvent repositoriLaporanEvent,
        IJoinEntityRepository<KolaboratorEvent> joinEntityRepository,
        IUnitOfWork unitOfWork,
        ISignInManager signInManager)
    {
        _repositoriEvent = repositoriEvent;
        _repositoriLaporanEvent = repositoriLaporanEvent;
        _joinEntityRepository = joinEntityRepository;
        _unitOfWork = unitOfWork;
        _signInManager = signInManager;
    }

    public async Task<IActionResult> PengelolaanEvent()
    {
        var appUser = await _signInManager.GetUser();
        if (appUser is null || appUser.Role != UserRoles.KOLABORATOR || appUser.Kolaborator is null)
            return StatusCode(StatusCodes.Status403Forbidden);

        var daftarEvent = (await _repositoriEvent.GetAll()).Where(x => x.DaftarKolaborator.Contains(appUser.Kolaborator)).ToList();

        return View(daftarEvent);
    }

    public async Task<IActionResult> PelaporanDanDokumentasi()
    {
        var appUser = await _signInManager.GetUser();
        if (appUser is null || appUser.Role != UserRoles.KOLABORATOR || appUser.Kolaborator is null)
            return StatusCode(StatusCodes.Status403Forbidden);

        var daftarLaporanEvent = (await _repositoriLaporanEvent.GetAll())
            .Where(x => x.Event.DaftarKolaborator.Contains(appUser.Kolaborator))
            .ToList();

        return View(daftarLaporanEvent);
    }

    public async Task<IActionResult> PelaporanDanDokumentasiDetail(string id)
    {
        var appUser = await _signInManager.GetUser();
        if (appUser is null || appUser.Role != UserRoles.KOLABORATOR || appUser.Kolaborator is null)
            return StatusCode(StatusCodes.Status403Forbidden);

        var resultId = IdLaporanEvent.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var laporanEvent = await _repositoriLaporanEvent.Get(resultId.Value);
        if (laporanEvent is null) return NotFound();

        var kolaboratorEvent = laporanEvent.Event.DaftarKolaboratorEvent.FirstOrDefault(x => x.Entity2 == appUser.Kolaborator);
        if (kolaboratorEvent is null) return NotFound();

        return View(new PelaporanDanDokumentasiDetailVM
        {
            Id = id,
            MasukanKolaborator = kolaboratorEvent.MasukanKolaborator,
            RekomedasiEventBerikutnya = kolaboratorEvent.RekomedasiEventBerikutnya,
        });
    }

    [HttpPost]
    public async Task<IActionResult> PelaporanDanDokumentasiDetail(PelaporanDanDokumentasiDetailVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var appUser = await _signInManager.GetUser();
        if (appUser is null || appUser.Role != UserRoles.KOLABORATOR || appUser.Kolaborator is null)
            return StatusCode(StatusCodes.Status403Forbidden);

        var resultId = IdLaporanEvent.Create(vm.Id);
        if (resultId.IsFailure) return BadRequest();

        var laporanEvent = await _repositoriLaporanEvent.Get(resultId.Value);
        if (laporanEvent is null) return NotFound();

        var @event = await _repositoriEvent.Get(laporanEvent.Event.Id);
        if (@event is null) return NotFound();

        var kolaboratorEvent = @event.DaftarKolaboratorEvent.FirstOrDefault(x => x.Entity2 == appUser.Kolaborator);
        if (kolaboratorEvent is null) return NotFound();

        kolaboratorEvent.RekomedasiEventBerikutnya = vm.RekomedasiEventBerikutnya;
        kolaboratorEvent.MasukanKolaborator = vm.MasukanKolaborator;

        _joinEntityRepository.Update(kolaboratorEvent);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, result.Error.Message);
            return View(vm);
        }

        return RedirectToAction(nameof(PelaporanDanDokumentasi));
    }
}