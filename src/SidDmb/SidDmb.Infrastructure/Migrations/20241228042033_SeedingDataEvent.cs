using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SidDmb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "Id", "Anggaran", "Dekripsi", "JumlahPesertaMaksimal", "Kategori", "KontakInformasi", "Lokasi", "MediaPromosi", "Nama", "Penyelenggara", "Sponsor", "StatusPendaftaran", "TanggalDiinputkan", "TanggalPembaruanData", "TanggalWaktu", "TargetPeserta" },
                values: new object[] { "EV001", 12000000.0, "Festival tahunan yang menampilkan seni tari dan musik tradisional.", 150, 0, "+62 813-4567-8910", "Balai Desa Gilangharjo", "/assets/event2-test.png", "Festival Seni dan Budaya Gilang", "Pokdarwis Desa Gilangharjo", "Bank Gilang, Warung Gilang Sejahtera", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "Id",
                keyValue: "EV001");
        }
    }
}
