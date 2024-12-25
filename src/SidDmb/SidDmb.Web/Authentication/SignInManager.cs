using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using SidDmb.Domain.Authentication;
using SidDmb.Domain.Shared;
using System.Security.Claims;

namespace SidDmb.Web.Authentication;

public class SignInManager : ISignInManager
{
    private readonly IRepositoriAppUser _repositoriAppUser;
    private readonly IPasswordHasher<AppUser> _passwordHasher;
    private readonly ILogger<SignInManager> _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SignInManager(
        IRepositoriAppUser repositoriAppUser,
        IPasswordHasher<AppUser> passwordHasher,
        ILogger<SignInManager> logger,
        IHttpContextAccessor httpContextAccessor)
    {
        _repositoriAppUser = repositoriAppUser;
        _passwordHasher = passwordHasher;
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<AppUser?> GetUser()
    {
        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext is null) return null;

        var userName = httpContext.User.Identity?.Name;
        if(userName is null) return null;

        var appUser = await _repositoriAppUser.GetByUserName(userName);

        return appUser;
    }

    public async Task<Result> Login(string username, string password, bool rememberMe)
    {
        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext is null)
            return new Error("Login.Gagal", "Tidak ada HttpContext aktif");

        var appUser = await _repositoriAppUser.GetByUserName(username);
        if (appUser is null)
            return new Error("Login.AkunTidakDitemukan", $"Akun '{username}' tidak ditemukan");

        if (_passwordHasher.VerifyHashedPassword(appUser, appUser.PasswordHash, password) == PasswordVerificationResult.Failed)
            return new Error("Login.PasswordSalah", "Password yang dimasukan salah!");

        List<Claim> claims = [
            new Claim(ClaimTypes.Name, appUser.UserName),
            new Claim(ClaimTypes.Role, appUser.Role)
        ];

        var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var claimPrincipal = new ClaimsPrincipal(claimIdentity);
        var authProperties = new AuthenticationProperties { IsPersistent = rememberMe };

        await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, authProperties);

        _logger.LogInformation("{@userName} logged in at {@time}", username, DateTime.Now);

        return Result.Success();
    }

    public async Task Logout()
    {
        var httpContext = _httpContextAccessor.HttpContext;

        if (httpContext is not null)
            await httpContext.SignOutAsync();
    }
}