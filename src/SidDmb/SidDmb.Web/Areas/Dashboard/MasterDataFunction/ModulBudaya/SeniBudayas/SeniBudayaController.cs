using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Authentication;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.SeniBudayas;
using SidDmb.Infrastructure.Services.FileUpload;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulBudaya.SeniBudayas;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.ADMIN)]
public class SeniBudayaController : Controller
{
    private readonly IRepositoriSeniBudaya _repositoriSeniBudaya;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileService _fileService;

    public SeniBudayaController(
        IRepositoriSeniBudaya repositoriSeniBudaya,
        IUnitOfWork unitOfWork,
        IFileService fileService)
    {
        _repositoriSeniBudaya = repositoriSeniBudaya;
        _unitOfWork = unitOfWork;
        _fileService = fileService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _repositoriSeniBudaya.GetAll());
    }

    public IActionResult Tambah() => View(new TambahVM());

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var fileResult = await _fileService.UploadFile<TambahVM>(
            vm.MediaPromosi,
            "/seni_budaya",
            [".jpg", ".jpeg", ".png"],
            0, long.MaxValue);

        if (fileResult.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.MediaPromosi), fileResult.Error.Message);
            return View(vm);
        }

        var seniBudaya = new SeniBudaya
        {
            Id = await IdSeni.Generate(_repositoriSeniBudaya),
            Nama = vm.Nama,
            Dekripsi = vm.Dekripsi,
            DurasiPentunjukan = vm.DurasiPentunjukan,
            FasilitasPertunjukan = vm.FasilitasPertunjukan,
            HargaTiket = vm.HargaTiket,
            Kategori = vm.Kategori,
            LokasiPertunjukan = vm.LokasiPertunjukan,
            MediaPromosi = fileResult.Value,
            NamaPelakuSeni = vm.NamaPelakuSeni,
            PeraturanKhusus = vm.PeraturanKhusus,
            WaktuPertunjukan = vm.WaktuPertunjukan
        };

        _repositoriSeniBudaya.Add(seniBudaya);
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
        var resultId = IdSeni.Create(id);
        if (resultId.IsFailure) return NotFound();

        var seniBudaya = await _repositoriSeniBudaya.Get(resultId.Value);
        if (seniBudaya is null) return NotFound();

        return View(new EditVM
        {
            Id = id,
            Dekripsi = seniBudaya.Dekripsi,
            DurasiPentunjukan = seniBudaya.DurasiPentunjukan,
            FasilitasPertunjukan = seniBudaya.FasilitasPertunjukan,
            HargaTiket = seniBudaya.HargaTiket,
            Kategori = seniBudaya.Kategori,
            LokasiPertunjukan = seniBudaya.LokasiPertunjukan,
            Nama = seniBudaya.Nama,
            NamaPelakuSeni = seniBudaya.NamaPelakuSeni,
            PeraturanKhusus = seniBudaya.PeraturanKhusus,
            WaktuPertunjukan = seniBudaya.WaktuPertunjukan
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var resultId = IdSeni.Create(vm.Id);
        if (resultId.IsFailure) return NotFound();

        var seniBudaya = await _repositoriSeniBudaya.Get(resultId.Value);
        if (seniBudaya is null) return NotFound();

        if (vm.MediaPromosiBaru is not null)
        {
            var fileResult = await _fileService.UploadFile<EditVM>(
                vm.MediaPromosiBaru,
                "/seni_budaya",
                [".jpg", ".jpeg", ".png"],
                0, long.MaxValue);

            if (fileResult.IsFailure)
            {
                ModelState.AddModelError(nameof(EditVM.MediaPromosiBaru), fileResult.Error.Message);
                return View(vm);
            }

            seniBudaya.MediaPromosi = fileResult.Value;
        }

        seniBudaya.Dekripsi = vm.Dekripsi;
        seniBudaya.DurasiPentunjukan = vm.DurasiPentunjukan;
        seniBudaya.FasilitasPertunjukan = vm.FasilitasPertunjukan;
        seniBudaya.HargaTiket = vm.HargaTiket;
        seniBudaya.Kategori = vm.Kategori;
        seniBudaya.LokasiPertunjukan = vm.LokasiPertunjukan;
        seniBudaya.Nama = vm.Nama;
        seniBudaya.NamaPelakuSeni = vm.NamaPelakuSeni;
        seniBudaya.PeraturanKhusus = vm.PeraturanKhusus;
        seniBudaya.WaktuPertunjukan = vm.WaktuPertunjukan;

        _repositoriSeniBudaya.Update(seniBudaya);
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
        var resultId = IdSeni.Create(id);
        if (resultId.IsFailure) return NotFound();

        var seniBudaya = await _repositoriSeniBudaya.Get(resultId.Value);
        if (seniBudaya is null) return NotFound();

        _repositoriSeniBudaya.Delete(seniBudaya);
        var result = await _unitOfWork.SaveChangesAsync();

        if (result.IsFailure) return StatusCode(StatusCodes.Status500InternalServerError);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Komentar(string id)
    {
        var idResult = IdSeni.Create(id);
        if (idResult.IsFailure) return NotFound();

        var seniBudaya = await _repositoriSeniBudaya.Get(idResult.Value);
        if (seniBudaya is null) return NotFound();

        return PartialView("_KomentarPartial", seniBudaya.DaftarKomentar);
    }
}
