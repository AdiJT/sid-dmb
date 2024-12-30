using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.CollaborationFunction.ModulManajemenEvent.PengelolaanEvent;
using SidDmb.Domain.MasterDataFunction.ModulBudaya;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.ArtefakBudayas;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.SeniBudayas;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.SitusBudayas;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.UpacaraBudayas;
using SidDmb.Domain.MasterDataFunction.ModulPreneur.ProdukLokals;
using SidDmb.Domain.MasterDataFunction.ModulWisata.DestinasiWisatas;

namespace SidDmb.Web.Controllers;

public class AtraksiController : Controller
{
    private readonly IRepositoriDestinasiWisata _repositoriDestinasiWisata;
    private readonly IRepositoriProdukLokal _repositoriProdukLokal;
    private readonly IRepositoriArtefakBudaya _repositoriArtefakBudaya;
    private readonly IRepositoriSitusBudaya _repositoriSitusBudaya;
    private readonly IRepositoriSeniBudaya _repositoriSeniBudaya;
    private readonly IRepositoriUpacaraBudaya _repositoriUpacaraBudaya;
    private readonly IRepositoriEvent _repositoriEvent;
    private readonly IRepositoriKomentar _repositoriKomentar;
    private readonly IUnitOfWork _unitOfWork;

    public AtraksiController(
        IRepositoriDestinasiWisata repositoriDestinasiWisata,
        IRepositoriProdukLokal repositoriProdukLokal,
        IRepositoriArtefakBudaya repositoriArtefakBudaya,
        IRepositoriSitusBudaya repositoriSitusBudaya,
        IRepositoriSeniBudaya repositoriSeniBudaya,
        IRepositoriUpacaraBudaya repositoriUpacaraBudaya,
        IRepositoriEvent repositoriEvent,
        IRepositoriKomentar repositoriKomentar,
        IUnitOfWork unitOfWork)
    {
        _repositoriDestinasiWisata = repositoriDestinasiWisata;
        _repositoriProdukLokal = repositoriProdukLokal;
        _repositoriArtefakBudaya = repositoriArtefakBudaya;
        _repositoriSitusBudaya = repositoriSitusBudaya;
        _repositoriSeniBudaya = repositoriSeniBudaya;
        _repositoriUpacaraBudaya = repositoriUpacaraBudaya;
        _repositoriEvent = repositoriEvent;
        _repositoriKomentar = repositoriKomentar;
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index() => View();

    public async Task<IActionResult> Destinasi() => View(await _repositoriDestinasiWisata.GetAll());

    public async Task<IActionResult> Artefak() => View(await _repositoriArtefakBudaya.GetAll());

    public async Task<IActionResult> Seni() => View(await _repositoriSeniBudaya.GetAll());

    public async Task<IActionResult> Situs() => View(await _repositoriSitusBudaya.GetAll());

    public async Task<IActionResult> Upacara() => View(await _repositoriUpacaraBudaya.GetAll());

    public async Task<IActionResult> ProdukLokal() => View(await _repositoriProdukLokal.GetAll());

    public async Task<IActionResult> DetailDestinasi(string id)
    {
        var resultId = IdDestinasi.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var destinasi = await _repositoriDestinasiWisata.Get(resultId.Value);
        if (destinasi is null) return NotFound();

        return View(destinasi);
    }

    public async Task<IActionResult> DetailArtefak(string id)
    {
        var resultId = IdArtefak.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var artefak = await _repositoriArtefakBudaya.Get(resultId.Value);
        if (artefak is null) return NotFound();

        return View(artefak);
    }

    public async Task<IActionResult> DetailSeni(string id)
    {
        var resultId = IdSeni.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var seni = await _repositoriSeniBudaya.Get(resultId.Value);
        if (seni is null) return NotFound();

        return View(seni);
    }

    public async Task<IActionResult> DetailSitus(string id)
    {
        var resultId = IdSitus.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var situs = await _repositoriSitusBudaya.Get(resultId.Value);
        if (situs is null) return NotFound();

        return View(situs);
    }

    public async Task<IActionResult> DetailUpacara(string id)
    {
        var resultId = IdUpacara.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var upacara = await _repositoriUpacaraBudaya.Get(resultId.Value);
        if (upacara is null) return NotFound();

        return View(upacara);
    }

    public async Task<IActionResult> DetailProdukLokal(string id)
    {
        var resultId = IdProduk.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var produk = await _repositoriProdukLokal.Get(resultId.Value);
        if (produk is null) return NotFound();

        return View(produk);
    }

    [HttpPost]
    public async Task<IActionResult> TambahKomentarArtefak(string id, string nama, string isi, double rating)
    {
        var resultId = IdArtefak.Create(id);
        if(resultId.IsFailure) return BadRequest();

        var artefak = await _repositoriArtefakBudaya.Get(resultId.Value);
        if (artefak is null) return NotFound();

        var komentar = new Komentar
        {
            Id = 0,
            Nama = nama,
            Isi = isi,
            Rating = rating,
            ArtefakBudaya = artefak
        };

        artefak.DaftarKomentar.Add(komentar);

        _repositoriKomentar.Add(komentar);
        _repositoriArtefakBudaya.Update(artefak);

        var result = await _unitOfWork.SaveChangesAsync();
        if(result.IsFailure) return BadRequest();

        return RedirectToAction(nameof(DetailArtefak), new { id });
    }

    [HttpPost]
    public async Task<IActionResult> TambahKomentarSitus(string id, string nama, string isi, double rating)
    {
        var resultId = IdSitus.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var situs = await _repositoriSitusBudaya.Get(resultId.Value);
        if (situs is null) return NotFound();

        var komentar = new Komentar
        {
            Id = 0,
            Nama = nama,
            Isi = isi,
            Rating = rating,
            SitusBudaya = situs
        };

        situs.DaftarKomentar.Add(komentar);

        _repositoriKomentar.Add(komentar);
        _repositoriSitusBudaya.Update(situs);

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure) return BadRequest();

        return RedirectToAction(nameof(DetailSitus), new { id });
    }

    [HttpPost]
    public async Task<IActionResult> TambahKomentarSeni(string id, string nama, string isi, double rating)
    {
        var resultId = IdSeni.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var seni = await _repositoriSeniBudaya.Get(resultId.Value);
        if (seni is null) return NotFound();

        var komentar = new Komentar
        {
            Id = 0,
            Nama = nama,
            Isi = isi,
            Rating = rating,
            SeniBudaya = seni
        };

        seni.DaftarKomentar.Add(komentar);

        _repositoriKomentar.Add(komentar);
        _repositoriSeniBudaya.Update(seni);

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure) return BadRequest();

        return RedirectToAction(nameof(DetailSeni), new { id });
    }

    [HttpPost]
    public async Task<IActionResult> TambahKomentarUpacara(string id, string nama, string isi, double rating)
    {
        var resultId = IdUpacara.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var upacara = await _repositoriUpacaraBudaya.Get(resultId.Value);
        if (upacara is null) return NotFound();

        var komentar = new Komentar
        {
            Id = 0,
            Nama = nama,
            Isi = isi,
            Rating = rating,
            UpacaraBudaya = upacara
        };

        upacara.DaftarKomentar.Add(komentar);

        _repositoriKomentar.Add(komentar);
        _repositoriUpacaraBudaya.Update(upacara);

        var result = await _unitOfWork.SaveChangesAsync();
        if (result.IsFailure) return BadRequest();

        return RedirectToAction(nameof(DetailUpacara), new { id });
    }
}
