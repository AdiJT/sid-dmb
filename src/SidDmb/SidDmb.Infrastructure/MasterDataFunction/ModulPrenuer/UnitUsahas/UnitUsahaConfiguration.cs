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
                Nama = "Bakpia Lestari",
                Dekripsi = "Produsen bakpia tradisional dengan resep turun-temurun.",
                Kategori = KategoriUnitUsaha.Produksi,
                Alamat = "Jl. Malioboro No. 5, Sleman",
                TitikKoordinat = new Point(110.367, -7.801),
                PemilikUsaha = "Bapak Sugeng",
                JumlahKaryawan = 15,
                KontakInformasi = "+62 812-5678-9101",
                TanggalBerdiri = new DateOnly(2010, 5, 15),
                Legalitas = LegalitasUsaha.MemilikiIzin,
                MediaPromosi = new Uri("/assets/Produk_Lokal/ProdukLokal_Bakpia_Pathok_Sleman.jpg", UriKind.Relative),
                TanggalDiinputkan = new DateTime(2024, 12, 26),
                TanggalPembaruanData = new DateTime(2024, 12, 26)
            },
            new UnitUsaha
            {
                Id = IdUnitUsaha.Create("UU002").Value,
                Nama = "Gatot Mulya",
                Dekripsi = "Produsen makanan tradisional berbasis singkong.",
                Kategori = KategoriUnitUsaha.Produksi,
                Alamat = "Dusun Kedungmiri, Gunungkidul",
                TitikKoordinat = new Point(110.454, -7.978),
                PemilikUsaha = "Ibu Nur Aini",
                JumlahKaryawan = 7,
                KontakInformasi = "+62 813-2345-6789",
                TanggalBerdiri = new DateOnly(2012, 6, 10),
                Legalitas = LegalitasUsaha.MemilikiIzin,
                MediaPromosi = new Uri("/assets/Produk_Lokal/ProdukLokal_Gatot.jpg", UriKind.Relative),
                TanggalDiinputkan = new DateTime(2024, 12, 26),
                TanggalPembaruanData = new DateTime(2024, 12, 26)
            },
            new UnitUsaha
            {
                Id = IdUnitUsaha.Create("UU003").Value,
                Nama = "Geplak Lestari",
                Dekripsi = "Produsen geplak dengan kualitas terbaik menggunakan kelapa dan gula asli.",
                Kategori = KategoriUnitUsaha.Produksi,
                Alamat = "Jl. Raya Bantul No. 25, Bantul",
                TitikKoordinat = new Point(110.328, -7.892),
                PemilikUsaha = "Bapak Wahyu Hadi",
                JumlahKaryawan = 8,
                KontakInformasi = "+62 814-3456-7890",
                TanggalBerdiri = new DateOnly(2014, 9, 5),
                Legalitas = LegalitasUsaha.MemilikiIzin,
                MediaPromosi = new Uri("/assets/Produk_Lokal/ProdukLokal_Geplak_Bantul.jpg", UriKind.Relative),
                TanggalDiinputkan = new DateTime(2024, 12, 26),
                TanggalPembaruanData = new DateTime(2024, 12, 26)
            },
            new UnitUsaha
            {
                Id = IdUnitUsaha.Create("UU004").Value,
                Nama = "Gudeg Manggar Resto",
                Dekripsi = "Restoran yang menyajikan gudeg khas Yogyakarta, dengan manggar sebagai bahan utama.",
                Kategori = KategoriUnitUsaha.Produksi,
                Alamat = "Jl. Raya Gunungkidul No. 12, Yogyakarta",
                TitikKoordinat = new Point(110.516, -7.817),
                PemilikUsaha = "Ibu Nurul Aulia",
                JumlahKaryawan = 20,
                KontakInformasi = "+62 815-6789-0123",
                TanggalBerdiri = new DateOnly(2017, 4, 17),
                Legalitas = LegalitasUsaha.MemilikiIzin,
                MediaPromosi = new Uri("/assets/Produk_Lokal/ProdukLokal_Gudeg_Manggar.jpg", UriKind.Relative),
                TanggalDiinputkan = new DateTime(2024, 12, 26),
                TanggalPembaruanData = new DateTime(2024, 12, 26)
            },
            new UnitUsaha
            {
                Id = IdUnitUsaha.Create("UU005").Value,
                Nama = "Thiwul Griya",
                Dekripsi = "Produsen tiwul khas Gunungkidul dengan bahan utama gaplek berkualitas.",
                Kategori = KategoriUnitUsaha.Produksi,
                Alamat = "Jl. Wonosari No. 8, Gunungkidul",
                TitikKoordinat = new Point(110.650, -8.033),
                PemilikUsaha = "Bapak Agus Setiawan",
                JumlahKaryawan = 5,
                KontakInformasi = "+62 816-7890-1234",
                TanggalBerdiri = new DateOnly(2016, 11, 30),
                Legalitas = LegalitasUsaha.MemilikiIzin,
                MediaPromosi = new Uri("/assets/Produk_Lokal/ProdukLokal_Thiwul.jpg", UriKind.Relative),
                TanggalDiinputkan = new DateTime(2024, 12, 26),
                TanggalPembaruanData = new DateTime(2024, 12, 26)
            }
        );
    }
}