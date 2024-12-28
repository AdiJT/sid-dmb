using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Authentication;
using SidDmb.Domain.CollaborationFunction;
using SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi.MateriEdukasiDanPembelajaran;
using SidDmb.Infrastructure.Services.FileUpload;

namespace SidDmb.Web.Areas.Dashboard.CollaborationFunction.ModulPelatihanEdukasi.MateriEdukasiDanPembelajaran;

[Area("Dashboard")]
[Authorize(Roles = UserRoles.ADMIN)]
public class MateriEdukasiController : Controller
{
    private readonly IRepositoriMateri _repositoriMateri;
    private readonly IRepositoriKolaborator _repositoriKolaborator;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFileService _fileService;

    public MateriEdukasiController(
        IRepositoriMateri repositoriMateri,
        IRepositoriKolaborator repositoriKolaborator,
        IUnitOfWork unitOfWork,
        IFileService fileService)
    {
        _repositoriMateri = repositoriMateri;
        _repositoriKolaborator = repositoriKolaborator;
        _unitOfWork = unitOfWork;
        _fileService = fileService;
    }

    public async Task<IActionResult> Index() => View(await  _repositoriMateri.GetAll());
}
