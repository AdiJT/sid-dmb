﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.Authentication;
using SidDmb.Web.Areas.Dashboard.Models.HomeModels;
using SidDmb.Web.Authentication;

namespace SidDmb.Web.Areas.Dashboard.Controllers;

[Area("Dashboard")]
public class HomeController : Controller
{
    private readonly ISignInManager _signInManager;

    public HomeController(ISignInManager signInManager)
    {
        _signInManager = signInManager;
    }

    [Authorize(Roles = $"{UserRoles.ADMIN}, {UserRoles.KOLABORATOR}")]
    public async Task<IActionResult> Index()
    {
        var appUser = await _signInManager.GetUser();

        if (appUser is not null && appUser.Role == UserRoles.KOLABORATOR)
            return RedirectToAction("KegiatanPrima", "Prima");

        return View();
    }

    [Route("[controller]/[action]")]
    [AllowAnonymous]
    public IActionResult Login(string? returnUrl = null)
    {
        return View(new LoginVM
        {
            ReturnUrl = returnUrl ?? Url.Action(nameof(Index))!
        });
    }

    [HttpPost]
    [Route("[controller]/[action]")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginVM vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        var result = await _signInManager.Login(vm.UserName, vm.Password, vm.RememberMe);
        if (result.IsFailure)
        {
            ModelState.AddModelError(string.Empty, result.Error.Message);
            return View(vm);
        }

        return Redirect(vm.ReturnUrl);
    }

    [Route("[controller]/[action]")]
    [Authorize(Roles = $"{UserRoles.ADMIN}, {UserRoles.KOLABORATOR}")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.Logout();

        return RedirectToAction("Index", "Home", new { Area = "" });
    }
}