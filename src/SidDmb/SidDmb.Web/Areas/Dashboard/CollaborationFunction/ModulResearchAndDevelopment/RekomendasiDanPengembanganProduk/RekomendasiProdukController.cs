using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Authentication;
using SidDmb.Domain.CollaborationFunction;
using SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.ManajemenProduk;
using SidDmb.Domain.CollaborationFunction.ModulResearchAndDevelopment.RekomendasiDanPengembanganProduk;
using SidDmb.Infrastructure.Services.FileUpload;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulResearchAndDevelopment.RekomendasiDanPengembanganProduk;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.ADMIN)]
public class RekomendasiProdukController : Controller
{
    private readonly IRepositoriRekomendasi _repositoriRekomendasi;
    private readonly IRepositoriProduk _repositoriProduk;
    private readonly IRepositoriKolaborator _repositoriKolaborator;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileService _fileService;

    public RekomendasiProdukController(
        IRepositoriRekomendasi repositoriRekomendasi,
        IRepositoriProduk repositoriProduk,
        IUnitOfWork unitOfWork,
        IFileService fileService,
        IRepositoriKolaborator repositoriKolaborator)
    {
        _repositoriRekomendasi = repositoriRekomendasi;
        _repositoriProduk = repositoriProduk;
        _unitOfWork = unitOfWork;
        _fileService = fileService;
        _repositoriKolaborator = repositoriKolaborator;
    }

    public async Task<IActionResult> Index() => View(await _repositoriRekomendasi.GetAll());

    public IActionResult Tambah() => View(new TambahVM());

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var fileResult = await _fileService.UploadFile<TambahVM>(vm.DokumenPendukung, "/rekomendasi_produk", [".pdf"], 0, long.MaxValue);
        if (fileResult.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.DokumenPendukung), fileResult.Error.Message);
            return View(vm);
        }

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

        var produkResult = IdProduk.Create(vm.ProdukId);
        if (produkResult.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.ProdukId), produkResult.Error.Message);
            return View(vm);
        }

        var produk = await _repositoriProduk.Get(produkResult.Value);
        if (produk is null)
        {
            ModelState.AddModelError(nameof(TambahVM.ProdukId), $"Produk dengan Id '{vm.ProdukId}' tidak ditemukan");
            return View(vm);
        }

        var rekomendasi = new Rekomendasi
        {
            Id = await IdRekomendasi.Generate(_repositoriRekomendasi),
            Judul = vm.Judul,
            Dekripsi = vm.Dekripsi,
            Anggaran = vm.Anggaran,
            HasilYangDiharapkan = vm.HasilYangDiharapkan,
            KategoriPengembangan = vm.KategoriPengembangan,
            PemberiRekomendasi = vm.PemberiRekomendasi,
            StatusImplementasi = vm.StatusImplementasi,
            StrategiYangDirekomendasikan = vm.StrategiYangDirekomendasikan,
            TujuanPengembangan = vm.TujuanPengembangan,
            TimelineRekomendasi = vm.TimelineRekomendasi,
            DokumenPendukung = fileResult.Value,
            ProdukTerkait = produk,
            DaftarKolaborator = daftarKolaborator,
        };

        _repositoriRekomendasi.Add(rekomendasi);
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
        var resultId = IdRekomendasi.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var rekomendasi = await _repositoriRekomendasi.Get(resultId.Value);
        if (rekomendasi is null) return NotFound();

        return View(new EditVM
        {
            Id = id,
            Judul = rekomendasi.Judul,
            Dekripsi = rekomendasi.Dekripsi,
            Anggaran = rekomendasi.Anggaran,
            HasilYangDiharapkan = rekomendasi.HasilYangDiharapkan,
            KategoriPengembangan = rekomendasi.KategoriPengembangan,
            PemberiRekomendasi = rekomendasi.PemberiRekomendasi,
            StatusImplementasi = rekomendasi.StatusImplementasi,
            StrategiYangDirekomendasikan = rekomendasi.StrategiYangDirekomendasikan,
            TujuanPengembangan = rekomendasi.TujuanPengembangan,
            TimelineRekomendasi = rekomendasi.TimelineRekomendasi,
            ProdukId = rekomendasi.ProdukTerkait.Id.Value,
            DaftarKolaboratorId = rekomendasi.DaftarKolaborator.Select(x => x.Id).ToArray(),
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var resultId = IdRekomendasi.Create(vm.Id);
        if (resultId.IsFailure) return BadRequest();

        var rekomendasi = await _repositoriRekomendasi.Get(resultId.Value);
        if (rekomendasi is null) return NotFound();

        if (vm.DokumenPendukung is not null)
        {
            var fileResult = await _fileService.UploadFile<TambahVM>(vm.DokumenPendukung, "/rekomendasi_produk", [".pdf"], 0, long.MaxValue);
            if (fileResult.IsFailure)
            {
                ModelState.AddModelError(nameof(TambahVM.DokumenPendukung), fileResult.Error.Message);
                return View(vm);
            }

            rekomendasi.DokumenPendukung = fileResult.Value;
        }

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

        var produkResult = IdProduk.Create(vm.ProdukId);
        if (produkResult.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.ProdukId), produkResult.Error.Message);
            return View(vm);
        }

        var produk = await _repositoriProduk.Get(produkResult.Value);
        if (produk is null)
        {
            ModelState.AddModelError(nameof(TambahVM.ProdukId), $"Produk dengan Id '{vm.ProdukId}' tidak ditemukan");
            return View(vm);
        }

        rekomendasi.Judul = vm.Judul;
        rekomendasi.Dekripsi = vm.Dekripsi;
        rekomendasi.Anggaran = vm.Anggaran;
        rekomendasi.HasilYangDiharapkan = vm.HasilYangDiharapkan;
        rekomendasi.KategoriPengembangan = vm.KategoriPengembangan;
        rekomendasi.PemberiRekomendasi = vm.PemberiRekomendasi;
        rekomendasi.StatusImplementasi = vm.StatusImplementasi;
        rekomendasi.StrategiYangDirekomendasikan = vm.StrategiYangDirekomendasikan;
        rekomendasi.TujuanPengembangan = vm.TujuanPengembangan;
        rekomendasi.TimelineRekomendasi = vm.TimelineRekomendasi;
        rekomendasi.ProdukTerkait = produk;
        rekomendasi.DaftarKolaborator = daftarKolaborator;

        _repositoriRekomendasi.Update(rekomendasi);
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
        var resultId = IdRekomendasi.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var rekomendasi = await _repositoriRekomendasi.Get(resultId.Value);
        if (rekomendasi is null) return NotFound();

        _repositoriRekomendasi.Delete(rekomendasi);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure) return StatusCode(StatusCodes.Status500InternalServerError);

        return RedirectToAction(nameof(Index));
    }
}
