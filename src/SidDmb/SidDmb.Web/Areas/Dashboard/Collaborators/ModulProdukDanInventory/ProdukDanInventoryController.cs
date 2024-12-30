using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Authentication;
using SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.ManajemenDistribusi;
using SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.ManajemenProduk;
using SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.SertifikasiDanLegalitas;
using SidDmb.Domain.MasterDataFunction.ModulPrima.KegiatanPrimas;
using SidDmb.Web.Authentication;

namespace SidDmb.Web.Areas.Dashboard.Collaborators.ModulProdukDanInventory;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.KOLABORATOR)]
public class ProdukDanInventoryController : Controller
{
    private readonly IRepositoriDistribusi _repositoriDistribusi;
    private readonly IRepositoriProduk _repositoriProduk;
    private readonly IRepositoriSertifikasi _repositoriSertifikasi;
    private readonly IJoinEntityRepository<KolaboratorSertifikasi> _joinEntityRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISignInManager _signInManager;

    public ProdukDanInventoryController(
        IRepositoriDistribusi repositoriDistribusi,
        IRepositoriProduk repositoriProduk,
        IRepositoriSertifikasi repositoriSertifikasi,
        IJoinEntityRepository<KolaboratorSertifikasi> joinEntityRepository,
        IUnitOfWork unitOfWork,
        ISignInManager signInManager)
    {
        _repositoriDistribusi = repositoriDistribusi;
        _repositoriProduk = repositoriProduk;
        _repositoriSertifikasi = repositoriSertifikasi;
        _joinEntityRepository = joinEntityRepository;
        _unitOfWork = unitOfWork;
        _signInManager = signInManager;
    }

    public async Task<IActionResult> ManajemenDistribusi()
    {
        var appUser = await _signInManager.GetUser();
        if (appUser is null || appUser.Role != UserRoles.KOLABORATOR || appUser.Kolaborator is null)
            return StatusCode(StatusCodes.Status403Forbidden);

        return View((await _repositoriDistribusi.GetAll()).Where(x => x.DaftarKolaborator.Contains(appUser.Kolaborator)).ToList());
    }

    public async Task<IActionResult> ManajemenProduk()
    {
        var appUser = await _signInManager.GetUser();
        if (appUser is null || appUser.Role != UserRoles.KOLABORATOR || appUser.Kolaborator is null)
            return StatusCode(StatusCodes.Status403Forbidden);

        return View((await _repositoriProduk.GetAll()).Where(x => x.DaftarKolaborator.Contains(appUser.Kolaborator)).ToList());
    }

    public async Task<IActionResult> SertifikasiDanLegalitas()
    {
        var appUser = await _signInManager.GetUser();
        if (appUser is null || appUser.Role != UserRoles.KOLABORATOR || appUser.Kolaborator is null)
            return StatusCode(StatusCodes.Status403Forbidden);

        return View((await _repositoriSertifikasi.GetAll()).Where(x => x.DaftarKolaborator.Contains(appUser.Kolaborator)).ToList());
    }

    public async Task<IActionResult> SertifikasiDanLegalitasDetail(string id)
    {
        var appUser = await _signInManager.GetUser();
        if (appUser is null || appUser.Role != UserRoles.KOLABORATOR || appUser.Kolaborator is null)
            return StatusCode(StatusCodes.Status403Forbidden);

        var resultId = IdSertifikasi.Create(id);
        if (resultId.IsFailure) return BadRequest();

        var sertifikasi = await _repositoriSertifikasi.Get(resultId.Value);
        if (sertifikasi is null) return NotFound();

        var kolaboratorSertifikasi = sertifikasi.DaftarKolaboratorSertifikasi.FirstOrDefault(x => x.Entity2 == appUser.Kolaborator);
        if (kolaboratorSertifikasi is null) return NotFound();

        return View(new SertifikasiDanLegalitasDetailVM
        {
            Id = id,
            Komentar = kolaboratorSertifikasi.Komentar
        });
    }

    [HttpPost]
    public async Task<IActionResult> SertifikasiDanLegalitasDetail(SertifikasiDanLegalitasDetailVM vm)
    {
        var appUser = await _signInManager.GetUser();
        if (appUser is null || appUser.Role != UserRoles.KOLABORATOR || appUser.Kolaborator is null)
            return StatusCode(StatusCodes.Status403Forbidden);

        var resultId = IdSertifikasi.Create(vm.Id);
        if (resultId.IsFailure) return BadRequest();

        var sertifikasi = await _repositoriSertifikasi.Get(resultId.Value);
        if (sertifikasi is null) return NotFound();

        var kolaboratorSertifikasi = sertifikasi.DaftarKolaboratorSertifikasi.FirstOrDefault(x => x.Entity2 == appUser.Kolaborator);
        if (kolaboratorSertifikasi is null) return NotFound();

        kolaboratorSertifikasi.Komentar = vm.Komentar;
        _joinEntityRepository.Update(kolaboratorSertifikasi);
        var result = await _unitOfWork.SaveChangesAsync();
        if(result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, result.Error.Message);
            return View(vm);
        }

        return RedirectToAction(nameof(SertifikasiDanLegalitas));
    }
}