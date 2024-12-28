using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.MasterDataFunction.ModulWisata.KalenderAcaras;

namespace SidDmb.Web.Controllers;

public class EventController : Controller
{
    private readonly IRepositoriKalenderAcara _repositoriKalenderAcara;

    public EventController(IRepositoriKalenderAcara repositoriKalenderAcara)
    {
        _repositoriKalenderAcara = repositoriKalenderAcara;
    }

    public async Task<IActionResult> Index() => View((await _repositoriKalenderAcara.GetAll()).OrderBy(k => k.TanggalDanWaktu).ToList());

    public async Task<IActionResult> Detail(string id)
    { 
        var resultId = IdAcara.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var kalenderAcara = await _repositoriKalenderAcara.Get(resultId.Value);
        if(kalenderAcara is null) return NotFound();

        return View(kalenderAcara);
    }
}
