using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.SeniBudayas;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulBudaya.SeniBudayas;

internal class SeniBudayaConfiguration : IEntityTypeConfiguration<SeniBudaya>
{
    public void Configure(EntityTypeBuilder<SeniBudaya> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(i => i.Value, s => IdSeni.Create(s).Value);

        builder.HasMany(x => x.DaftarKomentar).WithOne(x => x.SeniBudaya);
    }
}
