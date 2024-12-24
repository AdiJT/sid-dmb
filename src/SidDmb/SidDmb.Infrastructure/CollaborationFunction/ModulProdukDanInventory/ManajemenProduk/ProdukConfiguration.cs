using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.ManajemenProduk;

namespace SidDmb.Infrastructure.CollaborationFunction.ModulProdukDanInventory.ManajemenProduk;

internal class ProdukConfiguration : IEntityTypeConfiguration<Produk>
{
    public void Configure(EntityTypeBuilder<Produk> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(i => i.Value, s => IdProduk.Create(s).Value);

        builder.HasMany(x => x.DaftarDistribusi).WithOne(x => x.Produk);
        builder.HasMany(x => x.DaftarKolaborator).WithMany(x => x.DaftarProduk);
    }
}