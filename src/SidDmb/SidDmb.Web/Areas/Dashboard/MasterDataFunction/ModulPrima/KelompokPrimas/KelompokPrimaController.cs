using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Authentication;
using SidDmb.Domain.MasterDataFunction.ModulPrima.KelompokPrimas;
using SidDmb.Infrastructure.Services.FileUpload;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulPrima.KelompokPrimas;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.ADMIN)]
public class KelompokPrimaController : Controller
{
    private readonly IRepositoriKelompokPrima _repositoriKelompokPrima;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileService _fileService;

    public KelompokPrimaController(
        IRepositoriKelompokPrima repositoriKelompokPrima,
        IUnitOfWork unitOfWork,
        IFileService fileService)
    {
        _repositoriKelompokPrima = repositoriKelompokPrima;
        _unitOfWork = unitOfWork;
        _fileService = fileService;
    }

    public async Task<IActionResult> Index() => View(await _repositoriKelompokPrima.GetAll());

    public IActionResult Tambah() => View(new TambahVM());

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var fileResult = await _fileService.UploadFile<TambahVM>(vm.MediaPromosi, "/kelompok_prima", [".jpeg", ".png", ".jpg"], 0, long.MaxValue);
        if (fileResult.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.MediaPromosi), fileResult.Error.Message);
            return View(vm);
        }

        var kelompokPrima = new KelompokPrima
        {
            Id = await IdKelompok.Generate(_repositoriKelompokPrima),
            Nama = vm.Nama,
            Dekripsi = vm.Dekripsi,
            Alamat = vm.Alamat,
            JumlahAnggota = vm.JumlahAnggota,
            FokusKegiatan = vm.FokusKegiatan.Aggregate(vm.FokusKegiatan.First(), (acc, f) => acc | f),
            JumlahProgramDilaksanakan = vm.JumlahProgramDilaksanakan,
            KetuaKelompok = vm.KetuaKelompok,
            KontakInformasi = vm.KontakInformasi,
            MediaPromosi = fileResult.Value,
            ProgramUnggulan = vm.ProgramUnggulan,
            TahunBerdiri = vm.TahunBerdiri,
        };

        _repositoriKelompokPrima.Add(kelompokPrima);
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
        var resultId = IdKelompok.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var kelompokPrima = await _repositoriKelompokPrima.Get(resultId.Value);
        if (kelompokPrima is null) return NotFound();

        return View(new EditVM
        {
            Id = id,
            Alamat = kelompokPrima.Alamat,
            JumlahAnggota = kelompokPrima.JumlahAnggota,
            Dekripsi = kelompokPrima.Dekripsi,
            JumlahProgramDilaksanakan = kelompokPrima.JumlahProgramDilaksanakan,
            FokusKegiatan = Enum.GetValues<FokusKegiatanKelompokPrima>().Where(f => kelompokPrima.FokusKegiatan.HasFlag(f)).ToArray(),
            KetuaKelompok = kelompokPrima.KetuaKelompok,
            KontakInformasi = kelompokPrima.KontakInformasi,
            Nama = kelompokPrima.Nama,
            ProgramUnggulan = kelompokPrima.ProgramUnggulan,
            TahunBerdiri = kelompokPrima.TahunBerdiri
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        var resultId = IdKelompok.Create(vm.Id);
        if (resultId.IsFailure) return BadRequest();

        var kelompokPrima = await _repositoriKelompokPrima.Get(resultId.Value);
        if (kelompokPrima is null) return NotFound();

        if(vm.MediaPromosiBaru is not null)
        {
            var fileResult = await _fileService.UploadFile<EditVM>(vm.MediaPromosiBaru, "/kelompok_prima", [".jpeg", ".png", ".jpg"], 0, long.MaxValue);
            if (fileResult.IsFailure)
            {
                ModelState.AddModelError(nameof(EditVM.MediaPromosiBaru), fileResult.Error.Message);
                return View(vm);
            }

            kelompokPrima.MediaPromosi = fileResult.Value;
        }

        kelompokPrima.Alamat = vm.Alamat;
        kelompokPrima.JumlahAnggota = vm.JumlahAnggota;
        kelompokPrima.Dekripsi = vm.Dekripsi;
        kelompokPrima.JumlahProgramDilaksanakan = vm.JumlahProgramDilaksanakan;
        kelompokPrima.FokusKegiatan = vm.FokusKegiatan.Aggregate(vm.FokusKegiatan.First(), (acc, f) => acc | f);
        kelompokPrima.KetuaKelompok = vm.KetuaKelompok;
        kelompokPrima.KontakInformasi = vm.KontakInformasi;
        kelompokPrima.Nama = vm.Nama;
        kelompokPrima.ProgramUnggulan = vm.ProgramUnggulan;
        kelompokPrima.TahunBerdiri = vm.TahunBerdiri;

        _repositoriKelompokPrima.Update(kelompokPrima);
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
        var resultId = IdKelompok.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var kelompokPrima = await _repositoriKelompokPrima.Get(resultId.Value);
        if (kelompokPrima is null) return NotFound();

        _repositoriKelompokPrima.Delete(kelompokPrima);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure) return StatusCode(StatusCodes.Status500InternalServerError);

        return RedirectToAction(nameof(Index));
    }
}