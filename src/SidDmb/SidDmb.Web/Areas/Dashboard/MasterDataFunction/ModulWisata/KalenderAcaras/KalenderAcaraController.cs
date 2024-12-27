using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Authentication;
using SidDmb.Domain.MasterDataFunction.ModulWisata.KalenderAcaras;
using SidDmb.Infrastructure.Services.FileUpload;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulWisata.KalenderAcaras;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.ADMIN)]
public class KalenderAcaraController : Controller
{
    private readonly IRepositoriKalenderAcara _repositoriKalenderAcara;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileService _fileService;

    public KalenderAcaraController(
        IRepositoriKalenderAcara repositoriKalenderAcara,
        IUnitOfWork unitOfWork,
        IFileService fileService)
    {
        _repositoriKalenderAcara = repositoriKalenderAcara;
        _unitOfWork = unitOfWork;
        _fileService = fileService;
    }

    public async Task<IActionResult> Index() => View(await _repositoriKalenderAcara.GetAll());

    public IActionResult Tambah() => View(new TambahVM());

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var fileResult = await _fileService.UploadFile<TambahVM>(vm.MediaPromosi, "/kalender_acara", [".jpg", ".jpeg", ".png"], 0, long.MaxValue);
        if(fileResult.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.MediaPromosi), fileResult.Error.Message);
            return View(vm);
        }

        var kalenderAcara = new KalenderAcara
        {
            Id = await IdAcara.Generate(_repositoriKalenderAcara),
            NamaAcara = vm.NamaAcara,
            HargaTiketAcara = vm.HargaTiketAcara,
            LokasiAcara = vm.LokasiAcara,
            RatingAcara = vm.RatingAcara,
            TargetPesertaAcara = vm.TargetPesertaAcara,
            DekripsiAcara = vm.DekripsiAcara,
            SponsorAcara = vm.SponsorAcara,
            BatasKuotaPeserta = vm.BatasKuotaPeserta,
            Kategori = vm.Kategori,
            KontakInformasi = vm.KontakInformasi,
            MediaPromosi = fileResult.Value,
            PenanggungJawab = vm.PenanggungJawab,
            StatusPendaftaran = vm.StatusPendaftaran,
            TanggalDanWaktu = new DateTime(vm.TanggalDanWaktu.Ticks, DateTimeKind.Unspecified),
            TautanPendaftaran = vm.TautanPendaftaran
        };
        _repositoriKalenderAcara.Add(kalenderAcara);
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
        var resultId = IdAcara.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var kalenderAcara = await _repositoriKalenderAcara.Get(resultId.Value);
        if (kalenderAcara is null) return NotFound();

        return View(new EditVM
        {
            Id = id,
            NamaAcara = kalenderAcara.NamaAcara,
            HargaTiketAcara = kalenderAcara.HargaTiketAcara,
            LokasiAcara = kalenderAcara.LokasiAcara,
            RatingAcara = kalenderAcara.RatingAcara,
            TargetPesertaAcara = kalenderAcara.TargetPesertaAcara,
            DekripsiAcara = kalenderAcara.DekripsiAcara,
            SponsorAcara = kalenderAcara.SponsorAcara,
            BatasKuotaPeserta = kalenderAcara.BatasKuotaPeserta,
            Kategori = kalenderAcara.Kategori,
            KontakInformasi = kalenderAcara.KontakInformasi,
            PenanggungJawab = kalenderAcara.PenanggungJawab,
            StatusPendaftaran = kalenderAcara.StatusPendaftaran,
            TanggalDanWaktu = kalenderAcara.TanggalDanWaktu,
            TautanPendaftaran = kalenderAcara.TautanPendaftaran
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var resultId = IdAcara.Create(vm.Id);
        if (resultId.IsFailure) return BadRequest();

        var kalenderAcara = await _repositoriKalenderAcara.Get(resultId.Value);
        if (kalenderAcara is null) return NotFound();

        if(vm.MediaPromosi is not null)
        {
            var fileResult = await _fileService.UploadFile<EditVM>(vm.MediaPromosi, "/kalender_acara", [".jpg", ".jpeg", ".png"], 0, long.MaxValue);
            if (fileResult.IsFailure)
            {
                ModelState.AddModelError(nameof(EditVM.MediaPromosi), fileResult.Error.Message);
                return View(vm);
            }

            kalenderAcara.MediaPromosi = fileResult.Value;
        }

        kalenderAcara.NamaAcara = vm.NamaAcara;
        kalenderAcara.HargaTiketAcara = vm.HargaTiketAcara;
        kalenderAcara.LokasiAcara = vm.LokasiAcara;
        kalenderAcara.RatingAcara = vm.RatingAcara;
        kalenderAcara.TargetPesertaAcara = vm.TargetPesertaAcara;
        kalenderAcara.DekripsiAcara = vm.DekripsiAcara;
        kalenderAcara.SponsorAcara = vm.SponsorAcara;
        kalenderAcara.BatasKuotaPeserta = vm.BatasKuotaPeserta;
        kalenderAcara.Kategori = vm.Kategori;
        kalenderAcara.KontakInformasi = vm.KontakInformasi;
        kalenderAcara.PenanggungJawab = vm.PenanggungJawab;
        kalenderAcara.StatusPendaftaran = vm.StatusPendaftaran;
        kalenderAcara.TanggalDanWaktu = new DateTime(vm.TanggalDanWaktu.Ticks, DateTimeKind.Unspecified);
        kalenderAcara.TautanPendaftaran = vm.TautanPendaftaran;

        _repositoriKalenderAcara.Update(kalenderAcara);
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
        var resultId = IdAcara.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var kalenderAcara = await _repositoriKalenderAcara.Get(resultId.Value);
        if (kalenderAcara is null) return NotFound();

        _repositoriKalenderAcara.Delete(kalenderAcara);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure) return StatusCode(StatusCodes.Status500InternalServerError);

        return RedirectToAction(nameof(Index));
    }
}
