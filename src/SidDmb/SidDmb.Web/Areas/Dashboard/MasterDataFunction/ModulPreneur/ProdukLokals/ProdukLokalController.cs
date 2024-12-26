using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Algorithm;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Authentication;
using SidDmb.Domain.MasterDataFunction.ModulPreneur.ProdukLokals;
using SidDmb.Domain.MasterDataFunction.ModulPreneur.UnitUsahas;
using SidDmb.Infrastructure.Services.FileUpload;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulPreneur.ProdukLokals;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.ADMIN)]
public class ProdukLokalController : Controller
{
    private readonly IRepositoriProdukLokal _repositoriProdukLokal;
    private readonly IRepositoriUnitUsaha _repositoriUnitUsaha;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileService _fileService;

    public ProdukLokalController(
        IRepositoriProdukLokal repositoriProdukLokal,
        IRepositoriUnitUsaha repositoriUnitUsaha,
        IUnitOfWork unitOfWork,
        IFileService fileService)
    {
        _repositoriProdukLokal = repositoriProdukLokal;
        _unitOfWork = unitOfWork;
        _fileService = fileService;
        _repositoriUnitUsaha = repositoriUnitUsaha;
    }

    public async Task<IActionResult> Index() => View(await _repositoriProdukLokal.GetAll());

    public IActionResult Tambah() => View(new TambahVM());

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var resultIdUnitUsaha = IdUnitUsaha.Create(vm.UnitUsahaId);
        if(resultIdUnitUsaha.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.UnitUsahaId), $"Unit Usaha dengan Id '{vm.UnitUsahaId}' tidak ditemukan");
            return View(vm);
        }

        var unitUsaha = await _repositoriUnitUsaha.Get(resultIdUnitUsaha.Value);
        if (unitUsaha is null) 
        {
            ModelState.AddModelError(nameof(TambahVM.UnitUsahaId), $"Unit Usaha dengan Id '{vm.UnitUsahaId}' tidak ditemukan");
            return View(vm);
        }

        var fileResult = await _fileService.UploadFile<TambahVM>(vm.MediaPromosi, "/produk_lokal", [".jpeg", ".jpg", ".png"], 0, long.MaxValue);
        if(fileResult.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.MediaPromosi), fileResult.Error.Message);
            return View(vm);
        }

        var produkLokal = new ProdukLokal
        {
            Id = await IdProduk.Generate(_repositoriProdukLokal),
            BahanUtama = vm.BahanUtama,
            Dekripsi = vm.Dekripsi,
            Harga = vm.Harga,
            Kategori = vm.Kategori,
            KontakInformasi = vm.KontakInformasi,
            LegalitasDanSertifikat = vm.LegalitasDanSertifikat,
            StatusKetersediaan = vm.StatusKetersediaan,
            MediaPromosi = fileResult.Value,
            Nama = vm.Nama,
            TanggalKadaluarsa = vm.TanggalKadaluarsa,
            TanggalProduksiTerakhir = vm.TanggalProduksiTerakhir,
            UnitUsaha = unitUsaha
        };

        unitUsaha.DaftarProduk.Add(produkLokal);

        _repositoriProdukLokal.Add(produkLokal);
        _repositoriUnitUsaha.Update(unitUsaha);
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
        var resultId = IdProduk.Create(id);
        if (resultId.IsFailure) return NotFound();

        var produkLokal = await _repositoriProdukLokal.Get(resultId.Value);
        if(produkLokal is null) return NotFound();

        return View(new EditVM
        {
            Id = id,
            Nama = produkLokal.Nama,
            BahanUtama = produkLokal.BahanUtama,
            Dekripsi = produkLokal.Dekripsi,
            Harga = produkLokal.Harga,
            Kategori = produkLokal.Kategori,
            KontakInformasi = produkLokal.KontakInformasi,
            LegalitasDanSertifikat = produkLokal.LegalitasDanSertifikat,
            StatusKetersediaan = produkLokal.StatusKetersediaan,
            TanggalKadaluarsa = produkLokal.TanggalKadaluarsa,
            TanggalProduksiTerakhir = produkLokal.TanggalProduksiTerakhir,
            UnitUsahaId = produkLokal.UnitUsaha.Id.Value
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var resultId = IdProduk.Create(vm.Id);
        if (resultId.IsFailure) return NotFound();

        var produkLokal = await _repositoriProdukLokal.Get(resultId.Value);
        if (produkLokal is null) return NotFound();

        var resultIdUnitUsaha = IdUnitUsaha.Create(vm.UnitUsahaId);
        if (resultIdUnitUsaha.IsFailure)
        {
            ModelState.AddModelError(nameof(EditVM.UnitUsahaId), $"Unit Usaha dengan Id '{vm.UnitUsahaId}' tidak ditemukan");
            return View(vm);
        }

        var unitUsaha = await _repositoriUnitUsaha.Get(resultIdUnitUsaha.Value);
        if (unitUsaha is null)
        {
            ModelState.AddModelError(nameof(EditVM.UnitUsahaId), $"Unit Usaha dengan Id '{vm.UnitUsahaId}' tidak ditemukan");
            return View(vm);
        }

        produkLokal.UnitUsaha = unitUsaha;
        if(!unitUsaha.DaftarProduk.Contains(produkLokal))
            unitUsaha.DaftarProduk.Add(produkLokal);

        if (vm.MediaPromosiBaru is not null)
        {
            var fileResult = await _fileService.UploadFile<EditVM>(vm.MediaPromosiBaru, "/produk_lokal", [".jpeg", ".jpg", ".png"], 0, long.MaxValue);
            if (fileResult.IsFailure)
            {
                ModelState.AddModelError(nameof(EditVM.MediaPromosiBaru), fileResult.Error.Message);
                return View(vm);
            }

            produkLokal.MediaPromosi = fileResult.Value;
        }

        produkLokal.Nama = vm.Nama;
        produkLokal.BahanUtama = vm.BahanUtama;
        produkLokal.Dekripsi = vm.Dekripsi;
        produkLokal.Harga = vm.Harga;
        produkLokal.Kategori = vm.Kategori;
        produkLokal.KontakInformasi = vm.KontakInformasi;
        produkLokal.LegalitasDanSertifikat = vm.LegalitasDanSertifikat;
        produkLokal.StatusKetersediaan = vm.StatusKetersediaan;
        produkLokal.TanggalKadaluarsa = vm.TanggalKadaluarsa;
        produkLokal.TanggalProduksiTerakhir = vm.TanggalProduksiTerakhir;

        _repositoriProdukLokal.Update(produkLokal);
        _repositoriUnitUsaha.Update(unitUsaha);

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
        var resultId = IdProduk.Create(id);
        if (resultId.IsFailure) return NotFound();

        var produkLokal = await _repositoriProdukLokal.Get(resultId.Value);
        if (produkLokal is null) return NotFound();

        _repositoriProdukLokal.Delete(produkLokal);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure) return StatusCode(StatusCodes.Status500InternalServerError);

        return RedirectToAction(nameof(Index));
    }
}