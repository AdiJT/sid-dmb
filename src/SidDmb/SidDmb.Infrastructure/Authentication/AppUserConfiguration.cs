using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.Authentication;
using SidDmb.Domain.CollaborationFunction;

namespace SidDmb.Infrastructure.Authentication;

internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Kolaborator).WithOne(k => k.AppUser).HasForeignKey<Kolaborator>("AppUserId");

        builder.HasData(
            new AppUser
            {
                Id = 1,
                UserName = "Admin",
                PasswordHash = "AQAAAAIAAYagAAAAEIvnLFelRQItxw7VYqY6lQ23tSsOmnZ3FMifozrOmDHUmPCZrAYjnbzfDR07zgFJjw==",
                Role = UserRoles.ADMIN
            }, 
            new AppUser
            {
                Id = 2,
                UserName = "Dinas Pariwisata",
                PasswordHash = "AQAAAAIAAYagAAAAEJhTWHliTZKRD57TRJFPsWpZgZsWxU21omcBx/HdNuyMFsj+2Ibhs2z2aCYVGwEUsw==",
                Role = UserRoles.KOLABORATOR
            },
            new AppUser
            {
                Id = 3,
                UserName = "Dinas Kebudayaan",
                PasswordHash = "AQAAAAIAAYagAAAAEJhTWHliTZKRD57TRJFPsWpZgZsWxU21omcBx/HdNuyMFsj+2Ibhs2z2aCYVGwEUsw==",
                Role = UserRoles.KOLABORATOR
            },
            new AppUser
            {
                Id = 4,
                UserName = "Dinas Koperasi UMKM",
                PasswordHash = "AQAAAAIAAYagAAAAEJhTWHliTZKRD57TRJFPsWpZgZsWxU21omcBx/HdNuyMFsj+2Ibhs2z2aCYVGwEUsw==",
                Role = UserRoles.KOLABORATOR
            },
            new AppUser
            {
                Id = 5,
                UserName = "DP3AP2",
                PasswordHash = "AQAAAAIAAYagAAAAEJhTWHliTZKRD57TRJFPsWpZgZsWxU21omcBx/HdNuyMFsj+2Ibhs2z2aCYVGwEUsw==",
                Role = UserRoles.KOLABORATOR
            },
            new AppUser
            {
                Id = 6,
                UserName = "Assosiacation",
                PasswordHash = "AQAAAAIAAYagAAAAEJhTWHliTZKRD57TRJFPsWpZgZsWxU21omcBx/HdNuyMFsj+2Ibhs2z2aCYVGwEUsw==",
                Role = UserRoles.KOLABORATOR
            },
            new AppUser
            {
                Id = 7,
                UserName = "BPOM",
                PasswordHash = "AQAAAAIAAYagAAAAEJhTWHliTZKRD57TRJFPsWpZgZsWxU21omcBx/HdNuyMFsj+2Ibhs2z2aCYVGwEUsw==",
                Role = UserRoles.KOLABORATOR
            },
            new AppUser
            {
                Id = 8,
                UserName = "Academics",
                PasswordHash = "AQAAAAIAAYagAAAAEJhTWHliTZKRD57TRJFPsWpZgZsWxU21omcBx/HdNuyMFsj+2Ibhs2z2aCYVGwEUsw==",
                Role = UserRoles.KOLABORATOR
            },
            new AppUser
            {
                Id = 9,
                UserName = "Media",
                PasswordHash = "AQAAAAIAAYagAAAAEJhTWHliTZKRD57TRJFPsWpZgZsWxU21omcBx/HdNuyMFsj+2Ibhs2z2aCYVGwEUsw==",
                Role = UserRoles.KOLABORATOR
            }
        );
    }
}