using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SidDmb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahKolomRatingDiDestinasiWisata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "DestinasiWisata",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "DestinasiWisata",
                keyColumn: "Id",
                keyValue: "DW001",
                column: "Rating",
                value: 4.5);

            migrationBuilder.UpdateData(
                table: "DestinasiWisata",
                keyColumn: "Id",
                keyValue: "DW002",
                column: "Rating",
                value: 4.5);

            migrationBuilder.UpdateData(
                table: "DestinasiWisata",
                keyColumn: "Id",
                keyValue: "DW003",
                column: "Rating",
                value: 4.5);

            migrationBuilder.UpdateData(
                table: "DestinasiWisata",
                keyColumn: "Id",
                keyValue: "DW004",
                column: "Rating",
                value: 4.5);

            migrationBuilder.UpdateData(
                table: "DestinasiWisata",
                keyColumn: "Id",
                keyValue: "DW005",
                column: "Rating",
                value: 4.5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "DestinasiWisata");
        }
    }
}
