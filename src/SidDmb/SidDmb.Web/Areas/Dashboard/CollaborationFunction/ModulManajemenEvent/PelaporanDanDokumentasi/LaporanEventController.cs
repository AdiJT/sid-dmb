using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Authentication;
using SidDmb.Domain.CollaborationFunction.ModulManajemenEvent.PelaporanDanDokumentasi;
using SidDmb.Domain.CollaborationFunction.ModulManajemenEvent.PengelolaanEvent;
using SidDmb.Infrastructure.Services.FileUpload;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulManajemenEvent.PelaporanDanDokumentasi;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.ADMIN)]
public class LaporanEventController : Controller
{
    private readonly IRepostoriLaporanEvent _repositoriLaporanEvent;
    private readonly IRepostoriEvent _repostoriEvent;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileService _fileService;

    public LaporanEventController(
        IRepostoriLaporanEvent repositoriLaporanEvent,
        IUnitOfWork unitOfWork,
        IFileService fileService,
        IRepostoriEvent repositoriEvent)
    {
        _repositoriLaporanEvent = repositoriLaporanEvent;
        _unitOfWork = unitOfWork;
        _fileService = fileService;
        _repostoriEvent = repositoriEvent;
    }

    public async Task<IActionResult> Index() => View(await _repositoriLaporanEvent.GetAll());

    public IActionResult Tambah() => View(new TambahVM());

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var resultEventId = IdEvent.Create(vm.EventId);
        if (resultEventId.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.EventId), resultEventId.Error.Message);
            return View(vm);
        }

        var @event = await _repostoriEvent.Get(resultEventId.Value);
        if (@event is null)
        {
            ModelState.AddModelError(nameof(TambahVM.EventId), $"Event dengan ID '{resultEventId.Value}' tidak ditemukan");
            return View(vm);
        }

        var fotoResult = await _fileService.UploadFile<TambahVM>(vm.FotoDokumentasi, "/laporan_event", [".jpeg", ".jpg", ".png"], 0, long.MaxValue);
        if (fotoResult.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.FotoDokumentasi), fotoResult.Error.Message);
            return View(vm);
        }

        var videoResult = await _fileService.UploadFile<TambahVM>(vm.VideoDokumentasi, "/laporan_event", [".mp4"], 0, long.MaxValue);
        if (videoResult.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.VideoDokumentasi), videoResult.Error.Message);
            return View(vm);
        }

        var laporanResult = await _fileService.UploadFile<TambahVM>(vm.LaporanDetail, "/laporan_event", [".pdf"], 0, long.MaxValue);
        if (laporanResult.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.LaporanDetail), laporanResult.Error.Message);
            return View(vm);
        }

        var laporanEvent = new LaporanEvent
        {
            Id = await IdLaporanEvent.Generate(_repositoriLaporanEvent),
            Event = @event,
            FeedbackPeserta = vm.FeedbackPeserta,
            FotoDokumentasi = fotoResult.Value,
            JumlahPeserta = vm.JumlahPeserta,
            LaporanDetail = laporanResult.Value,
            PendapatanEvent = vm.PendapatanEvent,
            PengeluaranEvent = vm.PengeluaranEvent,
            TanggalPelaporan = vm.TanggalPelaporan,
            VideoDokumentasi = videoResult.Value,
            UlasanSingkatEvent = vm.UlasanSingkatEvent,
        };

        _repositoriLaporanEvent.Add(laporanEvent);
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
        var resultId = IdLaporanEvent.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var laporanEvent = await _repositoriLaporanEvent.Get(resultId.Value);
        if (laporanEvent is null) return NotFound();

        return View(new EditVM
        {
            Id = id,
            EventId = laporanEvent.Event.Id.Value,
            TanggalPelaporan = laporanEvent.TanggalPelaporan,
            FeedbackPeserta = laporanEvent.FeedbackPeserta,
            JumlahPeserta = laporanEvent.JumlahPeserta,
            PendapatanEvent = laporanEvent.PendapatanEvent,
            PengeluaranEvent = laporanEvent.PengeluaranEvent,
            UlasanSingkatEvent = laporanEvent.UlasanSingkatEvent
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        var resultId = IdLaporanEvent.Create(vm.Id);
        if (resultId.IsFailure) return BadRequest();

        var laporanEvent = await _repositoriLaporanEvent.Get(resultId.Value);
        if (laporanEvent is null) return NotFound();

        var resultEventId = IdEvent.Create(vm.EventId);
        if (resultEventId.IsFailure)
        {
            ModelState.AddModelError(nameof(EditVM.EventId), resultEventId.Error.Message);
            return View(vm);
        }

        var @event = await _repostoriEvent.Get(resultEventId.Value);
        if (@event is null)
        {
            ModelState.AddModelError(nameof(EditVM.EventId), $"Event dengan ID '{resultEventId.Value}' tidak ditemukan");
            return View(vm);
        }

        if (vm.FotoDokumentasi is not null)
        {
            var fotoResult = await _fileService.UploadFile<EditVM>(vm.FotoDokumentasi, "/laporan_event", [".jpeg", ".jpg", ".png"], 0, long.MaxValue);
            if (fotoResult.IsFailure)
            {
                ModelState.AddModelError(nameof(EditVM.FotoDokumentasi), fotoResult.Error.Message);
                return View(vm);
            }

            laporanEvent.FotoDokumentasi = fotoResult.Value;
        }

        if (vm.VideoDokumentasi is not null)
        {
            var videoResult = await _fileService.UploadFile<EditVM>(vm.VideoDokumentasi, "/laporan_event", [".mp4"], 0, long.MaxValue);
            if (videoResult.IsFailure)
            {
                ModelState.AddModelError(nameof(EditVM.VideoDokumentasi), videoResult.Error.Message);
                return View(vm);
            }

            laporanEvent.VideoDokumentasi = videoResult.Value;
        }

        if (vm.LaporanDetail is not null)
        {
            var laporanResult = await _fileService.UploadFile<EditVM>(vm.LaporanDetail, "/laporan_event", [".pdf"], 0, long.MaxValue);
            if (laporanResult.IsFailure)
            {
                ModelState.AddModelError(nameof(EditVM.LaporanDetail), laporanResult.Error.Message);
                return View(vm);
            }
        }

        laporanEvent.TanggalPelaporan = vm.TanggalPelaporan;
        laporanEvent.FeedbackPeserta = vm.FeedbackPeserta;
        laporanEvent.JumlahPeserta = vm.JumlahPeserta;
        laporanEvent.PendapatanEvent = vm.PendapatanEvent;
        laporanEvent.PengeluaranEvent = vm.PengeluaranEvent;
        laporanEvent.UlasanSingkatEvent = vm.UlasanSingkatEvent;
        laporanEvent.Event = @event;

        _repositoriLaporanEvent.Update(laporanEvent);
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
        var resultId = IdLaporanEvent.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var laporanEvent = await _repositoriLaporanEvent.Get(resultId.Value);
        if (laporanEvent is null) return NotFound();

        _repositoriLaporanEvent.Delete(laporanEvent);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure) return StatusCode(StatusCodes.Status500InternalServerError);

        return RedirectToAction(nameof(Index));
    }
}