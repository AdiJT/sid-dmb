using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SidDmb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDatLaporanKnjungan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LaporanKunjungan",
                columns: new[] { "Id", "DestinasiWisataId", "DurasiKunjungan", "JumlahWisatawanDomestik", "JumlahWisatawanInternasional", "KomentarPengunjung", "RatingPengunjung", "TanggalDiinputkan", "TanggalKunjungan", "TanggalPembaruanData", "TiketTerjual" },
                values: new object[,]
                {
                    { "LK001", "DW001", new TimeSpan(0, 6, 0, 0, 0), 75, 75, "Mantap", 4.7000000000000002, new DateTime(2024, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2024, 1, 1), new DateTime(2024, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 150 },
                    { "LK002", "DW002", new TimeSpan(0, 6, 0, 0, 0), 100, 100, "Mantap", 4.7000000000000002, new DateTime(2024, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2024, 2, 1), new DateTime(2024, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 200 },
                    { "LK003", "DW003", new TimeSpan(0, 6, 0, 0, 0), 60, 60, "Mantap", 4.7000000000000002, new DateTime(2024, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2024, 3, 1), new DateTime(2024, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 200 },
                    { "LK004", "DW004", new TimeSpan(0, 6, 0, 0, 0), 125, 125, "Mantap", 4.7000000000000002, new DateTime(2024, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2024, 4, 1), new DateTime(2024, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 200 },
                    { "LK005", "DW005", new TimeSpan(0, 6, 0, 0, 0), 150, 150, "Mantap", 4.7000000000000002, new DateTime(2024, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2024, 5, 1), new DateTime(2024, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 200 },
                    { "LK006", "DW001", new TimeSpan(0, 6, 0, 0, 0), 200, 200, "Mantap", 4.7000000000000002, new DateTime(2024, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2024, 6, 1), new DateTime(2024, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 200 },
                    { "LK007", "DW002", new TimeSpan(0, 6, 0, 0, 0), 125, 125, "Mantap", 4.7000000000000002, new DateTime(2024, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2024, 7, 1), new DateTime(2024, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 200 },
                    { "LK008", "DW003", new TimeSpan(0, 6, 0, 0, 0), 65, 65, "Mantap", 4.7000000000000002, new DateTime(2024, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2024, 8, 1), new DateTime(2024, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 200 },
                    { "LK009", "DW004", new TimeSpan(0, 6, 0, 0, 0), 100, 100, "Mantap", 4.7000000000000002, new DateTime(2024, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2024, 9, 1), new DateTime(2024, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 200 },
                    { "LK010", "DW005", new TimeSpan(0, 6, 0, 0, 0), 75, 75, "Mantap", 4.7000000000000002, new DateTime(2024, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2024, 10, 1), new DateTime(2024, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 200 },
                    { "LK011", "DW001", new TimeSpan(0, 6, 0, 0, 0), 100, 45, "Mantap", 4.7000000000000002, new DateTime(2024, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2024, 11, 1), new DateTime(2024, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 200 },
                    { "LK012", "DW002", new TimeSpan(0, 6, 0, 0, 0), 75, 75, "Mantap", 4.7000000000000002, new DateTime(2024, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2024, 12, 1), new DateTime(2024, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 200 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LaporanKunjungan",
                keyColumn: "Id",
                keyValue: "LK001");

            migrationBuilder.DeleteData(
                table: "LaporanKunjungan",
                keyColumn: "Id",
                keyValue: "LK002");

            migrationBuilder.DeleteData(
                table: "LaporanKunjungan",
                keyColumn: "Id",
                keyValue: "LK003");

            migrationBuilder.DeleteData(
                table: "LaporanKunjungan",
                keyColumn: "Id",
                keyValue: "LK004");

            migrationBuilder.DeleteData(
                table: "LaporanKunjungan",
                keyColumn: "Id",
                keyValue: "LK005");

            migrationBuilder.DeleteData(
                table: "LaporanKunjungan",
                keyColumn: "Id",
                keyValue: "LK006");

            migrationBuilder.DeleteData(
                table: "LaporanKunjungan",
                keyColumn: "Id",
                keyValue: "LK007");

            migrationBuilder.DeleteData(
                table: "LaporanKunjungan",
                keyColumn: "Id",
                keyValue: "LK008");

            migrationBuilder.DeleteData(
                table: "LaporanKunjungan",
                keyColumn: "Id",
                keyValue: "LK009");

            migrationBuilder.DeleteData(
                table: "LaporanKunjungan",
                keyColumn: "Id",
                keyValue: "LK010");

            migrationBuilder.DeleteData(
                table: "LaporanKunjungan",
                keyColumn: "Id",
                keyValue: "LK011");

            migrationBuilder.DeleteData(
                table: "LaporanKunjungan",
                keyColumn: "Id",
                keyValue: "LK012");
        }
    }
}
