using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Authentication;
using SidDmb.Domain.CollaborationFunction;
using SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.ManajemenDistribusi;
using SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.ManajemenProduk;
using SidDmb.Infrastructure.Services.FileUpload;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulProdukDanInventory.ManajemenDistribusi;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.ADMIN)]
public class ManajemenDistribusiController : Controller
{
    private readonly IRepositoriDistribusi _repositoriDistribusi;
    private readonly IRepositoriProduk _repositoriProduk;
    private readonly IRepositoriKolaborator _repositoriKolaborator;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileService _fileService;

    public ManajemenDistribusiController(
        IRepositoriDistribusi repositoriDistribusi,
        IRepositoriKolaborator repositoriKolaborator,
        IRepositoriProduk repositoriProduk,
        IUnitOfWork unitOfWork,
        IFileService fileService)
    {
        _repositoriDistribusi = repositoriDistribusi;
        _repositoriKolaborator = repositoriKolaborator;
        _repositoriProduk = repositoriProduk;
        _unitOfWork = unitOfWork;
        _fileService = fileService;
    }

    public async Task<IActionResult> Index() => View(await _repositoriDistribusi.GetAll());

    public IActionResult Tambah() => View(new TambahVM());

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if(!ModelState.IsValid) return View(vm);

        var fileResult = await _fileService.UploadFile<TambahVM>(vm.DokumenPengiriman, "/distribusi", [".pdf"], 0, long.MaxValue);
        if (fileResult.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.DokumenPengiriman), fileResult.Error.Message);
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

        var produkResult = IdProduk.Create(vm.ProdukId);
        if(produkResult.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.ProdukId), produkResult.Error.Message);
            return View(vm);
        }

        var produk = await _repositoriProduk.Get(produkResult.Value);
        if(produk is null)
        {
            ModelState.AddModelError(nameof(TambahVM.ProdukId), $"Produk dengan Id '{vm.ProdukId}' tidak ditemukan");
            return View(vm);
        }

        var distribusi = new Distribusi
        {
            Id = await IdDistribusi.Generate(_repositoriDistribusi),
            NamaDistributor = vm.NamaDistributor,
            AlamatTujuan = vm.AlamatTujuan,
            BiayaPengiriman = vm.BiayaPengiriman,
            JumlahProduk = vm.JumlahProduk,
            KontakDistributor = vm.KontakDistributor,
            TanggalPengiriman = vm.TanggalPengiriman,
            DokumenPengiriman = fileResult.Value,
            Produk = produk,
            DaftarKolaborator = daftarKolaborator
        };

        _repositoriDistribusi.Add(distribusi);
        var result = await _unitOfWork.SaveChangesAsync();
        if(result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, result.Error.Message);
            return View(vm);
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(string id)
    {
        var resultId = IdDistribusi.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var distribusi = await _repositoriDistribusi.Get(resultId.Value);
        if (distribusi is null) return NotFound();

        return View(new EditVM
        {
            Id = id,
            AlamatTujuan = distribusi.AlamatTujuan,
            BiayaPengiriman = distribusi.BiayaPengiriman,
            JumlahProduk = distribusi.JumlahProduk,
            KontakDistributor = distribusi.KontakDistributor,
            NamaDistributor = distribusi.NamaDistributor,
            TanggalPengiriman = distribusi.TanggalPengiriman,
            ProdukId = distribusi.Produk.Id.Value,
            DaftarKolaboratorId = distribusi.DaftarKolaborator.Select(x => x.Id).ToArray(),
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        var resultId = IdDistribusi.Create(vm.Id);
        if (resultId.IsFailure) return BadRequest();

        var distribusi = await _repositoriDistribusi.Get(resultId.Value);
        if (distribusi is null) return NotFound();

        if(vm.DokumenPengiriman is not null)
        {
            var fileResult = await _fileService.UploadFile<EditVM>(vm.DokumenPengiriman, "/distribusi", [".pdf"], 0, long.MaxValue);
            if (fileResult.IsFailure)
            {
                ModelState.AddModelError(nameof(EditVM.DokumenPengiriman), fileResult.Error.Message);
                return View(vm);
            }
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

        var produkResult = IdProduk.Create(vm.ProdukId);
        if (produkResult.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.ProdukId), produkResult.Error.Message);
            return View(vm);
        }

        var produk = await _repositoriProduk.Get(produkResult.Value);
        if (produk is null)
        {
            ModelState.AddModelError(nameof(TambahVM.ProdukId), $"Produk dengan Id '{vm.ProdukId}' tidak ditemukan");
            return View(vm);
        }

        distribusi.AlamatTujuan = vm.AlamatTujuan;
        distribusi.BiayaPengiriman = vm.BiayaPengiriman;
        distribusi.JumlahProduk = vm.JumlahProduk;
        distribusi.KontakDistributor = vm.KontakDistributor;
        distribusi.NamaDistributor = vm.NamaDistributor;
        distribusi.TanggalPengiriman = vm.TanggalPengiriman;
        distribusi.Produk = produk;
        distribusi.DaftarKolaborator = daftarKolaborator;

        _repositoriDistribusi.Update(distribusi);
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
        var resultId = IdDistribusi.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var distribusi = await _repositoriDistribusi.Get(resultId.Value);
        if (distribusi is null) return NotFound();

        _repositoriDistribusi.Delete(distribusi);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure) return StatusCode(StatusCodes.Status500InternalServerError);

        return RedirectToAction(nameof(Index));
    }
}
