using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Authentication;
using SidDmb.Domain.CollaborationFunction;
using SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi.PeningkatanKapasitas;
using SidDmb.Infrastructure.Services.FileUpload;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulPelatihanEdukasi.PeningkatanKapasitas;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.ADMIN)]
public class PeningkatanKapasitasController : Controller
{
    private readonly IRepositoriPelatihan _repositoriPelatihan;
    private readonly IRepositoriKolaborator _repositoriKolaborator;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileService _fileService;

    public PeningkatanKapasitasController(
        IRepositoriPelatihan repositoriPelatihan,
        IRepositoriKolaborator repositoriKolaborator,
        IUnitOfWork unitOfWork,
        IFileService fileService)
    {
        _repositoriPelatihan = repositoriPelatihan;
        _repositoriKolaborator = repositoriKolaborator;
        _unitOfWork = unitOfWork;
        _fileService = fileService;
    }

    public async Task<IActionResult> Index() => View(await _repositoriPelatihan.GetAll());

    public IActionResult Tambah() => View(new TambahVM());

    [HttpPost]
    public async Task<IActionResult> Tambah(TambahVM vm)
    {
        if (!ModelState.IsValid) return View(vm);

        var fileResult = await _fileService.UploadFile<TambahVM>(vm.DokumenDanMedia, "/pelatihan", [".pptx", ".pdf"], 0, long.MaxValue);
        if (fileResult.IsFailure)
        {
            ModelState.AddModelError(nameof(TambahVM.DokumenDanMedia), fileResult.Error.Message);
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

        var pelatihan = new Pelatihan
        {
            Id = await IdPelatihan.Generate(_repositoriPelatihan),
            Nama = vm.Nama,
            Dekripsi = vm.Dekripsi,
            Durasi = vm.Durasi,
            EvaluasiPeserta = vm.EvaluasiPeserta,
            Fasilitator = vm.Fasilitator,
            FeedbackPeserta = vm.FeedbackPeserta,
            JumlahPeserta = vm.JumlahPeserta,
            TanggalPelaksanaan = vm.TanggalPelaksanaan,
            Kategori = vm.Kategori,
            Lokasi = vm.Lokasi,
            Materi = vm.Materi,
            Penyelenggara = vm.Penyelenggara,
            DokumenDanMedia = fileResult.Value,
            TargetPeserta = vm.TargetPeserta.Aggregate(vm.TargetPeserta.First(), (acc, f) => acc | f),
            DaftarKolaborator = daftarKolaborator
        };

        _repositoriPelatihan.Add(pelatihan);
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
        var resultId = IdPelatihan.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var pelatihan = await _repositoriPelatihan.Get(resultId.Value);
        if (pelatihan is null) return NotFound();

        return View(new EditVM
        {
            Id = id,
            Nama = pelatihan.Nama,
            Dekripsi = pelatihan.Dekripsi,
            Durasi = pelatihan.Durasi,
            EvaluasiPeserta = pelatihan.EvaluasiPeserta,
            Fasilitator = pelatihan.Fasilitator,
            FeedbackPeserta = pelatihan.FeedbackPeserta,
            JumlahPeserta = pelatihan.JumlahPeserta,
            TanggalPelaksanaan = pelatihan.TanggalPelaksanaan,
            Kategori = pelatihan.Kategori,
            Lokasi = pelatihan.Lokasi,
            Materi = pelatihan.Materi,
            Penyelenggara = pelatihan.Penyelenggara,
            DaftarKolaboratorId = pelatihan.DaftarKolaborator.Select(x => x.Id).ToArray(),
            TargetPeserta = Enum.GetValues<TargetPeserta>().Where(x => pelatihan.TargetPeserta.HasFlag(x)).ToArray(),
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditVM vm)
    {
        var resultId = IdPelatihan.Create(vm.Id);
        if (resultId.IsFailure) return BadRequest();

        var pelatihan = await _repositoriPelatihan.Get(resultId.Value);
        if (pelatihan is null) return NotFound();

        if (vm.DokumenDanMedia is not null)
        {
            var fileResult = await _fileService.UploadFile<EditVM>(vm.DokumenDanMedia, "/pelatihan", [".pptx", ".pdf"], 0, long.MaxValue);
            if (fileResult.IsFailure)
            {
                ModelState.AddModelError(nameof(EditVM.DokumenDanMedia), fileResult.Error.Message);
                return View(vm);
            }

            pelatihan.DokumenDanMedia = fileResult.Value;
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

        pelatihan.Nama = vm.Nama;
        pelatihan.Dekripsi = vm.Dekripsi;
        pelatihan.Durasi = vm.Durasi;
        pelatihan.EvaluasiPeserta = vm.EvaluasiPeserta;
        pelatihan.Fasilitator = vm.Fasilitator;
        pelatihan.FeedbackPeserta = vm.FeedbackPeserta;
        pelatihan.JumlahPeserta = vm.JumlahPeserta;
        pelatihan.TanggalPelaksanaan = vm.TanggalPelaksanaan;
        pelatihan.Kategori = vm.Kategori;
        pelatihan.Lokasi = vm.Lokasi;
        pelatihan.Materi = vm.Materi;
        pelatihan.Penyelenggara = vm.Penyelenggara;
        pelatihan.TargetPeserta = vm.TargetPeserta.Aggregate(vm.TargetPeserta.First(), (acc, f) => acc | f);
        pelatihan.DaftarKolaborator = daftarKolaborator;

        Console.WriteLine($"{(int)pelatihan.TargetPeserta:B}");
        Console.WriteLine($"{string.Join(", ", vm.TargetPeserta.Select(x => $"{(int)x:B}"))}");

        _repositoriPelatihan.Update(pelatihan);
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
        var resultId = IdPelatihan.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var pelatihan = await _repositoriPelatihan.Get(resultId.Value);
        if (pelatihan is null) return NotFound();

        _repositoriPelatihan.Delete(pelatihan);
        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure) return StatusCode(StatusCodes.Status500InternalServerError);

        return RedirectToAction(nameof(Index));
    }
}