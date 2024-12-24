using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.MasterDataFunction.ModulPreneur.ProdukLokals;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulPrenuer.ProdukLokals;

internal class ProdukLokalConfiguration : IEntityTypeConfiguration<ProdukLokal>
{
    public void Configure(EntityTypeBuilder<ProdukLokal> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(i => i.Value, s => IdProduk.Create(s).Value);
        builder.Property(x => x.TanggalProduksiTerakhir).HasColumnType("timestamp without time zone");
        builder.Property(x => x.TanggalKadaluarsa).HasColumnType("timestamp without time zone");

        builder.HasOne(x => x.UnitUsaha).WithMany(u => u.DaftarProduk);
    }
}