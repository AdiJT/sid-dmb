using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.SitusBudayas;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulBudaya.SitusBudayas;

internal class SitusBudayaConfiguration : IEntityTypeConfiguration<SitusBudaya>
{
    public void Configure(EntityTypeBuilder<SitusBudaya> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(x => x.Value, s => IdSitus.Create(s).Value);

        builder.HasMany(x => x.DaftarFasilitas).WithMany(x => x.DaftarSitusBudaya);
    }
}