using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.MasterDataFunction.ModulPreneur.UnitUsahas;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulPrenuer.UnitUsahas;

internal class UnitUsahaConfiguration : IEntityTypeConfiguration<UnitUsaha>
{
    public void Configure(EntityTypeBuilder<UnitUsaha> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasConversion(i => i.Value, s => IdUnitUsaha.Create(s).Value);

        builder.HasMany(u => u.DaftarProduk).WithOne(p => p.UnitUsaha);
    }
}