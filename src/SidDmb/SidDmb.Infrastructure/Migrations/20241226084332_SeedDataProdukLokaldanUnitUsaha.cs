using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SidDmb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataProdukLokaldanUnitUsaha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProdukLokal",
                keyColumn: "Id",
                keyValue: "PL001",
                columns: new[] { "BahanUtama", "Dekripsi", "Harga", "Kategori", "KontakInformasi", "LegalitasDanSertifikat", "MediaPromosi", "Nama", "TanggalKadaluarsa", "TanggalProduksiTerakhir" },
                values: new object[] { "Tepung, Kacang Hijau, Gula", "Bakpia khas Sleman dengan isian kacang hijau dan varian rasa modern.", 50000.0, 1, "+62 812-5678-9101", "PIRT 67890/2024, Halal MUI", "/assets/Produk_Lokal/ProdukLokal_Bakpia_Pathok_Sleman.jpg", "Bakpia Pathok Sleman", new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "UnitUsaha",
                keyColumn: "Id",
                keyValue: "UU001",
                columns: new[] { "Alamat", "Dekripsi", "JumlahKaryawan", "KontakInformasi", "MediaPromosi", "Nama", "PemilikUsaha", "TanggalBerdiri", "TitikKoordinat" },
                values: new object[] { "Jl. Malioboro No. 5, Sleman", "Produsen bakpia tradisional dengan resep turun-temurun.", 15, "+62 812-5678-9101", "/assets/Produk_Lokal/ProdukLokal_Bakpia_Pathok_Sleman.jpg", "Bakpia Lestari", "Bapak Sugeng", new DateOnly(2010, 5, 15), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (110.367 -7.801)") });

            migrationBuilder.InsertData(
                table: "UnitUsaha",
                columns: new[] { "Id", "Alamat", "Dekripsi", "JumlahKaryawan", "Kategori", "KontakInformasi", "Legalitas", "MediaPromosi", "Nama", "PemilikUsaha", "TanggalBerdiri", "TanggalDiinputkan", "TanggalPembaruanData", "TitikKoordinat" },
                values: new object[,]
                {
                    { "UU002", "Dusun Kedungmiri, Gunungkidul", "Produsen makanan tradisional berbasis singkong.", 7, 0, "+62 813-2345-6789", 0, "/assets/Produk_Lokal/ProdukLokal_Gatot.jpg", "Gatot Mulya", "Ibu Nur Aini", new DateOnly(2012, 6, 10), new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (110.454 -7.978)") },
                    { "UU003", "Jl. Raya Bantul No. 25, Bantul", "Produsen geplak dengan kualitas terbaik menggunakan kelapa dan gula asli.", 8, 0, "+62 814-3456-7890", 0, "/assets/Produk_Lokal/ProdukLokal_Geplak_Bantul.jpg", "Geplak Lestari", "Bapak Wahyu Hadi", new DateOnly(2014, 9, 5), new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (110.328 -7.892)") },
                    { "UU004", "Jl. Raya Gunungkidul No. 12, Yogyakarta", "Restoran yang menyajikan gudeg khas Yogyakarta, dengan manggar sebagai bahan utama.", 20, 0, "+62 815-6789-0123", 0, "/assets/Produk_Lokal/ProdukLokal_Gudeg_Manggar.jpg", "Gudeg Manggar Resto", "Ibu Nurul Aulia", new DateOnly(2017, 4, 17), new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (110.516 -7.817)") },
                    { "UU005", "Jl. Wonosari No. 8, Gunungkidul", "Produsen tiwul khas Gunungkidul dengan bahan utama gaplek berkualitas.", 5, 0, "+62 816-7890-1234", 0, "/assets/Produk_Lokal/ProdukLokal_Thiwul.jpg", "Thiwul Griya", "Bapak Agus Setiawan", new DateOnly(2016, 11, 30), new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (110.65 -8.033)") }
                });

            migrationBuilder.InsertData(
                table: "ProdukLokal",
                columns: new[] { "Id", "BahanUtama", "Dekripsi", "Harga", "Kategori", "KontakInformasi", "LegalitasDanSertifikat", "MediaPromosi", "Nama", "StatusKetersediaan", "TanggalDiinputkan", "TanggalKadaluarsa", "TanggalPembaruanData", "TanggalProduksiTerakhir", "UnitUsahaId" },
                values: new object[,]
                {
                    { "PL002", "Singkong Kering, Kelapa", "Makanan tradisional dari singkong yang dikeringkan, disajikan dengan kelapa parut.", 20000.0, 1, "+62 813-2345-6789", "PIRT 23456/2024, Halal MUI", "/assets/Produk_Lokal/ProdukLokal_Gatot.jpg", "Gatot", 0, new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "UU002" },
                    { "PL003", "Kelapa, Gula", "Geplak manis berwarna-warni khas Bantul yang terbuat dari kelapa dan gula.", 30000.0, 1, "+62 814-3456-7890", "PIRT 34567/2024, Halal MUI", "/assets/Produk_Lokal/ProdukLokal_Geplak_Bantul.jpg", "Geplak Bantul", 0, new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "UU003" },
                    { "PL004", "Manggar (Bunga Kelapa), Santan, Gula Jawa", "Gudeg berbahan dasar bunga kelapa muda khas Yogyakarta.", 70000.0, 1, "+62 815-6789-0123", "PIRT 45678/2024, Halal MUI", "/assets/Produk_Lokal/ProdukLokal_Gudeg_Manggar.jpg", "Gudeg Manggar", 0, new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "UU004" },
                    { "PL005", "Tepung Gaplek, Kelapa Parut, Gula Merah", "Makanan berbahan dasar tepung gaplek khas Gunungkidul.", 25000.0, 1, "+62 816-7890-1234", "PIRT 56789/2024, Halal MUI", "/assets/Produk_Lokal/ProdukLokal_Thiwul.jpg", "Thiwul", 0, new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "UU005" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProdukLokal",
                keyColumn: "Id",
                keyValue: "PL002");

            migrationBuilder.DeleteData(
                table: "ProdukLokal",
                keyColumn: "Id",
                keyValue: "PL003");

            migrationBuilder.DeleteData(
                table: "ProdukLokal",
                keyColumn: "Id",
                keyValue: "PL004");

            migrationBuilder.DeleteData(
                table: "ProdukLokal",
                keyColumn: "Id",
                keyValue: "PL005");

            migrationBuilder.DeleteData(
                table: "UnitUsaha",
                keyColumn: "Id",
                keyValue: "UU002");

            migrationBuilder.DeleteData(
                table: "UnitUsaha",
                keyColumn: "Id",
                keyValue: "UU003");

            migrationBuilder.DeleteData(
                table: "UnitUsaha",
                keyColumn: "Id",
                keyValue: "UU004");

            migrationBuilder.DeleteData(
                table: "UnitUsaha",
                keyColumn: "Id",
                keyValue: "UU005");

            migrationBuilder.UpdateData(
                table: "ProdukLokal",
                keyColumn: "Id",
                keyValue: "PL001",
                columns: new[] { "BahanUtama", "Dekripsi", "Harga", "Kategori", "KontakInformasi", "LegalitasDanSertifikat", "MediaPromosi", "Nama", "TanggalKadaluarsa", "TanggalProduksiTerakhir" },
                values: new object[] { "Katun, Pewarna Alami", "Batik tulis berbahan katun dengan motif khas Desa Gilangharjo.", 150000.0, 0, "+62 812-3456-7890", "PIRT 12345/2024, Halal MUI", "/assets/produklokal2-test.png", "Batik Tulis Motif Gilang", new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "UnitUsaha",
                keyColumn: "Id",
                keyValue: "UU001",
                columns: new[] { "Alamat", "Dekripsi", "JumlahKaryawan", "KontakInformasi", "MediaPromosi", "Nama", "PemilikUsaha", "TanggalBerdiri", "TitikKoordinat" },
                values: new object[] { "Jl. Raya Gilang No. 15, Bantul", "Unit usaha yang memproduksi batik tulis dengan motif khas Gilangharjo.", 10, "+62 812-3456-7890", "/assets/produklokal-test.png", "Batik Gilang Sejahtera", "Ibu Siti Aisyah", new DateOnly(2015, 7, 15), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (110.329 -7.917)") });
        }
    }
}
