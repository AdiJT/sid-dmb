using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.ManajemenDistribusi;

namespace SidDmb.Infrastructure.CollaborationFunction.ModulProdukDanInventory.ManajemenDistribusi;

internal class DistribusiConfiguration : IEntityTypeConfiguration<Distribusi>
{
    public void Configure(EntityTypeBuilder<Distribusi> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(i => i.Value, s => IdDistribusi.Create(s).Value);

        builder.HasOne(x => x.Produk).WithMany(x => x.DaftarDistribusi);
        builder.HasMany(x => x.DaftarKolaborator).WithMany(x => x.DaftarDistribusi);
    }
}