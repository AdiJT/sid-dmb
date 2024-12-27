using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Authentication;
using SidDmb.Domain.MasterDataFunction.ModulWisata.DestinasiWisatas;
using SidDmb.Domain.MasterDataFunction.ModulWisata.LaporanKunjungans;
using SidDmb.Infrastructure.Services.FileUpload;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulWisata.LaporanKunjungans;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.ADMIN)]
public class LaporanKunjunganController : Controller
{
    private readonly IRepositoriLaporanKunjungan _repositoriLaporanKunjungan;
    private readonly IRepositoriDestinasiWisata _repositoriDestinasiWisata;
    private readonly IUnitOfWork _unitOfWork;

    public LaporanKunjunganController(
        IRepositoriLaporanKunjungan repositoriLaporanKunjungan,
        IRepositoriDestinasiWisata repositoriDestinasiWisata,
        IUnitOfWork unitOfWork)
    {
        _repositoriLaporanKunjungan = repositoriLaporanKunjungan;
        _repositoriDestinasiWisata = repositoriDestinasiWisata;
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index() => View(await _repositoriLaporanKunjungan.GetAll());

    public IActionResult Tambah() => View(new TambahVM());

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if(!ModelState.IsValid) return View(vm);

        var resultDestinasiId = IdDestinasi.Create(vm.DestinasiWisataId);
        if(resultDestinasiId.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.DestinasiWisataId), resultDestinasiId.Error.Message);
            return View(vm);
        }

        var destinasiWisata = await _repositoriDestinasiWisata.Get(resultDestinasiId.Value);
        if(destinasiWisata is null)
        {
            ModelState.AddModelError(nameof(TambahVM.DestinasiWisataId), $"Destinasi Wisata dengan Id '{resultDestinasiId.Value}' tidak ditemukan");
            return View(vm);
        }

        var laporanKunjungan = new LaporanKunjungan
        {
            Id = await IdKunjungan.Generate(_repositoriLaporanKunjungan),
            TanggalKunjungan = vm.TanggalKunjungan,
            DurasiKunjungan = vm.DurasiKunjungan,
            JumlahWisatawanDomestik = vm.JumlahWisatawanDomestik,
            JumlahWisatawanInternasional = vm.JumlahWisatawanInternasional,
            KomentarPengunjung = vm.KomentarPengunjung,
            RatingPengunjung = vm.RatingPengunjung,
            TiketTerjual = vm.TiketTerjual,
            DestinasiWisata = destinasiWisata,
        };

        _repositoriLaporanKunjungan.Add(laporanKunjungan);
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
        var resultId = IdKunjungan.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var laporanKunjungan = await _repositoriLaporanKunjungan.Get(resultId.Value);
        if(laporanKunjungan is null) return NotFound();

        return View(new EditVM
        {
            Id = id,
            TanggalKunjungan = laporanKunjungan.TanggalKunjungan,
            DurasiKunjungan = laporanKunjungan.DurasiKunjungan,
            JumlahWisatawanDomestik = laporanKunjungan.JumlahWisatawanDomestik,
            JumlahWisatawanInternasional = laporanKunjungan.JumlahWisatawanInternasional,
            KomentarPengunjung = laporanKunjungan.KomentarPengunjung,
            RatingPengunjung = laporanKunjungan.RatingPengunjung,
            TiketTerjual = laporanKunjungan.TiketTerjual,
            DestinasiWisataId = laporanKunjungan.DestinasiWisata.Id.Value,
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var resultId = IdKunjungan.Create(vm.Id);
        if (resultId.IsFailure) return BadRequest();

        var laporanKunjungan = await _repositoriLaporanKunjungan.Get(resultId.Value);
        if (laporanKunjungan is null) return NotFound();

        var resultDestinasiId = IdDestinasi.Create(vm.DestinasiWisataId);
        if (resultDestinasiId.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.DestinasiWisataId), resultDestinasiId.Error.Message);
            return View(vm);
        }

        var destinasiWisata = await _repositoriDestinasiWisata.Get(resultDestinasiId.Value);
        if (destinasiWisata is null)
        {
            ModelState.AddModelError(nameof(TambahVM.DestinasiWisataId), $"Destinasi Wisata dengan Id '{resultDestinasiId.Value}' tidak ditemukan");
            return View(vm);
        }

        laporanKunjungan.TanggalKunjungan = vm.TanggalKunjungan;
        laporanKunjungan.DurasiKunjungan = vm.DurasiKunjungan;
        laporanKunjungan.JumlahWisatawanDomestik = vm.JumlahWisatawanDomestik;
        laporanKunjungan.JumlahWisatawanInternasional = vm.JumlahWisatawanInternasional;
        laporanKunjungan.KomentarPengunjung = vm.KomentarPengunjung;
        laporanKunjungan.RatingPengunjung = vm.RatingPengunjung;
        laporanKunjungan.TiketTerjual = vm.TiketTerjual;
        laporanKunjungan.DestinasiWisata = destinasiWisata;

        _repositoriLaporanKunjungan.Update(laporanKunjungan);
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
        var resultId = IdKunjungan.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var laporanKunjungan = await _repositoriLaporanKunjungan.Get(resultId.Value);
        if (laporanKunjungan is null) return NotFound();

        _repositoriLaporanKunjungan.Delete(laporanKunjungan);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure) return StatusCode(StatusCodes.Status500InternalServerError);

        return RedirectToAction(nameof(Index));
    }
}
