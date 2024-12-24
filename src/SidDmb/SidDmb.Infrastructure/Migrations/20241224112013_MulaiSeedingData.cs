using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SidDmb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MulaiSeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Isi",
                table: "Komentar",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "ArtefakBudaya",
                columns: new[] { "Id", "Bahan", "Dekripsi", "Dimensi", "Foto", "Kategori", "Ketersediaan", "Kondisi", "LokasiPenyimpanan", "Nama", "NilaiHistoris", "Pengelola", "TanggalDiinputkan", "TanggalPembaruanData", "Usia" },
                values: new object[] { "AR001", "Besi, Perunggu", "Keris ini dipercaya sebagai pusaka warisan Ki Ageng Gilang.", "Panjang: 40 cm, Lebar: 10 cm", "/assets/artefak-test.png", 0, 0, 0, "Museum Desa Gilangharjo", "Keris Ki Ageng Gilang", "Artefak ini digunakan dalam upacara adat sejak abad ke-17.", "Kelompok Budaya Desa Gilangharjo", new DateTime(2024, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abad ke-17" });

            migrationBuilder.InsertData(
                table: "Komentar",
                columns: new[] { "Id", "ArtefakBudayaId", "Isi", "Nama", "Rating", "SeniBudayaId", "SitusBudayaId", "UpacaraBudayaId" },
                values: new object[] { 1, "AR001", "Artefak yang sangat menarik, tetapi informasi lebih detail diperlukan.", "Kometator 1", 4.7999999999999998, null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ArtefakBudaya",
                keyColumn: "Id",
                keyValue: "AR001");

            migrationBuilder.DropColumn(
                name: "Isi",
                table: "Komentar");
        }
    }
}
