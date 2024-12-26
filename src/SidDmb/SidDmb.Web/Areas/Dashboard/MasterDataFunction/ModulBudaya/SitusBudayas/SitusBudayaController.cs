using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Authentication;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.SitusBudayas;
using SidDmb.Infrastructure.Services.FileUpload;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulBudaya.SitusBudayas;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.ADMIN)]
public class SitusBudayaController : Controller
{
    private readonly IRepositoriSitusBudaya _repositoriSitusBudaya;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileService _fileService;

    public SitusBudayaController(
        IRepositoriSitusBudaya repositoriSitusBudaya,
        IUnitOfWork unitOfWork,
        IFileService fileService)
    {
        _repositoriSitusBudaya = repositoriSitusBudaya;
        _unitOfWork = unitOfWork;
        _fileService = fileService;
    }

    public async Task<IActionResult> Index() => View(await _repositoriSitusBudaya.GetAll());

    public IActionResult Tambah() => View(new TambahVM());

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if(!ModelState.IsValid) return View(vm);

        var fileResult = await _fileService.UploadFile<TambahVM>(vm.FotoPromosi, "/situs_budaya", [".jpg", ".jpeg", ".png"], 0, long.MaxValue);
        if(fileResult.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.FotoPromosi), fileResult.Error.Message);
            return View(vm);
        }

        var situsBudaya = new SitusBudaya
        {
            Id = await IdSitus.Generate(_repositoriSitusBudaya),
            Nama = vm.Nama,
            Dekripsi = vm.Dekripsi,
            Alamat = vm.Alamat,
            DaftarFasilitas = vm.DaftarFasilitas,
            FotoPromosi = fileResult.Value,
            HargaTiketMasuk = vm.HargaTiketMasuk,
            JamOperasional = vm.JamOperasional,
            Kategori = vm.Kategori,
            KontakInformasi = vm.KontakInformasi,
            KoordinatLokasi = new Point(vm.Lng, vm.Lat),
            PengelolaSitus = vm.PengelolaSitus,
            PeraturanKhusus = vm.PeraturanKhusus,
            Status = vm.Status
        };
        _repositoriSitusBudaya.Add(situsBudaya);
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
        var resultId = IdSitus.Create(id);
        if (resultId.IsFailure) return NotFound();

        var situsBudaya = await _repositoriSitusBudaya.Get(resultId.Value);
        if (situsBudaya is null) return NotFound();

        return View(new EditVM
        {
            Id = id,
            Nama = situsBudaya.Nama,
            Alamat = situsBudaya.Alamat,
            DaftarFasilitas = situsBudaya.DaftarFasilitas,
            Dekripsi = situsBudaya.Dekripsi,
            HargaTiketMasuk = situsBudaya.HargaTiketMasuk,
            JamOperasional = situsBudaya.JamOperasional,
            Kategori = situsBudaya.Kategori,
            KontakInformasi = situsBudaya.KontakInformasi,
            Lat = situsBudaya.KoordinatLokasi.Y,
            Lng = situsBudaya.KoordinatLokasi.X,
            PengelolaSitus = situsBudaya.PengelolaSitus,
            PeraturanKhusus = situsBudaya.PeraturanKhusus,
            Status = situsBudaya.Status,
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var resultId = IdSitus.Create(vm.Id);
        if (resultId.IsFailure) return NotFound();

        var situsBudaya = await _repositoriSitusBudaya.Get(resultId.Value);
        if (situsBudaya is null) return NotFound();

        if(vm.FotoPromosiBaru is not null)
        {
            var fileResult = await _fileService.UploadFile<EditVM>(vm.FotoPromosiBaru, "/situs_budaya", [".jpg", ".jpeg", ".png"], 0, long.MaxValue);
            if (fileResult.IsFailure)
            {
                ModelState.AddModelError(nameof(EditVM.FotoPromosiBaru), fileResult.Error.Message);
                return View(vm);
            }

            situsBudaya.FotoPromosi = fileResult.Value;
        }

        situsBudaya.Nama = vm.Nama;
        situsBudaya.Alamat = vm.Alamat;
        situsBudaya.DaftarFasilitas = vm.DaftarFasilitas;
        situsBudaya.Dekripsi = vm.Dekripsi;
        situsBudaya.HargaTiketMasuk = vm.HargaTiketMasuk;
        situsBudaya.JamOperasional = vm.JamOperasional;
        situsBudaya.Kategori = vm.Kategori;
        situsBudaya.KontakInformasi = vm.KontakInformasi;
        situsBudaya.PengelolaSitus = vm.PengelolaSitus;
        situsBudaya.PeraturanKhusus = vm.PeraturanKhusus;
        situsBudaya.Status = vm.Status;
        situsBudaya.KoordinatLokasi = new Point(vm.Lng, vm.Lat);

        _repositoriSitusBudaya.Update(situsBudaya);
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
        var resultId = IdSitus.Create(id);
        if (resultId.IsFailure) return NotFound();

        var situsBudaya = await _repositoriSitusBudaya.Get(resultId.Value);
        if (situsBudaya is null) return NotFound();

        _repositoriSitusBudaya.Delete(situsBudaya);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure) return BadRequest();

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Komentar(string id)
    {
        var resultId = IdSitus.Create(id);
        if (resultId.IsFailure) return NotFound();

        var situsBudaya = await _repositoriSitusBudaya.Get(resultId.Value);
        if(situsBudaya is null) return NotFound();

        return PartialView("_KomentarPartial", situsBudaya.DaftarKomentar);
    }
}