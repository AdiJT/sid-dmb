using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Authentication;
using SidDmb.Domain.CollaborationFunction;
using SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi.MateriEdukasiDanPembelajaran;
using SidDmb.Infrastructure.Services.FileUpload;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulPelatihanEdukasi.MateriEdukasi;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.ADMIN)]
public class MateriEdukasiController : Controller
{
    private readonly IRepositoriMateri _repositoriMateri;
    private readonly IRepositoriKolaborator _repositoriKolaborator;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileService _fileService;

    public MateriEdukasiController(
        IRepositoriMateri repositoriMateri,
        IRepositoriKolaborator repositoriKolaborator,
        IUnitOfWork unitOfWork,
        IFileService fileService)
    {
        _repositoriMateri = repositoriMateri;
        _repositoriKolaborator = repositoriKolaborator;
        _unitOfWork = unitOfWork;
        _fileService = fileService;
    }

    public async Task<IActionResult> Index() => View(await  _repositoriMateri.GetAll());

    public IActionResult Tambah() => View(new TambahVM());

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if(!ModelState.IsValid) return View(vm);

        var linkUnduhanResult = await _fileService.UploadFile<TambahVM>(vm.LinkUnduhan, "/materi_edukasi", [".pdf", ".mp4", ".pptx"], 0, long.MaxValue);
        if(linkUnduhanResult.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.LinkUnduhan), linkUnduhanResult.Error.Message); 
            return View(vm);
        }

        var dokumenPendukungResult = await _fileService.UploadFile<TambahVM>(vm.DokumenPendukung, "/materi_edukasi", [".pdf"], 0, long.MaxValue);
        if (dokumenPendukungResult.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.DokumenPendukung), dokumenPendukungResult.Error.Message);
            return View(vm);
        }

        List<Kolaborator> daftarKolaborator = [];
        foreach (var kolaboratorId in vm.DaftarKolaboratorId)
        {
            var kolaborator = await _repositoriKolaborator.Get(kolaboratorId);
            if(kolaborator is null)
            {
                ModelState.AddModelError(nameof(TambahVM.DaftarKolaboratorId), $"Kolaborator dengan Id '{kolaboratorId}' tidak ditemukan");
                return View(vm);
            }

            daftarKolaborator.Add(kolaborator);
        }

        var materi = new Materi
        {
            Id = await IdMateri.Generate(_repositoriMateri),
            JudulMateri = vm.JudulMateri,
            DekripsiMateri = vm.DekripsiMateri,
            FeedBackAudiens = vm.FeedBackAudiens,
            JumlahPengguna = vm.JumlahPengguna,
            KategoriMateri = vm.KategoriMateri,
            StatusMateri = vm.StatusMateri,
            TipeMateri = vm.TipeMateri,
            PenyediaMateri = vm.PenyediaMateri,
            TanggalRilis = vm.TanggalRilis,
            TargetAudiens = vm.TargetAudiens.Aggregate(vm.TargetAudiens.First(), (acc, t) => acc | t),
            DokumenPendukung = dokumenPendukungResult.Value,
            LinkUnduhan = linkUnduhanResult.Value,
            DaftarKolaborator = daftarKolaborator
        };

        _repositoriMateri.Add(materi);
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
        var resultId = IdMateri.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var materi = await _repositoriMateri.Get(resultId.Value);
        if (materi is null) return NotFound();

        return View(new EditVM
        {
            Id = id,
            JudulMateri = materi.JudulMateri,
            DekripsiMateri = materi.DekripsiMateri,
            FeedBackAudiens = materi.FeedBackAudiens,
            JumlahPengguna = materi.JumlahPengguna,
            KategoriMateri = materi.KategoriMateri,
            StatusMateri = materi.StatusMateri,
            TipeMateri = materi.TipeMateri,
            PenyediaMateri = materi.PenyediaMateri,
            TanggalRilis = materi.TanggalRilis,
            TargetAudiens = Enum.GetValues<TargetAudiens>().Where(x => materi.TargetAudiens.HasFlag(x)).ToArray(),
            DaftarKolaboratorId = materi.DaftarKolaborator.Select(x => x.Id).ToArray(),
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        var resultId = IdMateri.Create(vm.Id);
        if (resultId.IsFailure) return BadRequest();

        var materi = await _repositoriMateri.Get(resultId.Value);
        if (materi is null) return NotFound();

        if(vm.LinkUnduhan is not null)
        {
            var linkUnduhanResult = await _fileService.UploadFile<EditVM>(vm.LinkUnduhan, "/materi_edukasi", [".pdf", ".mp4", ".pptx"], 0, long.MaxValue);
            if (linkUnduhanResult.IsFailure)
            {
                ModelState.AddModelError(nameof(EditVM.LinkUnduhan), linkUnduhanResult.Error.Message);
                return View(vm);
            }

            materi.LinkUnduhan = linkUnduhanResult.Value;
        }

        if (vm.DokumenPendukung is not null)
        {
            var dokumenPendukungResult = await _fileService.UploadFile<EditVM>(vm.DokumenPendukung, "/materi_edukasi", [".pdf"], 0, long.MaxValue);
            if (dokumenPendukungResult.IsFailure)
            {
                ModelState.AddModelError(nameof(EditVM.DokumenPendukung), dokumenPendukungResult.Error.Message);
                return View(vm);
            }

            materi.DokumenPendukung = dokumenPendukungResult.Value;
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

        materi.JudulMateri = vm.JudulMateri;
        materi.DekripsiMateri = vm.DekripsiMateri;
        materi.FeedBackAudiens = vm.FeedBackAudiens;
        materi.JumlahPengguna = vm.JumlahPengguna;
        materi.KategoriMateri = vm.KategoriMateri;
        materi.StatusMateri = vm.StatusMateri;
        materi.TipeMateri = vm.TipeMateri;
        materi.PenyediaMateri = vm.PenyediaMateri;
        materi.TanggalRilis = vm.TanggalRilis;
        materi.DaftarKolaborator = daftarKolaborator;
        materi.TargetAudiens = vm.TargetAudiens.Aggregate(vm.TargetAudiens.First(), (acc, t) => acc | t);

        _repositoriMateri.Update(materi);
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
        var resultId = IdMateri.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var materi = await _repositoriMateri.Get(resultId.Value);
        if (materi is null) return NotFound();

        _repositoriMateri.Delete(materi);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure) return StatusCode(StatusCodes.Status500InternalServerError);

        return RedirectToAction(nameof(Index));
    }
}