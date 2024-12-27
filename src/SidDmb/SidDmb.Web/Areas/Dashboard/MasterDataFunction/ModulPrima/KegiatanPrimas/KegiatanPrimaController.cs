using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Authentication;
using SidDmb.Domain.CollaborationFunction;
using SidDmb.Domain.MasterDataFunction.ModulPrima.KegiatanPrimas;
using SidDmb.Domain.MasterDataFunction.ModulPrima.KelompokPrimas;
using SidDmb.Infrastructure.Services.FileUpload;
using System.Drawing;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulPrima.KegiatanPrimas;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.ADMIN)]
public class KegiatanPrimaController : Controller
{
    private readonly IRepositoriKegiatanPrima _repositoriKegiatanPrima;
    private readonly IRepositoriKelompokPrima _repositoriKelompokPrima;
    private readonly IRepositoriKolaborator _repositoriKolaborator;
    private readonly IJoinEntityRepository<KolaboratorKegiatanPrima> _joinEntityRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileService _fileService;

    public KegiatanPrimaController(
        IRepositoriKegiatanPrima repositoriKegiatanPrima,
        IRepositoriKelompokPrima repositoriKelompokPrima,
        IUnitOfWork unitOfWork,
        IFileService fileService,
        IRepositoriKolaborator repositoriKolaborator,
        IJoinEntityRepository<KolaboratorKegiatanPrima> joinEntityRepository)
    {
        _repositoriKegiatanPrima = repositoriKegiatanPrima;
        _repositoriKelompokPrima = repositoriKelompokPrima;
        _unitOfWork = unitOfWork;
        _fileService = fileService;
        _repositoriKolaborator = repositoriKolaborator;
        _joinEntityRepository = joinEntityRepository;
    }

    public async Task<IActionResult> Index() => View(await _repositoriKegiatanPrima.GetAll());

    public IActionResult Tambah() => View(new TambahVM());

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var resultIdKelompokPrima = IdKelompok.Create(vm.KelompokPrimaId);
        if (resultIdKelompokPrima.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.KelompokPrimaId), resultIdKelompokPrima.Error.Message);
            return View(vm);
        }

        var kelompokPrima = await _repositoriKelompokPrima.Get(resultIdKelompokPrima.Value);
        if (kelompokPrima is null)
        {
            ModelState.AddModelError(nameof(TambahVM.KelompokPrimaId), $"Kelompok Prima dengan Id {resultIdKelompokPrima.Value} tidak ditemukan");
            return View(vm);
        }

        List<Kolaborator> daftarKolaborator = [];
        foreach (var kolaboratorId in vm.DaftarKolaboratorId)
        {
            var kolaborator = await _repositoriKolaborator.Get(kolaboratorId);
            if (kolaborator is null)
            {
                ModelState.AddModelError(nameof(TambahVM.DaftarKolaboratorId), $"Kolaborator dengan Id {kolaboratorId} tidak ditemukan");
                return View(vm);
            }

            daftarKolaborator.Add(kolaborator);
        }

        var fileResult = await _fileService.UploadFile<TambahVM>(vm.DokumentasiKegiatan, "/kegiatan_prima", [".jpeg", ".jpg", ".png"], 0, long.MaxValue);
        if (fileResult.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.DokumentasiKegiatan), fileResult.Error.Message);
            return View(vm);
        }

        var kegiatanPrima = new KegiatanPrima
        {
            Id = await IdKegiatanPrima.Generate(_repositoriKegiatanPrima),
            Nama = vm.Nama,
            Dekripsi = vm.Dekripsi,
            AnggaranKegiatan = vm.AnggaranKegiatan,
            DokumentasiKegiatan = fileResult.Value,
            Durasi = vm.Durasi,
            Fasilitator = vm.Fasilitator,
            FeedbackPeserta = vm.FeedbackPeserta,
            HasilKegiatan = vm.HasilKegiatan,
            Jenis = vm.Jenis,
            JumlahPeserta = vm.JumlahPeserta,
            Lokasi = vm.Lokasi,
            TanggalPelaksanaan = vm.TanggalPelaksanaan,
            KelompokPrima = kelompokPrima,
            DaftarKolabolator = daftarKolaborator
        };

        _repositoriKegiatanPrima.Add(kegiatanPrima);
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
        var resultId = IdKegiatanPrima.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var kegiatanPrima = await _repositoriKegiatanPrima.Get(resultId.Value);
        if (kegiatanPrima is null) return NotFound();

        return View(new EditVM
        {
            Id = id,
            Nama = kegiatanPrima.Nama,
            Dekripsi = kegiatanPrima.Dekripsi,
            AnggaranKegiatan = kegiatanPrima.AnggaranKegiatan,
            Durasi = kegiatanPrima.Durasi,
            Fasilitator = kegiatanPrima.Fasilitator,
            FeedbackPeserta = kegiatanPrima.FeedbackPeserta,
            HasilKegiatan = kegiatanPrima.HasilKegiatan,
            Jenis = kegiatanPrima.Jenis,
            JumlahPeserta = kegiatanPrima.JumlahPeserta,
            Lokasi = kegiatanPrima.Lokasi,
            TanggalPelaksanaan = kegiatanPrima.TanggalPelaksanaan,
            KelompokPrimaId = kegiatanPrima.KelompokPrima.Id.Value,
            DaftarKolaboratorId = kegiatanPrima.DaftarKolabolator.Select(k => k.Id).ToArray(),
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var resultId = IdKegiatanPrima.Create(vm.Id);
        if (resultId.IsFailure) return BadRequest();

        var kegiatanPrima = await _repositoriKegiatanPrima.Get(resultId.Value);
        if (kegiatanPrima is null) return NotFound();

        var resultIdKelompokPrima = IdKelompok.Create(vm.KelompokPrimaId);
        if (resultIdKelompokPrima.IsFailure)
        {
            ModelState.AddModelError(nameof(EditVM.KelompokPrimaId), resultIdKelompokPrima.Error.Message);
            return View(vm);
        }

        var kelompokPrima = await _repositoriKelompokPrima.Get(resultIdKelompokPrima.Value);
        if (kelompokPrima is null)
        {
            ModelState.AddModelError(nameof(EditVM.KelompokPrimaId), $"Kelompok Prima dengan Id {resultIdKelompokPrima.Value} tidak ditemukan");
            return View(vm);
        }

        List<Kolaborator> daftarKolaboratorBaru = [];
        foreach (var kolaboratorId in vm.DaftarKolaboratorId)
        {
            var kolaborator = await _repositoriKolaborator.Get(kolaboratorId);
            if (kolaborator is null)
            {
                ModelState.AddModelError(nameof(EditVM.DaftarKolaboratorId), $"Kolaborator dengan Id {kolaboratorId} tidak ditemukan");
                return View(vm);
            }

            daftarKolaboratorBaru.Add(kolaborator);
        }

        if (vm.DokumentasiKegiatanBaru is not null)
        {
            var fileResult = await _fileService.UploadFile<EditVM>(vm.DokumentasiKegiatanBaru, "/kegiatan_prima", [".jpeg", ".jpg", ".png"], 0, long.MaxValue);
            if (fileResult.IsFailure)
            {
                ModelState.AddModelError(nameof(EditVM.DokumentasiKegiatanBaru), fileResult.Error.Message);
                return View(vm);
            }

            kegiatanPrima.DokumentasiKegiatan = fileResult.Value;
        }

        kegiatanPrima.Nama = vm.Nama;
        kegiatanPrima.Dekripsi = vm.Dekripsi;
        kegiatanPrima.AnggaranKegiatan = vm.AnggaranKegiatan;
        kegiatanPrima.Durasi = vm.Durasi;
        kegiatanPrima.Fasilitator = vm.Fasilitator;
        kegiatanPrima.FeedbackPeserta = vm.FeedbackPeserta;
        kegiatanPrima.HasilKegiatan = vm.HasilKegiatan;
        kegiatanPrima.Jenis = vm.Jenis;
        kegiatanPrima.JumlahPeserta = vm.JumlahPeserta;
        kegiatanPrima.Lokasi = vm.Lokasi;
        kegiatanPrima.TanggalPelaksanaan = vm.TanggalPelaksanaan;
        kegiatanPrima.KelompokPrima = kelompokPrima;
        kegiatanPrima.DaftarKolabolator = daftarKolaboratorBaru;

        _repositoriKegiatanPrima.Update(kegiatanPrima);
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
        var resultId = IdKegiatanPrima.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var kegiatanPrima = await _repositoriKegiatanPrima.Get(resultId.Value);
        if (kegiatanPrima is null) return NotFound();

        _repositoriKegiatanPrima.Delete(kegiatanPrima);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure) return StatusCode(StatusCodes.Status500InternalServerError);

        return RedirectToAction(nameof(Index));
    }
}
