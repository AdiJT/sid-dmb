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
                Nama = "Bakpia Pathok Sleman",
                Dekripsi = "Bakpia khas Sleman dengan isian kacang hijau dan varian rasa modern.",
                Kategori = KategoriProduk.Makanan,
                Harga = 50000d,
                BahanUtama = "Tepung, Kacang Hijau, Gula",
                StatusKetersediaan = StatusKetersediaanProduk.Tersedia,
                TanggalProduksiTerakhir = new DateTime(2024, 12, 20),
                TanggalKadaluarsa = new DateTime(2025, 12, 20),
                LegalitasDanSertifikat = "PIRT 67890/2024, Halal MUI",
                KontakInformasi = "+62 812-5678-9101",
                MediaPromosi = new Uri("/assets/Produk_Lokal/ProdukLokal_Bakpia_Pathok_Sleman.jpg", UriKind.Relative),
                TanggalDiinputkan = new DateTime(2024, 12, 26),
                TanggalPembaruanData = new DateTime(2024, 12, 26),
                UnitUsahaId = IdUnitUsaha.Create("UU001").Value
            },
            new
            {
                Id = IdProduk.Create("PL002").Value,
                Nama = "Gatot",
                Dekripsi = "Makanan tradisional dari singkong yang dikeringkan, disajikan dengan kelapa parut.",
                Kategori = KategoriProduk.Makanan,
                Harga = 20000d,
                BahanUtama = "Singkong Kering, Kelapa",
                StatusKetersediaan = StatusKetersediaanProduk.Tersedia,
                TanggalProduksiTerakhir = new DateTime(2024, 12, 22),
                TanggalKadaluarsa = new DateTime(2025, 06, 22),
                LegalitasDanSertifikat = "PIRT 23456/2024, Halal MUI",
                KontakInformasi = "+62 813-2345-6789",
                MediaPromosi = new Uri("/assets/Produk_Lokal/ProdukLokal_Gatot.jpg", UriKind.Relative),
                TanggalDiinputkan = new DateTime(2024, 12, 26),
                TanggalPembaruanData = new DateTime(2024, 12, 26),
                UnitUsahaId = IdUnitUsaha.Create("UU002").Value
            },
            new
            {
                Id = IdProduk.Create("PL003").Value,
                Nama = "Geplak Bantul",
                Dekripsi = "Geplak manis berwarna-warni khas Bantul yang terbuat dari kelapa dan gula.",
                Kategori = KategoriProduk.Makanan,
                Harga = 30000d,
                BahanUtama = "Kelapa, Gula",
                StatusKetersediaan = StatusKetersediaanProduk.Tersedia,
                TanggalProduksiTerakhir = new DateTime(2024, 12, 18),
                TanggalKadaluarsa = new DateTime(2025, 06, 18),
                LegalitasDanSertifikat = "PIRT 34567/2024, Halal MUI",
                KontakInformasi = "+62 814-3456-7890",
                MediaPromosi = new Uri("/assets/Produk_Lokal/ProdukLokal_Geplak_Bantul.jpg", UriKind.Relative),
                TanggalDiinputkan = new DateTime(2024, 12, 26),
                TanggalPembaruanData = new DateTime(2024, 12, 26),
                UnitUsahaId = IdUnitUsaha.Create("UU003").Value
            },
            new
            {
                Id = IdProduk.Create("PL004").Value,
                Nama = "Gudeg Manggar",
                Dekripsi = "Gudeg berbahan dasar bunga kelapa muda khas Yogyakarta.",
                Kategori = KategoriProduk.Makanan,
                Harga = 70000d,
                BahanUtama = "Manggar (Bunga Kelapa), Santan, Gula Jawa",
                StatusKetersediaan = StatusKetersediaanProduk.Tersedia,
                TanggalProduksiTerakhir = new DateTime(2024, 12, 25),
                TanggalKadaluarsa = new DateTime(2025, 01, 25),
                LegalitasDanSertifikat = "PIRT 45678/2024, Halal MUI",
                KontakInformasi = "+62 815-6789-0123",
                MediaPromosi = new Uri("/assets/Produk_Lokal/ProdukLokal_Gudeg_Manggar.jpg", UriKind.Relative),
                TanggalDiinputkan = new DateTime(2024, 12, 26),
                TanggalPembaruanData = new DateTime(2024, 12, 26),
                UnitUsahaId = IdUnitUsaha.Create("UU004").Value
            },
            new
            {
                Id = IdProduk.Create("PL005").Value,
                Nama = "Thiwul",
                Dekripsi = "Makanan berbahan dasar tepung gaplek khas Gunungkidul.",
                Kategori = KategoriProduk.Makanan,
                Harga = 25000d,
                BahanUtama = "Tepung Gaplek, Kelapa Parut, Gula Merah",
                StatusKetersediaan = StatusKetersediaanProduk.Tersedia,
                TanggalProduksiTerakhir = new DateTime(2024, 12, 23),
                TanggalKadaluarsa = new DateTime(2025, 07, 23),
                LegalitasDanSertifikat = "PIRT 56789/2024, Halal MUI",
                KontakInformasi = "+62 816-7890-1234",
                MediaPromosi = new Uri("/assets/Produk_Lokal/ProdukLokal_Thiwul.jpg", UriKind.Relative),
                TanggalDiinputkan = new DateTime(2024, 12, 26),
                TanggalPembaruanData = new DateTime(2024, 12, 26),
                UnitUsahaId = IdUnitUsaha.Create("UU005").Value
            }
        );
    }
}