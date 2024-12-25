using SidDmb.Domain.Authentication;
using SidDmb.Domain.Shared;

namespace SidDmb.Web.Authentication;

public interface ISignInManager
{
    Task<Result> Login(string username, string password, bool rememberMe);
    Task Logout();
    Task<AppUser?> GetUser();
}