using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.MasterDataFunction.ModulPrima.KegiatanPrimas;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulPrima.KegiatanPrimas;

internal class KolaboratorKegiatanPrimaConfiguration : IEntityTypeConfiguration<KolaboratorKegiatanPrima>
{
    public void Configure(EntityTypeBuilder<KolaboratorKegiatanPrima> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.DaftarKegiatanPrima).WithMany(x => x.KolaboratorKegiatan);
    }
}
