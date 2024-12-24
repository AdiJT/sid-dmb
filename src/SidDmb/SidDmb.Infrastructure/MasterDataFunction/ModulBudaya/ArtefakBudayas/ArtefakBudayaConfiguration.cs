using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.ArtefakBudayas;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulBudaya.ArtefakBudayas;

internal class ArtefakBudayaConfiguration : IEntityTypeConfiguration<ArtefakBudaya>
{
    public void Configure(EntityTypeBuilder<ArtefakBudaya> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(i => i.Value, s => IdArtefak.Create(s).Value);

        builder.HasMany(x => x.DaftarKomentar).WithOne(x => x.ArtefakBudaya);
    }
}