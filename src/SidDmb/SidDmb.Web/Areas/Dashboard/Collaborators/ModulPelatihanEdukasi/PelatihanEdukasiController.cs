using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Authentication;
using SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi.MateriEdukasiDanPembelajaran;
using SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi.PeningkatanKapasitas;
using SidDmb.Infrastructure.Migrations;
using SidDmb.Web.Authentication;
using System.Security.Cryptography;

namespace SidDmb.Web.Areas.Dashboard.Collaborators.ModulPelatihanEdukasi;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.KOLABORATOR)]
public class PelatihanEdukasiController : Controller
{
    private readonly IRepositoriMateri _repositoriMateri;
    private readonly IRepositoriPelatihan _repositoriPelatihan;
    private readonly IJoinEntityRepository<KolaboratorMateri> _repositoriKolaboratorMateri;
    private readonly IJoinEntityRepository<KolaboratorPelatihan> _repositoriKolaboratorPelatihan;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISignInManager _signInManager;

    public PelatihanEdukasiController(
        IRepositoriMateri repositoriMateri,
        IRepositoriPelatihan repositoriPelatihan,
        IJoinEntityRepository<KolaboratorMateri> repositoriKolaboratorMateri,
        IJoinEntityRepository<KolaboratorPelatihan> repositoriKolaboratorPelatihan,
        IUnitOfWork unitOfWork,
        ISignInManager signInManager)
    {
        _repositoriMateri = repositoriMateri;
        _repositoriPelatihan = repositoriPelatihan;
        _repositoriKolaboratorMateri = repositoriKolaboratorMateri;
        _repositoriKolaboratorPelatihan = repositoriKolaboratorPelatihan;
        _unitOfWork = unitOfWork;
        _signInManager = signInManager;
    }

    public async Task<IActionResult> MateriEdukasi()
    {
        var appUser = await _signInManager.GetUser();
        if (appUser is null || appUser.Role != UserRoles.KOLABORATOR || appUser.Kolaborator is null)
            return StatusCode(StatusCodes.Status403Forbidden);

        return View((await _repositoriMateri.GetAll()).Where(x => x.DaftarKolaborator.Contains(appUser.Kolaborator)).ToList());
    }

    public async Task<IActionResult> MateriEdukasiDetail(string id)
    {
        var appUser = await _signInManager.GetUser();
        if (appUser is null || appUser.Role != UserRoles.KOLABORATOR || appUser.Kolaborator is null)
            return StatusCode(StatusCodes.Status403Forbidden);

        var resultId = IdMateri.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var materi = await _repositoriMateri.Get(resultId.Value);
        if (materi is null) return NotFound();

        var kolaboratorMateri = materi.DaftarKolaboratorMateri.FirstOrDefault(x => x.Entity2 == appUser.Kolaborator);
        if (kolaboratorMateri is null) return NotFound();

        return View(new MateriEdukasiDetailVM
        {
            Id = id,
            RekomendasiPembaruanMateri = kolaboratorMateri.RekomendasiPembaruanMateri
        });
    }

    [HttpPost]
    public async Task<IActionResult> MateriEdukasiDetail(MateriEdukasiDetailVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var appUser = await _signInManager.GetUser();
        if (appUser is null || appUser.Role != UserRoles.KOLABORATOR || appUser.Kolaborator is null)
            return StatusCode(StatusCodes.Status403Forbidden);

        var resultId = IdMateri.Create(vm.Id);
        if (resultId.IsFailure) return BadRequest();

        var materi = await _repositoriMateri.Get(resultId.Value);
        if (materi is null) return NotFound();

        var kolaboratorMateri = materi.DaftarKolaboratorMateri.FirstOrDefault(x => x.Entity2 == appUser.Kolaborator);
        if (kolaboratorMateri is null) return NotFound();

        kolaboratorMateri.RekomendasiPembaruanMateri = vm.RekomendasiPembaruanMateri;

        _repositoriKolaboratorMateri.Update(kolaboratorMateri);
        var result = await _unitOfWork.SaveChangesAsync();
        if(result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, result.Error.Message);
            return View(vm);
        }

        return RedirectToAction(nameof(MateriEdukasi));
    }

    public async Task<IActionResult> PeningkatanEdukasi()
    {
        var appUser = await _signInManager.GetUser();
        if (appUser is null || appUser.Role != UserRoles.KOLABORATOR || appUser.Kolaborator is null)
            return StatusCode(StatusCodes.Status403Forbidden);

        return View((await _repositoriPelatihan.GetAll()).Where(x => x.DaftarKolaborator.Contains(appUser.Kolaborator)).ToList());
    }

    public async Task<IActionResult> PeningkatanEdukasiDetail(string id)
    {
        var appUser = await _signInManager.GetUser();
        if (appUser is null || appUser.Role != UserRoles.KOLABORATOR || appUser.Kolaborator is null)
            return StatusCode(StatusCodes.Status403Forbidden);

        var resultId = IdPelatihan.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var pelatihan = await _repositoriPelatihan.Get(resultId.Value);
        if (pelatihan is null) return NotFound();

        var kolaboratorPelatihan = pelatihan.DaftarKolaboratorPelatihan.FirstOrDefault(x => x.Entity2 == appUser.Kolaborator);
        if (kolaboratorPelatihan is null) return NotFound();

        return View(new PeningkatanEdukasiDetailVM
        {
            Id = id,
            RekomendasiUntukPelatihanBerikutnya = kolaboratorPelatihan.RekomendasiUntukPelatihanBerikutnya
        });
    }

    [HttpPost]
    public async Task<IActionResult> PeningkatanEdukasiDetail(PeningkatanEdukasiDetailVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var appUser = await _signInManager.GetUser();
        if (appUser is null || appUser.Role != UserRoles.KOLABORATOR || appUser.Kolaborator is null)
            return StatusCode(StatusCodes.Status403Forbidden);

        var resultId = IdPelatihan.Create(vm.Id);
        if (resultId.IsFailure) return BadRequest();

        var pelatihan = await _repositoriPelatihan.Get(resultId.Value);
        if (pelatihan is null) return NotFound();

        var kolaboratorPelatihan = pelatihan.DaftarKolaboratorPelatihan.FirstOrDefault(x => x.Entity2 == appUser.Kolaborator);
        if (kolaboratorPelatihan is null) return NotFound();

        kolaboratorPelatihan.RekomendasiUntukPelatihanBerikutnya = vm.RekomendasiUntukPelatihanBerikutnya;

        _repositoriKolaboratorPelatihan.Update(kolaboratorPelatihan);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, result.Error.Message);
            return View(vm);
        }

        return RedirectToAction(nameof(MateriEdukasi));
    }
}