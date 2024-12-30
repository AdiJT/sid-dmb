using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SidDmb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UbahNamaKolom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EntitasPenelitian",
                table: "DataRiset",
                newName: "EntitasPeneliti");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EntitasPeneliti",
                table: "DataRiset",
                newName: "EntitasPenelitian");
        }
    }
}
