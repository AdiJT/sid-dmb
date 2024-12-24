using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SidDmb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahKomentar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KomentarPeserta",
                table: "UpacaraBudaya");

            migrationBuilder.DropColumn(
                name: "RatingPeserta",
                table: "UpacaraBudaya");

            migrationBuilder.DropColumn(
                name: "KomentarPengunjung",
                table: "SitusBudaya");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "SitusBudaya");

            migrationBuilder.DropColumn(
                name: "KomentarPenonton",
                table: "SeniBudaya");

            migrationBuilder.DropColumn(
                name: "RatingPenonton",
                table: "SeniBudaya");

            migrationBuilder.CreateTable(
                name: "Komentar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<double>(type: "double precision", nullable: false),
                    UpacaraBudayaId = table.Column<string>(type: "text", nullable: true),
                    SitusBudayaId = table.Column<string>(type: "text", nullable: true),
                    SeniBudayaId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Komentar_SeniBudaya_SeniBudayaId",
                        column: x => x.SeniBudayaId,
                        principalTable: "SeniBudaya",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Komentar_SitusBudaya_SitusBudayaId",
                        column: x => x.SitusBudayaId,
                        principalTable: "SitusBudaya",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Komentar_UpacaraBudaya_UpacaraBudayaId",
                        column: x => x.UpacaraBudayaId,
                        principalTable: "UpacaraBudaya",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Komentar_SeniBudayaId",
                table: "Komentar",
                column: "SeniBudayaId");

            migrationBuilder.CreateIndex(
                name: "IX_Komentar_SitusBudayaId",
                table: "Komentar",
                column: "SitusBudayaId");

            migrationBuilder.CreateIndex(
                name: "IX_Komentar_UpacaraBudayaId",
                table: "Komentar",
                column: "UpacaraBudayaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Komentar");

            migrationBuilder.AddColumn<string>(
                name: "KomentarPeserta",
                table: "UpacaraBudaya",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "RatingPeserta",
                table: "UpacaraBudaya",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "KomentarPengunjung",
                table: "SitusBudaya",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "SitusBudaya",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "KomentarPenonton",
                table: "SeniBudaya",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "RatingPenonton",
                table: "SeniBudaya",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
