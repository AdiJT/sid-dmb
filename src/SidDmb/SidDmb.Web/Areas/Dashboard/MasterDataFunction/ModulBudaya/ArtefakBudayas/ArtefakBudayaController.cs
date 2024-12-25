using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Authentication;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.ArtefakBudayas;
using SidDmb.Infrastructure.Services.FileUpload;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulBudaya.ArtefakBudayas;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.ADMIN)]
public class ArtefakBudayaController : Controller
{
    private readonly IRepositoriArtefakBudaya _repositoriArtefakBudaya;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileService _fileService;

    public ArtefakBudayaController(
        IRepositoriArtefakBudaya repositoriArtefakBudaya,
        IUnitOfWork unitOfWork,
        IFileService fileService)
    {
        _repositoriArtefakBudaya = repositoriArtefakBudaya;
        _unitOfWork = unitOfWork;
        _fileService = fileService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _repositoriArtefakBudaya.GetAll());
    }

    public IActionResult Tambah()
    {
        return View(new TambahVM());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var fileResult = await _fileService.UploadFile<TambahVM>(vm.Foto, "/artefak_budaya", [".jpg", ".jpeg", ".png"], 0, long.MaxValue);
        if (fileResult.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.Foto), fileResult.Error.Message);
            return View(vm);
        }

        var artefakBudaya = new ArtefakBudaya
        {
            Id = await IdArtefak.Generate(_repositoriArtefakBudaya),
            Nama = vm.Nama,
            Dekripsi = vm.Dekripsi,
            Kategori = vm.Kategori,
            Bahan = vm.Bahan,
            Dimensi = vm.Dimensi,
            Foto = fileResult.Value,
            Ketersediaan = vm.Ketersediaan,
            Kondisi = vm.Kondisi,
            LokasiPenyimpanan = vm.LokasiPenyimpanan,
            NilaiHistoris = vm.NilaiHistoris,
            Pengelola = vm.Pengelola,
            Usia = vm.Usia,
        };

        _repositoriArtefakBudaya.Add(artefakBudaya);
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
        var resultId = IdArtefak.Create(id);
        if (resultId.IsFailure) return NotFound();

        var artefak = await _repositoriArtefakBudaya.Get(resultId.Value);
        if (artefak is null) return NotFound();

        return View(new EditVM
        {
            Id = id,
            Nama = artefak.Nama,
            Dekripsi = artefak.Dekripsi,
            Bahan = artefak.Bahan,
            Dimensi = artefak.Bahan,
            Foto = artefak.Foto,
            Kategori = artefak.Kategori,
            Ketersediaan = artefak.Ketersediaan,
            Kondisi = artefak.Kondisi,
            LokasiPenyimpanan = artefak.LokasiPenyimpanan,
            NilaiHistoris = artefak.NilaiHistoris,
            Pengelola = artefak.Pengelola,
            Usia = artefak.Usia,
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var resultId = IdArtefak.Create(vm.Id);
        if (resultId.IsFailure)
        {
            ModelState.AddModelError(string.Empty, resultId.Error.Message);
            return View(vm);
        }

        var artefak = await _repositoriArtefakBudaya.Get(resultId.Value);
        if (artefak is null) return NotFound();

        if (vm.FotoBaru is not null)
        {
            var fileResult = await _fileService.UploadFile<EditVM>(vm.FotoBaru, "/artefak_budaya", [".jpg", ".jpeg", ".png"], 0, long.MaxValue);
            if (fileResult.IsFailure)
            {
                ModelState.AddModelError(nameof(EditVM.FotoBaru), fileResult.Error.Message);
                return View(vm);
            }

            artefak.Foto = fileResult.Value;
        }

        artefak.Nama = vm.Nama;
        artefak.Dekripsi = vm.Dekripsi;
        artefak.Bahan = vm.Bahan;
        artefak.Dimensi = vm.Bahan;
        artefak.Kategori = vm.Kategori;
        artefak.Ketersediaan = vm.Ketersediaan;
        artefak.Kondisi = vm.Kondisi;
        artefak.LokasiPenyimpanan = vm.LokasiPenyimpanan;
        artefak.NilaiHistoris = vm.NilaiHistoris;
        artefak.Pengelola = vm.Pengelola;
        artefak.Usia = vm.Usia;

        _repositoriArtefakBudaya.Update(artefak);
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
        var resultId = IdArtefak.Create(id);
        if (resultId.IsFailure) return NotFound();

        var artefak = await _repositoriArtefakBudaya.Get(resultId.Value);
        if (artefak is null) return NotFound();

        _repositoriArtefakBudaya.Delete(artefak);
        var result = await _unitOfWork.SaveChangesAsync();

        if (result.IsFailure) return BadRequest();

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Komentar(string id)
    {
        var resultId = IdArtefak.Create(id);
        if (resultId.IsFailure) return NotFound();

        var artefak = await _repositoriArtefakBudaya.Get(resultId.Value);
        if (artefak is null) return NotFound();

        return PartialView("_KomentarPartial", artefak.DaftarKomentar);
    }
}