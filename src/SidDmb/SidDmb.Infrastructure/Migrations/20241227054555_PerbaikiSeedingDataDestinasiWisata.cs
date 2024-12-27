using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SidDmb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PerbaikiSeedingDataDestinasiWisata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DestinasiWisata",
                keyColumn: "Id",
                keyValue: "DW001",
                column: "Foto",
                value: "/assets/Destinasi_Wisata/Destinasi_Candi_Prambanan.jpg");

            migrationBuilder.UpdateData(
                table: "DestinasiWisata",
                keyColumn: "Id",
                keyValue: "DW002",
                column: "Foto",
                value: "/assets/Destinasi_Wisata/Destinasi_Gua_Pindul.jpg");

            migrationBuilder.UpdateData(
                table: "DestinasiWisata",
                keyColumn: "Id",
                keyValue: "DW003",
                column: "Foto",
                value: "/assets/Destinasi_Wisata/Destinasi_Gunung_Merapi.jpg");

            migrationBuilder.UpdateData(
                table: "DestinasiWisata",
                keyColumn: "Id",
                keyValue: "DW004",
                column: "Foto",
                value: "/assets/Destinasi_Wisata/Destinasi_Hutan_Pinus_Mangunan.jpg");

            migrationBuilder.UpdateData(
                table: "DestinasiWisata",
                keyColumn: "Id",
                keyValue: "DW005",
                column: "Foto",
                value: "/assets/Destinasi_Wisata/Destinasi_Pantai_Parangtritis.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DestinasiWisata",
                keyColumn: "Id",
                keyValue: "DW001",
                column: "Foto",
                value: "/assets/Destinasi_Candi_Prambanan.jpg");

            migrationBuilder.UpdateData(
                table: "DestinasiWisata",
                keyColumn: "Id",
                keyValue: "DW002",
                column: "Foto",
                value: "/assets/Destinasi_Gua_Pindul.jpg");

            migrationBuilder.UpdateData(
                table: "DestinasiWisata",
                keyColumn: "Id",
                keyValue: "DW003",
                column: "Foto",
                value: "/assets/Destinasi_Gunung_Merapi.jpg");

            migrationBuilder.UpdateData(
                table: "DestinasiWisata",
                keyColumn: "Id",
                keyValue: "DW004",
                column: "Foto",
                value: "/assets/Destinasi_Hutan_Pinus_Mangunan.jpg");

            migrationBuilder.UpdateData(
                table: "DestinasiWisata",
                keyColumn: "Id",
                keyValue: "DW005",
                column: "Foto",
                value: "/assets/Destinasi_Pantai_Parangtritis.jpg");
        }
    }
}
