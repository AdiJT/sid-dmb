using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SidDmb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahRelasiKegiatanPrimaKeKolaborator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KegiatanPrimaKolaboratorKegiatanPrima");

            migrationBuilder.DropTable(
                name: "KolaboratorKegiatanPrima");

            migrationBuilder.CreateTable(
                name: "KegiatanPrimaKolaborator",
                columns: table => new
                {
                    DaftarKegiatanPrimaId = table.Column<string>(type: "text", nullable: false),
                    KolaboratorKegiatanId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KegiatanPrimaKolaborator", x => new { x.DaftarKegiatanPrimaId, x.KolaboratorKegiatanId });
                    table.ForeignKey(
                        name: "FK_KegiatanPrimaKolaborator_KegiatanPrima_DaftarKegiatanPrimaId",
                        column: x => x.DaftarKegiatanPrimaId,
                        principalTable: "KegiatanPrima",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KegiatanPrimaKolaborator_Kolaborator_KolaboratorKegiatanId",
                        column: x => x.KolaboratorKegiatanId,
                        principalTable: "Kolaborator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KegiatanPrimaKolaborator_KolaboratorKegiatanId",
                table: "KegiatanPrimaKolaborator",
                column: "KolaboratorKegiatanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KegiatanPrimaKolaborator");

            migrationBuilder.CreateTable(
                name: "KolaboratorKegiatanPrima",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KolaboratorKegiatanPrima", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KegiatanPrimaKolaboratorKegiatanPrima",
                columns: table => new
                {
                    DaftarKegiatanPrimaId = table.Column<string>(type: "text", nullable: false),
                    KolaboratorKegiatanId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KegiatanPrimaKolaboratorKegiatanPrima", x => new { x.DaftarKegiatanPrimaId, x.KolaboratorKegiatanId });
                    table.ForeignKey(
                        name: "FK_KegiatanPrimaKolaboratorKegiatanPrima_KegiatanPrima_DaftarK~",
                        column: x => x.DaftarKegiatanPrimaId,
                        principalTable: "KegiatanPrima",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KegiatanPrimaKolaboratorKegiatanPrima_KolaboratorKegiatanPr~",
                        column: x => x.KolaboratorKegiatanId,
                        principalTable: "KolaboratorKegiatanPrima",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KegiatanPrimaKolaboratorKegiatanPrima_KolaboratorKegiatanId",
                table: "KegiatanPrimaKolaboratorKegiatanPrima",
                column: "KolaboratorKegiatanId");
        }
    }
}
