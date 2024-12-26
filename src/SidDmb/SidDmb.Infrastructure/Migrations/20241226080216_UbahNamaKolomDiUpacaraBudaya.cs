using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SidDmb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UbahNamaKolomDiUpacaraBudaya : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JumlahUpacara",
                table: "UpacaraBudaya",
                newName: "JumlahPeserta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JumlahPeserta",
                table: "UpacaraBudaya",
                newName: "JumlahUpacara");
        }
    }
}
