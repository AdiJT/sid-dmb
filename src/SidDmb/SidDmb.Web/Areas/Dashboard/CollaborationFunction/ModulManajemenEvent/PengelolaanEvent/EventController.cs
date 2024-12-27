using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Authentication;
using SidDmb.Domain.CollaborationFunction;
using SidDmb.Domain.CollaborationFunction.ModulManajemenEvent.PengelolaanEvent;
using SidDmb.Infrastructure.Services.FileUpload;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulManajemenEvent.PengelolaanEvent;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.ADMIN)]
public class EventController : Controller
{
    private readonly IRepositoriEvent _repositoriEvent;
    private readonly IRepositoriKolaborator _repositoriKolaborator;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileService _fileService;

    public EventController(
        IRepositoriEvent repositoriEvent,
        IRepositoriKolaborator repositoriKolaborator,
        IUnitOfWork unitOfWork,
        IFileService fileService)
    {
        _repositoriEvent = repositoriEvent;
        _repositoriKolaborator = repositoriKolaborator;
        _unitOfWork = unitOfWork;
        _fileService = fileService;
    }

    public async Task<IActionResult> Index() => View(await _repositoriEvent.GetAll());

    public IActionResult Tambah() => View(new TambahVM());

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

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

        var fileResult = await _fileService.UploadFile<TambahVM>(vm.MediaPromosi, "/event", [".jpg", ".png", ".jpeg"], 0, long.MaxValue);
        if (fileResult.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.MediaPromosi), fileResult.Error.Message);
            return View(vm);
        }

        var eventBaru = new Event
        {
            Id = await IdEvent.Generate(_repositoriEvent),
            Nama = vm.Nama,
            Dekripsi = vm.Dekripsi,
            Kategori = vm.Kategori,
            Anggaran = vm.Anggaran,
            JumlahPesertaMaksimal = vm.JumlahPesertaMaksimal,
            KontakInformasi = vm.KontakInformasi,
            Lokasi = vm.Lokasi,
            MediaPromosi = fileResult.Value,
            Penyelenggara = vm.Penyelenggara,
            Sponsor = vm.Sponsor,
            StatusPendaftaran = vm.StatusPendaftaran,
            TanggalWaktu = new DateTime(vm.TanggalWaktu.Ticks, DateTimeKind.Unspecified),
            TargetPeserta = vm.TargetPeserta,
            DaftarKolaborator = daftarKolaborator
        };
        _repositoriEvent.Add(eventBaru);
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
        var resultId = IdEvent.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var @event = await _repositoriEvent.Get(resultId.Value);
        if (@event is null) return NotFound();

        return View(new EditVM
        {
            Id = id,
            DaftarKolaboratorId = @event.DaftarKolaborator.Select(e => e.Id).ToArray(),
            Nama = @event.Nama,
            Dekripsi = @event.Dekripsi,
            Kategori = @event.Kategori,
            Anggaran = @event.Anggaran,
            JumlahPesertaMaksimal = @event.JumlahPesertaMaksimal,
            KontakInformasi = @event.KontakInformasi,
            Lokasi = @event.Lokasi,
            Penyelenggara = @event.Penyelenggara,
            Sponsor = @event.Sponsor,
            StatusPendaftaran = @event.StatusPendaftaran,
            TanggalWaktu = @event.TanggalWaktu,
            TargetPeserta = @event.TargetPeserta,
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        var resultId = IdEvent.Create(vm.Id);
        if (resultId.IsFailure) return BadRequest();

        var @event = await _repositoriEvent.Get(resultId.Value);
        if (@event is null) return NotFound();

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
        @event.DaftarKolaborator = daftarKolaborator;

        if (vm.MediaPromosi is not null)
        {
            var fileResult = await _fileService.UploadFile<EditVM>(vm.MediaPromosi, "/event", [".jpg", ".png", ".jpeg"], 0, long.MaxValue);
            if (fileResult.IsFailure)
            {
                ModelState.AddModelError(nameof(EditVM.MediaPromosi), fileResult.Error.Message);
                return View(vm);
            }

            @event.MediaPromosi = fileResult.Value;
        }

        @event.Nama = vm.Nama;
        @event.Dekripsi = vm.Dekripsi;
        @event.Kategori = vm.Kategori;
        @event.Anggaran = vm.Anggaran;
        @event.JumlahPesertaMaksimal = vm.JumlahPesertaMaksimal;
        @event.KontakInformasi = vm.KontakInformasi;
        @event.Lokasi = vm.Lokasi;
        @event.Penyelenggara = vm.Penyelenggara;
        @event.Sponsor = vm.Sponsor;
        @event.StatusPendaftaran = vm.StatusPendaftaran;
        @event.TanggalWaktu = new DateTime(vm.TanggalWaktu.Ticks, DateTimeKind.Unspecified);
        @event.TargetPeserta = vm.TargetPeserta;

        _repositoriEvent.Update(@event);
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
        var resultId = IdEvent.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var @event = await _repositoriEvent.Get(resultId.Value);
        if (@event is null) return NotFound();

        _repositoriEvent.Delete(@event);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure) return StatusCode(StatusCodes.Status500InternalServerError);

        return RedirectToAction(nameof(Index));
    }
}