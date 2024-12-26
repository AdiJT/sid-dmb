using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.MasterDataFunction.ModulPreneur.ProdukLokals;
using SidDmb.Domain.MasterDataFunction.ModulPreneur.UnitUsahas;

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

        builder.HasData(
            new
            {
                Id = IdProduk.Create("PL001").Value,
                Nama = "Batik Tulis Motif Gilang",
                Dekripsi = "Batik tulis berbahan katun dengan motif khas Desa Gilangharjo.",
                Kategori = KategoriProduk.Kerajinan,
                Harga = 150000d,
                BahanUtama = "Katun, Pewarna Alami",
                StatusKetersediaan = StatusKetersediaanProduk.Tersedia,
                TanggalProduksiTerakhir = new DateTime(2024, 12, 1),
                TanggalKadaluarsa = new DateTime(2025, 12, 1),
                LegalitasDanSertifikat = "PIRT 12345/2024, Halal MUI",
                KontakInformasi = "+62 812-3456-7890",
                MediaPromosi = new Uri("/assets/produklokal2-test.png", UriKind.Relative),
                TanggalDiinputkan = new DateTime(2024, 12, 26),
                TanggalPembaruanData = new DateTime(2024, 12, 26),
                UnitUsahaId = IdUnitUsaha.Create("UU001").Value
            }
        );
    }
}