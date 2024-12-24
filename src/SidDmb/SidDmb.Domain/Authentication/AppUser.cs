using SidDmb.Domain.Abstracts;
using SidDmb.Domain.CollaborationFunction;

namespace SidDmb.Domain.Authentication;

public class AppUser : Entity<int>
{
    public required string UserName { get; set; }
    public required string PasswordHash { get; set; }
    public required string Role { get; set; }

    public Kolaborator? Kolaborator { get; set; }
}

public static class UserRoles
{
    public const string ADMIN = "ADMIN";
    public const string KOLABORATOR = "KOLABORATOR";
}