using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Authentication;
using SidDmb.Domain.CollaborationFunction;
using SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.ManajemenProduk;
using SidDmb.Infrastructure.Services.FileUpload;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulProdukDanInventory.ManajemenProduk;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.ADMIN)]
public class ManajemenProdukController : Controller
{
    private readonly IRepositoriProduk _repositoriProduk;
    private readonly IRepositoriKolaborator _repositoriKolaborator;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileService _fileService;

    public ManajemenProdukController(
        IRepositoriProduk repositoriProduk,
        IRepositoriKolaborator repositoriKolaborator,
        IUnitOfWork unitOfWork,
        IFileService fileService)
    {
        _repositoriProduk = repositoriProduk;
        _repositoriKolaborator = repositoriKolaborator;
        _unitOfWork = unitOfWork;
        _fileService = fileService;
    }

    public async Task<IActionResult> Index() => View(await _repositoriProduk.GetAll());

    public IActionResult Tambah() => View(new TambahVM());

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var fileResult = await _fileService.UploadFile<TambahVM>(vm.MediaPromosi, "/produk", [".jpg", ".jpeg", ".png"], 0, long.MaxValue);
        if (fileResult.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.MediaPromosi), fileResult.Error.Message);
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

        var produk = new Produk
        {
            Id = await IdProduk.Generate(_repositoriProduk),
            Nama = vm.Nama,
            Dekripsi = vm.Dekripsi,
            HargaProduk = vm.HargaProduk,
            Kategori = vm.Kategori,
            StokAwal = vm.StokAwal,
            StokSaatIni = vm.StokSaatIni,
            StatusKetersediaan = vm.StatusKetersediaan,
            UnitUsahaTerkait = vm.UnitUsahaTerkait,
            TanggalProduksiTerakhir = vm.TanggalProduksiTerakhir,
            TanggalKadaluarsa = vm.TanggalKadaluarsa,
            MediaPromosi = fileResult.Value,
            DaftarKolaborator = daftarKolaborator,
        };

        _repositoriProduk.Add(produk);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, result.Error.Message);
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(string id)
    {
        var resultId = IdProduk.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var produk = await _repositoriProduk.Get(resultId.Value);
        if (produk is null) return NotFound();

        return View(new EditVM
        {
            Id = id,
            Nama = produk.Nama,
            Dekripsi = produk.Dekripsi,
            HargaProduk = produk.HargaProduk,
            Kategori = produk.Kategori,
            StokAwal = produk.StokAwal,
            StokSaatIni = produk.StokSaatIni,
            StatusKetersediaan = produk.StatusKetersediaan,
            UnitUsahaTerkait = produk.UnitUsahaTerkait,
            TanggalProduksiTerakhir = produk.TanggalProduksiTerakhir,
            TanggalKadaluarsa = produk.TanggalKadaluarsa,
            DaftarKolaboratorId = produk.DaftarKolaborator.Select(x => x.Id).ToArray(),
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        var resultId = IdProduk.Create(vm.Id);
        if (resultId.IsFailure) return BadRequest();

        var produk = await _repositoriProduk.Get(resultId.Value);
        if (produk is null) return NotFound();

        if (vm.MediaPromosi is not null)
        {
            var fileResult = await _fileService.UploadFile<EditVM>(vm.MediaPromosi, "/produk", [".jpg", ".jpeg", ".png"], 0, long.MaxValue);
            if (fileResult.IsFailure)
            {
                ModelState.AddModelError(nameof(EditVM.MediaPromosi), fileResult.Error.Message);
                return View(vm);
            }

            produk.MediaPromosi = fileResult.Value;
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

        produk.Nama = vm.Nama;
        produk.Dekripsi = vm.Dekripsi;
        produk.HargaProduk = vm.HargaProduk;
        produk.Kategori = vm.Kategori;
        produk.StokAwal = vm.StokAwal;
        produk.StokSaatIni = vm.StokSaatIni;
        produk.StatusKetersediaan = vm.StatusKetersediaan;
        produk.UnitUsahaTerkait = vm.UnitUsahaTerkait;
        produk.TanggalProduksiTerakhir = vm.TanggalProduksiTerakhir;
        produk.TanggalKadaluarsa = vm.TanggalKadaluarsa;
        produk.DaftarKolaborator = daftarKolaborator;

        _repositoriProduk.Update(produk);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, result.Error.Message);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Hapus(string id)
    {
        var resultId = IdProduk.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var produk = await _repositoriProduk.Get(resultId.Value);
        if (produk is null) return NotFound();

        _repositoriProduk.Delete(produk);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure) return StatusCode(StatusCodes.Status500InternalServerError);

        return RedirectToAction(nameof(Index));
    }
}