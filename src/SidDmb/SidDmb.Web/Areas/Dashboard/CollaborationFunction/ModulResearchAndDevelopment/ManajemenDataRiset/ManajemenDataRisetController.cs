using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Authentication;
using SidDmb.Domain.CollaborationFunction;
using SidDmb.Domain.CollaborationFunction.ModulResearchAndDevelopment.ManajemenDataRiset;
using SidDmb.Infrastructure.Services.FileUpload;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulResearchAndDevelopment.ManajemenDataRiset;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.ADMIN)]
public class ManajemenDataRisetController : Controller
{
    private readonly IRepositoriDataRiset _repositoriDataRiset;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepositoriKolaborator _repositoriKolaborator;
    private readonly IFileService _fileService;

    public ManajemenDataRisetController(
        IRepositoriDataRiset repositoriDataRiset,
        IUnitOfWork unitOfWork,
        IRepositoriKolaborator repositoriKolaborator,
        IFileService fileService)
    {
        _repositoriDataRiset = repositoriDataRiset;
        _unitOfWork = unitOfWork;
        _repositoriKolaborator = repositoriKolaborator;
        _fileService = fileService;
    }

    public async Task<IActionResult> Index() => View(await _repositoriDataRiset.GetAll());

    public IActionResult Tambah() => View(new TambahVM());

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var fileResult = await _fileService.UploadFile<TambahVM>(vm.DokumenPenelitian, "/data_riset", [".pdf"], 0, long.MaxValue);
        if (fileResult.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.DokumenPenelitian), fileResult.Error.Message);
            return View(vm);
        }

        List<Kolaborator> daftarKolaborator = [];
        foreach (var kolaboratorId in vm.DaftarKolaboratorId)
        {
            var kolaborator = await _repositoriKolaborator.Get(kolaboratorId);
            if (kolaborator is null)
            {
                ModelState.AddModelError(nameof(TambahVM.DaftarKolaboratorId), $"Kolaborator dengan Id '{kolaboratorId}' tidak ditemukan");
                return View(vm);
            }

            daftarKolaborator.Add(kolaborator);
        }

        var dataRiset = new DataRiset
        {
            Id = await IdDataRiset.Generate(_repositoriDataRiset),
            JudulPenelitian = vm.JudulPenelitian,
            DekripsiPenelitian = vm.DekripsiPenelitian,
            EntitasPeneliti = vm.EntitasPeneliti,
            HasilPenelitian = vm.HasilPenelitian,
            KategoriPenelitian = vm.KategoriPenelitian,
            ManfaatPenelitian = vm.ManfaatPenelitian,
            MetodePengumpulanData = vm.MetodePengumpulanData,
            TanggalMulaiPenelitian = vm.TanggalMulaiPenelitian,
            TanggalSelesaiPenelitian = vm.TanggalSelesaiPenelitian,
            StatusPenelitian = vm.StatusPenelitian,
            DaftarJenisDataRiset = vm.DaftarJenisDataRiset,
            DokumenPenelitian = fileResult.Value,
            DaftarKolaboratorPenelitian = daftarKolaborator
        };

        _repositoriDataRiset.Add(dataRiset);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, result.Error.Message);
            return View(vm);
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(string id)
    {
        var resultId = IdDataRiset.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var dataRiset = await _repositoriDataRiset.Get(resultId.Value);
        if (dataRiset is null) return NotFound();

        return View(new EditVM
        {
            Id = id,
            JudulPenelitian = dataRiset.JudulPenelitian,
            DekripsiPenelitian = dataRiset.DekripsiPenelitian,
            EntitasPeneliti = dataRiset.EntitasPeneliti,
            HasilPenelitian = dataRiset.HasilPenelitian,
            KategoriPenelitian = dataRiset.KategoriPenelitian,
            ManfaatPenelitian = dataRiset.ManfaatPenelitian,
            MetodePengumpulanData = dataRiset.MetodePengumpulanData,
            TanggalMulaiPenelitian = dataRiset.TanggalMulaiPenelitian,
            TanggalSelesaiPenelitian = dataRiset.TanggalSelesaiPenelitian,
            StatusPenelitian = dataRiset.StatusPenelitian,
            DaftarJenisDataRiset = dataRiset.DaftarJenisDataRiset,
            DaftarKolaboratorId = dataRiset.DaftarKolaboratorPenelitian.Select(x => x.Id).ToArray(),
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        var resultId = IdDataRiset.Create(vm.Id);
        if (resultId.IsFailure) return BadRequest();

        var dataRiset = await _repositoriDataRiset.Get(resultId.Value);
        if (dataRiset is null) return NotFound();

        if (vm.DokumenPenelitian is not null)
        {
            var fileResult = await _fileService.UploadFile<TambahVM>(vm.DokumenPenelitian, "/data_riset", [".pdf"], 0, long.MaxValue);
            if (fileResult.IsFailure)
            {
                ModelState.AddModelError(nameof(TambahVM.DokumenPenelitian), fileResult.Error.Message);
                return View(vm);
            }
            dataRiset.DokumenPenelitian = fileResult.Value;
        }

        List<Kolaborator> daftarKolaborator = [];
        foreach (var kolaboratorId in vm.DaftarKolaboratorId)
        {
            var kolaborator = await _repositoriKolaborator.Get(kolaboratorId);
            if (kolaborator is null)
            {
                ModelState.AddModelError(nameof(TambahVM.DaftarKolaboratorId), $"Kolaborator dengan Id '{kolaboratorId}' tidak ditemukan");
                return View(vm);
            }

            daftarKolaborator.Add(kolaborator);
        }

        dataRiset.JudulPenelitian = vm.JudulPenelitian;
        dataRiset.DekripsiPenelitian = vm.DekripsiPenelitian;
        dataRiset.EntitasPeneliti = vm.EntitasPeneliti;
        dataRiset.HasilPenelitian = vm.HasilPenelitian;
        dataRiset.KategoriPenelitian = vm.KategoriPenelitian;
        dataRiset.ManfaatPenelitian = vm.ManfaatPenelitian;
        dataRiset.MetodePengumpulanData = vm.MetodePengumpulanData;
        dataRiset.TanggalMulaiPenelitian = vm.TanggalMulaiPenelitian;
        dataRiset.TanggalSelesaiPenelitian = vm.TanggalSelesaiPenelitian;
        dataRiset.StatusPenelitian = vm.StatusPenelitian;
        dataRiset.DaftarJenisDataRiset = vm.DaftarJenisDataRiset;
        dataRiset.DaftarKolaboratorPenelitian = daftarKolaborator;

        _repositoriDataRiset.Update(dataRiset);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, result.Error.Message);
            return View(vm);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Hapus(string id)
    {
        var resultId = IdDataRiset.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var dataRiset = await _repositoriDataRiset.Get(resultId.Value);
        if (dataRiset is null) return NotFound();

        _repositoriDataRiset.Delete(dataRiset);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure) return StatusCode(StatusCodes.Status500InternalServerError);

        return RedirectToAction(nameof(Index));
    }
}