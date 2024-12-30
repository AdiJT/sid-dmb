using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Authentication;
using SidDmb.Domain.CollaborationFunction;
using SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.ManajemenProduk;
using SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.SertifikasiDanLegalitas;
using SidDmb.Infrastructure.Services.FileUpload;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulProdukDanInventory.SertifikasiDanLegalitas;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.ADMIN)]
public class SertifikasiController : Controller
{
    private readonly IRepositoriSertifikasi _repositoriSertifikasi;
    private readonly IRepositoriProduk _repositoriProduk;
    private readonly IRepositoriKolaborator _repositoriKolaborator;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileService _fileService;

    public SertifikasiController(
        IRepositoriSertifikasi repositoriSertifikasi,
        IRepositoriProduk repositoriProduk,
        IRepositoriKolaborator repositoriKolaborator,
        IUnitOfWork unitOfWork,
        IFileService fileService)
    {
        _repositoriSertifikasi = repositoriSertifikasi;
        _repositoriProduk = repositoriProduk;
        _repositoriKolaborator = repositoriKolaborator;
        _unitOfWork = unitOfWork;
        _fileService = fileService;
    }

    public async Task<IActionResult> Index() => View(await _repositoriSertifikasi.GetAll());

    public IActionResult Tambah() => View(new TambahVM());

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var fileResult = await _fileService.UploadFile<TambahVM>(vm.DokumenSertifikat, "/sertifikat", [".pdf"], 0, long.MaxValue);
        if (fileResult.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.DokumenSertifikat), fileResult.Error.Message);
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

        var sertifikasi = new Sertifikasi
        {
            Id = await IdSertifikasi.Generate(_repositoriSertifikasi),
            JenisSertifikasi = vm.JenisSertifikasi,
            NomorSertifikasi = vm.NomorSertifikasi,
            PemberiSertifikat = vm.PemberiSertifikat,
            ProsesYangDilalui = vm.ProsesYangDilalui,
            StatusSertifikasi = vm.StatusSertifikasi,
            TanggalPenerbitan = vm.TanggalPenerbitan,
            TanggalKadaluarsa = vm.TanggalKadaluarsa,
            DokumenSertifikat = fileResult.Value,
            DaftarKolaborator = daftarKolaborator,
            Produk = produk
        };
        _repositoriSertifikasi.Add(sertifikasi);
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
        var resultId = IdSertifikasi.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var sertifikasi = await _repositoriSertifikasi.Get(resultId.Value);
        if (sertifikasi is null) return NotFound();

        return View(new EditVM
        {
            Id = id,
            JenisSertifikasi = sertifikasi.JenisSertifikasi,
            NomorSertifikasi = sertifikasi.NomorSertifikasi,
            PemberiSertifikat = sertifikasi.PemberiSertifikat,
            ProsesYangDilalui = sertifikasi.ProsesYangDilalui,
            StatusSertifikasi = sertifikasi.StatusSertifikasi,
            TanggalPenerbitan = sertifikasi.TanggalPenerbitan,
            TanggalKadaluarsa = sertifikasi.TanggalKadaluarsa,
            ProdukId = sertifikasi.Produk.Id.Value,
            DaftarKolaboratorId = sertifikasi.DaftarKolaborator.Select(x => x.Id).ToArray(),
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        var resultId = IdSertifikasi.Create(vm.Id);
        if (resultId.IsFailure) return BadRequest();

        var sertifikasi = await _repositoriSertifikasi.Get(resultId.Value);
        if (sertifikasi is null) return NotFound();

        if (vm.DokumenSertifikat is not null)
        {
            var fileResult = await _fileService.UploadFile<EditVM>(vm.DokumenSertifikat, "/sertifikat", [".pdf"], 0, long.MaxValue);
            if (fileResult.IsFailure)
            {
                ModelState.AddModelError(nameof(EditVM.DokumenSertifikat), fileResult.Error.Message);
                return View(vm);
            }

            sertifikasi.DokumenSertifikat = fileResult.Value;
        }

        List<Kolaborator> daftarKolaborator = [];
        foreach (var kolaboratorId in vm.DaftarKolaboratorId)
        {
            var kolaborator = await _repositoriKolaborator.Get(kolaboratorId);
            if (kolaborator is null)
            {
                ModelState.AddModelError(nameof(EditVM.DaftarKolaboratorId), $"Kolaborator dengan Id '{kolaboratorId}' tidak ditemukan");
                return View(vm);
            }

            daftarKolaborator.Add(kolaborator);
        }

        var produkResult = IdProduk.Create(vm.ProdukId);
        if (produkResult.IsFailure)
        {
            ModelState.AddModelError(nameof(EditVM.ProdukId), produkResult.Error.Message);
            return View(vm);
        }

        var produk = await _repositoriProduk.Get(produkResult.Value);
        if (produk is null)
        {
            ModelState.AddModelError(nameof(EditVM.ProdukId), $"Produk dengan Id '{vm.ProdukId}' tidak ditemukan");
            return View(vm);
        }

        sertifikasi.JenisSertifikasi = vm.JenisSertifikasi;
        sertifikasi.NomorSertifikasi = vm.NomorSertifikasi;
        sertifikasi.PemberiSertifikat = vm.PemberiSertifikat;
        sertifikasi.ProsesYangDilalui = vm.ProsesYangDilalui;
        sertifikasi.StatusSertifikasi = vm.StatusSertifikasi;
        sertifikasi.TanggalPenerbitan = vm.TanggalPenerbitan;
        sertifikasi.TanggalKadaluarsa = vm.TanggalKadaluarsa;
        sertifikasi.Produk = produk;
        sertifikasi.DaftarKolaborator = daftarKolaborator;

        _repositoriSertifikasi.Update(sertifikasi);
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
        var resultId = IdSertifikasi.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var sertifikasi = await _repositoriSertifikasi.Get(resultId.Value);
        if (sertifikasi is null) return NotFound();

        _repositoriSertifikasi.Delete(sertifikasi);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure) return StatusCode(StatusCodes.Status500InternalServerError);

        return RedirectToAction(nameof(Index));
    }
}