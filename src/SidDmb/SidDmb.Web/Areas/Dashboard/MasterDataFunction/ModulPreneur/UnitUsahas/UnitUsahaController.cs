using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Authentication;
using SidDmb.Domain.MasterDataFunction.ModulPreneur.UnitUsahas;
using SidDmb.Domain.Shared;
using SidDmb.Infrastructure.Services.FileUpload;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulPreneur.UnitUsahas;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.ADMIN)]
public class UnitUsahaController : Controller
{
    private readonly IRepositoriUnitUsaha _repositoriUnitUsaha;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileService _fileService;

    public UnitUsahaController(
        IRepositoriUnitUsaha repositoriUnitUsaha,
        IUnitOfWork unitOfWork,
        IFileService fileService)
    {
        _repositoriUnitUsaha = repositoriUnitUsaha;
        _unitOfWork = unitOfWork;
        _fileService = fileService;
    }

    public async Task<IActionResult> Index() => View(await _repositoriUnitUsaha.GetAll());

    public IActionResult Tambah() => View(new TambahVM());

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var fileResult = await _fileService.UploadFile<TambahVM>(vm.MediaPromosi, "/unit_usaha", [".jpeg", ".jpg", ",png"], 0, long.MaxValue);
        if(fileResult.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.MediaPromosi), fileResult.Error.Message);
            return View(vm);
        }

        var unitUsaha = new UnitUsaha
        {
            Id = await IdUnitUsaha.Generate(_repositoriUnitUsaha),
            Nama = vm.Nama,
            Dekripsi = vm.Dekripsi,
            JumlahKaryawan = vm.JumlahKaryawan,
            PemilikUsaha = vm.PemilikUsaha,
            Alamat = vm.Alamat,
            Kategori = vm.Kategori,
            KontakInformasi = vm.KontakInformasi,
            Legalitas = vm.Legalitas,
            MediaPromosi = fileResult.Value,
            TanggalBerdiri = vm.TanggalBerdiri,
            TitikKoordinat = new Point(vm.Lng, vm.Lat)
        };

        _repositoriUnitUsaha.Add(unitUsaha);
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
        var resultId = IdUnitUsaha.Create(id);
        if (resultId.IsFailure) return NotFound();

        var unitUsaha = await _repositoriUnitUsaha.Get(resultId.Value);
        if(unitUsaha is null) return NotFound();

        return View(new EditVM
        {
            Id = id,
            Nama = unitUsaha.Nama,
            JumlahKaryawan = unitUsaha.JumlahKaryawan,
            Alamat = unitUsaha.Alamat,
            Dekripsi = unitUsaha.Dekripsi,
            Kategori = unitUsaha.Kategori,
            KontakInformasi = unitUsaha.KontakInformasi,
            Lat = unitUsaha.TitikKoordinat.Y,
            Lng = unitUsaha.TitikKoordinat.X,
            Legalitas = unitUsaha.Legalitas,
            PemilikUsaha = unitUsaha.PemilikUsaha,
            TanggalBerdiri = unitUsaha.TanggalBerdiri
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        var resultId = IdUnitUsaha.Create(vm.Id);
        if (resultId.IsFailure) return NotFound();

        var unitUsaha = await _repositoriUnitUsaha.Get(resultId.Value);
        if (unitUsaha is null) return NotFound();

        if(vm.MediaPromosiBaru is not null)
        {
            var fileResult = await _fileService.UploadFile<EditVM>(vm.MediaPromosiBaru, "/unit_usaha", [".jpeg", ".jpg", ",png"], 0, long.MaxValue);
            if (fileResult.IsFailure)
            {
                ModelState.AddModelError(nameof(EditVM.MediaPromosiBaru), fileResult.Error.Message);
                return View(vm);
            }

            unitUsaha.MediaPromosi = fileResult.Value;
        }
        
        unitUsaha.Nama = vm.Nama;
        unitUsaha.JumlahKaryawan = vm.JumlahKaryawan;
        unitUsaha.Alamat = vm.Alamat;
        unitUsaha.Dekripsi = vm.Dekripsi;
        unitUsaha.Kategori = vm.Kategori;
        unitUsaha.KontakInformasi = vm.KontakInformasi;
        unitUsaha.TitikKoordinat = new Point(vm.Lng, vm.Lat);
        unitUsaha.Legalitas = vm.Legalitas;
        unitUsaha.PemilikUsaha = vm.PemilikUsaha;
        unitUsaha.TanggalBerdiri = vm.TanggalBerdiri;

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
        var resultId = IdUnitUsaha.Create(id);
        if (resultId.IsFailure) return NotFound();

        var unitUsaha = await _repositoriUnitUsaha.Get(resultId.Value);
        if (unitUsaha is null) return NotFound();

        _repositoriUnitUsaha.Delete(unitUsaha);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure) return StatusCode(StatusCodes.Status500InternalServerError);

        return RedirectToAction(nameof(Index));
    }
}
