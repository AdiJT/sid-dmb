using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Authentication;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.UpacaraBudayas;
using SidDmb.Infrastructure.Services.FileUpload;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulBudaya.UpacaraBudayas;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.ADMIN)]
public class UpacaraBudayaController : Controller
{
    private readonly IRepositoriUpacaraBudaya _repositoriUpacaraBudaya;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileService _fileService;

    public UpacaraBudayaController(
        IRepositoriUpacaraBudaya repositoriUpacaraBudaya,
        IUnitOfWork unitOfWork,
        IFileService fileService)
    {
        _repositoriUpacaraBudaya = repositoriUpacaraBudaya;
        _unitOfWork = unitOfWork;
        _fileService = fileService;
    }

    public async Task<IActionResult> Index() => View(await _repositoriUpacaraBudaya.GetAll());

    public IActionResult Tambah() => View(new TambahVM());

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if(!ModelState.IsValid) return View(vm);

        var fileResult = await _fileService.UploadFile<TambahVM>(vm.MediaPromosi, "/upacara_budaya", [".jpg", ".png", ".jpeg"], 0, long.MaxValue);
        if(fileResult.IsFailure) 
        {
            ModelState.AddModelError(nameof(TambahVM.MediaPromosi), fileResult.Error.Message);
            return View(vm);
        }

        var upacaraBudaya = new UpacaraBudaya
        {
            Id = await IdUpacara.Generate(_repositoriUpacaraBudaya),
            RangkaianAcara = vm.RangkaianAcara,
            Dekripsi = vm.Dekripsi,
            Durasi = vm.Durasi,
            FasilitasPendukung = vm.FasilitasPendukung,
            JumlahPeserta = vm.JumlahPeserta,
            Kategori = vm.Kategori,
            LokasiPelaksanaan = vm.LokasiPelaksanaan,
            MediaPromosi = fileResult.Value,
            Nama = vm.Nama,
            PeraturanKhusus = vm.PeraturanKhusus,
            PihakTerlibat = vm.PihakTerlibat,
            WaktuPelaksanaan = new DateTime(vm.WaktuPelaksanaan.Ticks, DateTimeKind.Unspecified)
        };

        _repositoriUpacaraBudaya.Add(upacaraBudaya);
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
        var resultId = IdUpacara.Create(id);
        if (resultId.IsFailure) return NotFound();

        var upacaraBudaya = await _repositoriUpacaraBudaya.Get(resultId.Value);
        if (upacaraBudaya is null) return NotFound();

        return View(new EditVM
        {
            Id = id,
            Dekripsi = upacaraBudaya.Dekripsi,
            Nama = upacaraBudaya.Nama,
            RangkaianAcara = upacaraBudaya.RangkaianAcara,
            Durasi = upacaraBudaya.Durasi,
            FasilitasPendukung = upacaraBudaya.FasilitasPendukung,
            JumlahPeserta = upacaraBudaya.JumlahPeserta,
            Kategori = upacaraBudaya.Kategori,
            LokasiPelaksanaan = upacaraBudaya.LokasiPelaksanaan,
            PeraturanKhusus = upacaraBudaya.PeraturanKhusus,
            PihakTerlibat = upacaraBudaya.PihakTerlibat,
            WaktuPelaksanaan = upacaraBudaya.WaktuPelaksanaan,
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        var resultId = IdUpacara.Create(vm.Id);
        if (resultId.IsFailure) return NotFound();

        var upacaraBudaya = await _repositoriUpacaraBudaya.Get(resultId.Value);
        if (upacaraBudaya is null) return NotFound();

        if(vm.MediaPromosiBaru is not null)
        {
            var fileResult = await _fileService.UploadFile<EditVM>(vm.MediaPromosiBaru, "/upacara_budaya", [".jpg", ".png", ".jpeg"], 0, long.MaxValue);
            if (fileResult.IsFailure)
            {
                ModelState.AddModelError(nameof(EditVM.MediaPromosiBaru), fileResult.Error.Message);
                return View(vm);
            }

            upacaraBudaya.MediaPromosi = fileResult.Value;
        }

        upacaraBudaya.Dekripsi = vm.Dekripsi;
        upacaraBudaya.Nama = vm.Nama;
        upacaraBudaya.RangkaianAcara = vm.RangkaianAcara;
        upacaraBudaya.Durasi = vm.Durasi;
        upacaraBudaya.FasilitasPendukung = vm.FasilitasPendukung;
        upacaraBudaya.JumlahPeserta = vm.JumlahPeserta;
        upacaraBudaya.Kategori = vm.Kategori;
        upacaraBudaya.LokasiPelaksanaan = vm.LokasiPelaksanaan;
        upacaraBudaya.PeraturanKhusus = vm.PeraturanKhusus;
        upacaraBudaya.PihakTerlibat = vm.PihakTerlibat;
        upacaraBudaya.WaktuPelaksanaan = new DateTime(vm.WaktuPelaksanaan.Ticks, DateTimeKind.Unspecified);

        _repositoriUpacaraBudaya.Update(upacaraBudaya);
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
        var resultId = IdUpacara.Create(id);
        if (resultId.IsFailure) return NotFound();

        var upacaraBudaya = await _repositoriUpacaraBudaya.Get(resultId.Value);
        if (upacaraBudaya is null) return NotFound();

        _repositoriUpacaraBudaya.Delete(upacaraBudaya);

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure) return StatusCode(StatusCodes.Status500InternalServerError);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Komentar(string id)
    {
        var resultId = IdUpacara.Create(id);
        if (resultId.IsFailure) return NotFound();

        var upacaraBudaya = await _repositoriUpacaraBudaya.Get(resultId.Value);
        if (upacaraBudaya is null) return NotFound();

        return PartialView("_KomentarPartial", upacaraBudaya.DaftarKomentar);
    }
}
