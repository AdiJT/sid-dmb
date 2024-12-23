using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.MasterDataFunction.ModulPrima.KegiatanPrimas;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulPrima.KegiatanPrimas;

internal class KegiatanPrimaConfiguration : IEntityTypeConfiguration<KegiatanPrima>
{
    public void Configure(EntityTypeBuilder<KegiatanPrima> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(i => i.Value, s => IdKegiatanPrima.Create(s).Value);

        builder.HasOne(x => x.KelompokPrima).WithMany(x => x.DaftarKegiatanPrima);
        builder.HasMany(x => x.KolaboratorKegiatan).WithMany(x => x.DaftarKegiatanPrima);
    }
}