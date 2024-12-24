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
    }
}