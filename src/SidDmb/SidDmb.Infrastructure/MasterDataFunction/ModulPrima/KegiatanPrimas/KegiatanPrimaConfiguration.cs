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

        builder.HasMany(x => x.DaftarKolabolator)
            .WithMany(x => x.DaftarKegiatanPrima)
            .UsingEntity<KolaboratorKegiatanPrima>(
                l => l.HasOne(x => x.Entity2).WithMany(k => k.DaftarKolaboratorKegiatanPrima).HasForeignKey(x => x.Entity2Id),
                r => r.HasOne(x => x.Entity1).WithMany(k => k.DaftarKolaboratorKegiatan).HasForeignKey(x => x.Entity1Id));
    }
}