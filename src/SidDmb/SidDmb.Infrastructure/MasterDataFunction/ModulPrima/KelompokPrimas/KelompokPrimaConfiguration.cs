using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.MasterDataFunction.ModulPrima.KelompokPrimas;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulPrima.KelompokPrimas;

internal class KelompokPrimaConfiguration : IEntityTypeConfiguration<KelompokPrima>
{
    public void Configure(EntityTypeBuilder<KelompokPrima> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(i => i.Value, s => IdKelompok.Create(s).Value);

        builder.HasMany(x => x.DaftarKegiatanPrima).WithOne(x => x.KelompokPrima);
    }
}