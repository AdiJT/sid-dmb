using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.CollaborationFunction.ModulManajemenEvent.PengelolaanEvent;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.ArtefakBudayas;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.SeniBudayas;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.SitusBudayas;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.UpacaraBudayas;
using SidDmb.Domain.MasterDataFunction.ModulPreneur.ProdukLokals;
using SidDmb.Domain.MasterDataFunction.ModulWisata.DestinasiWisatas;
using SidDmb.Web.Models;
using SidDmb.Web.Models.Home;
using System.Diagnostics;

namespace SidDmb.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepositoriDestinasiWisata _repositoriDestinasiWisata;
    private readonly IRepositoriProdukLokal _repositoriProdukLokal;
    private readonly IRepositoriArtefakBudaya _repositoriArtefakBudaya;
    private readonly IRepositoriSitusBudaya _repositoriSitusBudaya;
    private readonly IRepositoriSeniBudaya _repositoriSeniBudaya;
    private readonly IRepositoriUpacaraBudaya _repositoriUpacaraBudaya;
    private readonly IRepositoriEvent _repositoriEvent;

    public HomeController(
        ILogger<HomeController> logger,
        IRepositoriDestinasiWisata repositoriDestinasiWisata,
        IRepositoriProdukLokal repositoriProdukLokal,
        IRepositoriArtefakBudaya repositoriArtefakBudaya,
        IRepositoriSitusBudaya repositoriSitusBudaya,
        IRepositoriSeniBudaya repositoriSeniBudaya,
        IRepositoriUpacaraBudaya repositoriUpacaraBudaya,
        IRepositoriEvent repositoriEvent)
    {
        _logger = logger;
        _repositoriDestinasiWisata = repositoriDestinasiWisata;
        _repositoriProdukLokal = repositoriProdukLokal;
        _repositoriArtefakBudaya = repositoriArtefakBudaya;
        _repositoriSitusBudaya = repositoriSitusBudaya;
        _repositoriSeniBudaya = repositoriSeniBudaya;
        _repositoriUpacaraBudaya = repositoriUpacaraBudaya;
        _repositoriEvent = repositoriEvent;
    }

    public async Task<IActionResult> Index()
    {
        return View(new IndexVM
        {
            DestinasiWisata = (await _repositoriDestinasiWisata.GetAll()).OrderBy(x => x.Nama).FirstOrDefault(),
            SitusBudaya = (await _repositoriSitusBudaya.GetAll()).OrderBy(x => x.Nama).FirstOrDefault(),
            SeniBudaya = (await _repositoriSeniBudaya.GetAll()).OrderBy(x => x.Nama).FirstOrDefault(),
            ArtefakBudaya = (await _repositoriArtefakBudaya.GetAll()).OrderBy(x => x.Nama).FirstOrDefault(),
            ProdukLokal = (await _repositoriProdukLokal.GetAll()).OrderBy(x => x.Nama).FirstOrDefault(),
            UpacaraBudaya = (await _repositoriUpacaraBudaya.GetAll()).OrderBy(x => x.Nama).FirstOrDefault(),
            DaftarEvent = (await _repositoriEvent.GetAll()).OrderBy(x => x.TanggalWaktu).TakeLast(4).ToList()
        });
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
