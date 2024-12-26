using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetTopologySuite.Geometries;
using SidDmb.Domain.MasterDataFunction.ModulPreneur.UnitUsahas;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulPrenuer.UnitUsahas;

internal class UnitUsahaConfiguration : IEntityTypeConfiguration<UnitUsaha>
{
    public void Configure(EntityTypeBuilder<UnitUsaha> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasConversion(i => i.Value, s => IdUnitUsaha.Create(s).Value);

        builder.HasMany(u => u.DaftarProduk).WithOne(p => p.UnitUsaha);

        builder.HasData(
            new UnitUsaha
            {
                Id = IdUnitUsaha.Create("UU001").Value,
                Nama = "Batik Gilang Sejahtera",
                Dekripsi = "Unit usaha yang memproduksi batik tulis dengan motif khas Gilangharjo.",
                Kategori = KategoriUnitUsaha.Produksi,
                Alamat = "Jl. Raya Gilang No. 15, Bantul",
                TitikKoordinat = new Point(110.329, -7.917),
                PemilikUsaha = "Ibu Siti Aisyah",
                JumlahKaryawan = 10,
                KontakInformasi = "+62 812-3456-7890",
                TanggalBerdiri = new DateOnly(2015, 7, 15),
                Legalitas = LegalitasUsaha.MemilikiIzin,
                MediaPromosi = new Uri("/assets/produklokal-test.png", UriKind.Relative),
                TanggalDiinputkan = new DateTime(2024, 12, 26),
                TanggalPembaruanData = new DateTime(2024, 12, 26),
            }
        );
    }
}