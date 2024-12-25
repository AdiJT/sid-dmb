using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SidDmb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataDestinasi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DestinasiWisata",
                columns: new[] { "Id", "Alamat", "DaftarAktivitas", "DaftarFasilitas", "Deskripsi", "HargaTiketMasuk", "InformasiKontak", "JamOperasional", "Kategori", "Nama", "PengelolaDestinasi", "StatusOperasional", "TanggalDiinputkan", "TanggalPembaruanData", "TitikKoordinat" },
                values: new object[,]
                {
                    { "DW001", "Jl. Raya Prambanan, Klaten, Jawa Tengah", new[] { "Tur Sejarah", "Fotografi", "Tari Barong" }, new[] { "Panggung Hiburan", "Toilet Umum", "Taman Parkir" }, "Candi Prambanan adalah kompleks candi Hindu terbesar di Indonesia dan merupakan salah satu situs warisan dunia UNESCO.", 35000.0, "+62 812-3456-7890", "08:00 - 18:00", 2, "Candi Prambanan", "Dinas Kebudayaan Yogyakarta", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (110.489273 -7.756137)") },
                    { "DW002", "Desa Bejiharjo, Karangmojo, Gunungkidul, Yogyakarta", new[] { "Cave Tubing", "Jelajah Gua", "Trekking" }, new[] { "Sewa Perahu", "Toilet Umum", "Area Parkir" }, "Gua Pindul adalah gua alami yang terkenal dengan wisata cave tubing di Yogyakarta.", 25000.0, "+62 812-3456-7890", "08:00 - 17:00", 0, "Gua Pindul", "PT. Pindul Adventure", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (110.648987 -7.930843)") },
                    { "DW003", "Sleman, Yogyakarta", new[] { "Pendakian", "Fotografi Alam", "Trekking Gunung" }, new[] { "Pusat Informasi", "Area Parkir", "Pemandu Gunung" }, "Gunung Merapi adalah gunung berapi aktif yang terkenal dengan pendakian dan pemandangan alam yang mempesona.", 50000.0, "+62 812-3456-7890", "24 Jam", 0, "Gunung Merapi", "Dinas Pariwisata Yogyakarta", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (110.4461 -7.541389)") },
                    { "DW004", "Dlingo, Bantul, Yogyakarta", new[] { "Fotografi Alam", "Jalan-jalan", "Wisata Alam" }, new[] { "Jalan Setapak", "Tempat Duduk", "Area Parkir" }, "Hutan Pinus Mangunan menawarkan keindahan alam yang asri dengan pemandangan spektakuler dan udara yang sejuk.", 15000.0, "+62 812-3456-7890", "07:00 - 18:00", 0, "Hutan Pinus Mangunan", "Dinas Pariwisata Bantul", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (110.431801 -7.9258)") },
                    { "DW005", "Jl. Parangtritis, Yogyakarta", new[] { "Bermain Pasir", "Fotografi", "Pemandangan Matahari Terbenam" }, new[] { "Panggung Hiburan", "Tempat Duduk", "Area Parkir" }, "Pantai Parangtritis terkenal dengan pasir pantainya yang luas dan pemandangan matahari terbenam yang menakjubkan.", 20000.0, "+62 812-3456-7890", "24 Jam", 0, "Pantai Parangtritis", "Dinas Pariwisata Yogyakarta", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (110.33287 -8.024295)") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DestinasiWisata",
                keyColumn: "Id",
                keyValue: "DW001");

            migrationBuilder.DeleteData(
                table: "DestinasiWisata",
                keyColumn: "Id",
                keyValue: "DW002");

            migrationBuilder.DeleteData(
                table: "DestinasiWisata",
                keyColumn: "Id",
                keyValue: "DW003");

            migrationBuilder.DeleteData(
                table: "DestinasiWisata",
                keyColumn: "Id",
                keyValue: "DW004");

            migrationBuilder.DeleteData(
                table: "DestinasiWisata",
                keyColumn: "Id",
                keyValue: "DW005");
        }
    }
}
