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
            WaktuPelaksanaan = vm.WaktuPelaksanaan,
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
