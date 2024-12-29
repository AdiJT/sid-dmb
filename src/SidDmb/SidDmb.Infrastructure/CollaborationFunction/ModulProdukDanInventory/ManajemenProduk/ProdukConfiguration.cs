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

        builder.HasData(
            new Produk
            {
                Id = IdProduk.Create("MP001").Value,
                Nama = "Batik Tulis Gilang",
                Dekripsi = "Batik tulis dengan pewarna alami dan motif khas Desa Gilangharjo.",
                Kategori = KategoriProduk.Kerajinan,
                UnitUsahaTerkait = "Batik Gilang Sejahtera",
                HargaProduk = 150_000d,
                StokAwal = 100,
                StokSaatIni = 50,
                StatusKetersediaan = StatusKetersediaan.Tersedia,
                TanggalProduksiTerakhir = new DateOnly(2024, 12, 1),
                TanggalKadaluarsa = new DateOnly(2024, 12, 1),
                LegalitasProduk = "PIRT 12345/2024, Halal MUI",
                MediaPromosi = new Uri("/assets/produklokal2-test.png", UriKind.Relative),
            }
        );
    }
}