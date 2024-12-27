using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SidDmb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HapusKolomDariLaporanEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MasukanKolaborator",
                table: "LaporanEvent");

            migrationBuilder.DropColumn(
                name: "RekomendasiUntukEventBerikutnya",
                table: "LaporanEvent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MasukanKolaborator",
                table: "LaporanEvent",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RekomendasiUntukEventBerikutnya",
                table: "LaporanEvent",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
