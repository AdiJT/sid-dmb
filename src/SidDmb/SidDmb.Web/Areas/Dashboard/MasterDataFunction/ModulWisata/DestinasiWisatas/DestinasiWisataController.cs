using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Authentication;
using SidDmb.Domain.MasterDataFunction.ModulWisata.DestinasiWisatas;
using SidDmb.Infrastructure.Services.FileUpload;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulWisata.DestinasiWisatas;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.ADMIN)]
public class DestinasiWisataController : Controller
{
    private readonly IRepositoriDestinasiWisata _repositoriDestinasiWisata;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileService _fileService;

    public DestinasiWisataController(
        IRepositoriDestinasiWisata repositoriDestinasiWisata,
        IUnitOfWork unitOfWork,
        IFileService fileService)
    {
        _repositoriDestinasiWisata = repositoriDestinasiWisata;
        _unitOfWork = unitOfWork;
        _fileService = fileService;
    }

    public async Task<IActionResult> Index() => View(await _repositoriDestinasiWisata.GetAll());

    public IActionResult Tambah() => View(new TambahVM());

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var fileResult = await _fileService.UploadFile<TambahVM>(vm.Foto, "/destinasi_wisata", [".jpg", ".jpeg", ".png"], 0, long.MaxValue);
        if (fileResult.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.Foto), fileResult.Error.Message);
            return View(vm);
        }

        var destinasiWisata = new DestinasiWisata
        {
            Id = await IdDestinasi.Generate(_repositoriDestinasiWisata),
            Nama = vm.Nama,
            Deskripsi = vm.Deskripsi,
            Alamat = vm.Alamat,
            HargaTiketMasuk = vm.HargaTiketMasuk,
            InformasiKontak = vm.InformasiKontak,
            JamOperasional = vm.JamOperasional,
            Kategori = vm.Kategori,
            PengelolaDestinasi = vm.PengelolaDestinasi,
            Rating = vm.Rating,
            Foto = fileResult.Value,
            TitikKoordinat = new Point(vm.Lng, vm.Lat),
            StatusOperasional = vm.StatusOperasional,
            DaftarAktivitas = vm.DaftarAktivitas,
            DaftarFasilitas = vm.DaftarFasilitas
        };

        _repositoriDestinasiWisata.Add(destinasiWisata);
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
        var resultId = IdDestinasi.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var destinasiWisata = await _repositoriDestinasiWisata.Get(resultId.Value);
        if (destinasiWisata is null) return NotFound();

        return View(new EditVM
        {
            Id = id,
            Nama = destinasiWisata.Nama,
            Deskripsi = destinasiWisata.Deskripsi,
            Alamat = destinasiWisata.Alamat,
            HargaTiketMasuk = destinasiWisata.HargaTiketMasuk,
            DaftarAktivitas = destinasiWisata.DaftarAktivitas,
            DaftarFasilitas = destinasiWisata.DaftarFasilitas,
            InformasiKontak = destinasiWisata.InformasiKontak,
            JamOperasional = destinasiWisata.JamOperasional,
            Kategori = destinasiWisata.Kategori,
            Lat = destinasiWisata.TitikKoordinat.Y,
            Lng = destinasiWisata.TitikKoordinat.X,
            PengelolaDestinasi = destinasiWisata.PengelolaDestinasi,
            Rating = destinasiWisata.Rating,
            StatusOperasional = destinasiWisata.StatusOperasional
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        var resultId = IdDestinasi.Create(vm.Id);
        if (resultId.IsFailure) return BadRequest();

        var destinasiWisata = await _repositoriDestinasiWisata.Get(resultId.Value);
        if (destinasiWisata is null) return NotFound();

        if (vm.Foto is not null)
        {
            var fileResult = await _fileService.UploadFile<EditVM>(vm.Foto, "/destinasi_wisata", [".jpg", ".jpeg", ".png"], 0, long.MaxValue);
            if (fileResult.IsFailure)
            {
                ModelState.AddModelError(nameof(EditVM.Foto), fileResult.Error.Message);
                return View(vm);
            }

            destinasiWisata.Foto = fileResult.Value;
        }

        destinasiWisata.Nama = vm.Nama;
        destinasiWisata.Deskripsi = vm.Deskripsi;
        destinasiWisata.Alamat = vm.Alamat;
        destinasiWisata.HargaTiketMasuk = vm.HargaTiketMasuk;
        destinasiWisata.DaftarAktivitas = vm.DaftarAktivitas;
        destinasiWisata.DaftarFasilitas = vm.DaftarFasilitas;
        destinasiWisata.InformasiKontak = vm.InformasiKontak;
        destinasiWisata.JamOperasional = vm.JamOperasional;
        destinasiWisata.Kategori = vm.Kategori;
        destinasiWisata.TitikKoordinat = new Point(vm.Lng, vm.Lat);
        destinasiWisata.PengelolaDestinasi = vm.PengelolaDestinasi;
        destinasiWisata.Rating = vm.Rating;
        destinasiWisata.StatusOperasional = vm.StatusOperasional;

        _repositoriDestinasiWisata.Update(destinasiWisata);
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
        var resultId = IdDestinasi.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var destinasiWisata = await _repositoriDestinasiWisata.Get(resultId.Value);
        if (destinasiWisata is null) return NotFound();

        _repositoriDestinasiWisata.Delete(destinasiWisata);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure) return StatusCode(StatusCodes.Status500InternalServerError);

        return RedirectToAction(nameof(Index));
    }
}