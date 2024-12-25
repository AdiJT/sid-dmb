using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Authentication;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.SeniBudayas;
using SidDmb.Infrastructure.Services.FileUpload;

namespace SidDmb.Web.Areas.Dashboard.MasterDataFunction.ModulBudaya.SeniBudayas;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.ADMIN)]
public class SeniBudayaController : Controller
{
    private readonly IRepositoriSeniBudaya _repositoriSeniBudaya;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileService _fileService;

    public SeniBudayaController(
        IRepositoriSeniBudaya repositoriSeniBudaya,
        IUnitOfWork unitOfWork,
        IFileService fileService)
    {
        _repositoriSeniBudaya = repositoriSeniBudaya;
        _unitOfWork = unitOfWork;
        _fileService = fileService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _repositoriSeniBudaya.GetAll());
    }
}
