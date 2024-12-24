using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SidDmb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahKomentarDiArtefakBudaya : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KomentarPengunjung",
                table: "ArtefakBudaya");

            migrationBuilder.DropColumn(
                name: "RatingPengunjung",
                table: "ArtefakBudaya");

            migrationBuilder.AddColumn<string>(
                name: "ArtefakBudayaId",
                table: "Komentar",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Komentar_ArtefakBudayaId",
                table: "Komentar",
                column: "ArtefakBudayaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Komentar_ArtefakBudaya_ArtefakBudayaId",
                table: "Komentar",
                column: "ArtefakBudayaId",
                principalTable: "ArtefakBudaya",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Komentar_ArtefakBudaya_ArtefakBudayaId",
                table: "Komentar");

            migrationBuilder.DropIndex(
                name: "IX_Komentar_ArtefakBudayaId",
                table: "Komentar");

            migrationBuilder.DropColumn(
                name: "ArtefakBudayaId",
                table: "Komentar");

            migrationBuilder.AddColumn<string>(
                name: "KomentarPengunjung",
                table: "ArtefakBudaya",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "RatingPengunjung",
                table: "ArtefakBudaya",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
