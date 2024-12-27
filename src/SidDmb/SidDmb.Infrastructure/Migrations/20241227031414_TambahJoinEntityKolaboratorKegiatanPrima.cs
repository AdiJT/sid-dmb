using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SidDmb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahJoinEntityKolaboratorKegiatanPrima : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KegiatanPrimaKolaborator");

            migrationBuilder.DropColumn(
                name: "RekomendasiUntukKegiatanBerikutnya",
                table: "KegiatanPrima");

            migrationBuilder.CreateTable(
                name: "KolaboratorKegiatanPrima",
                columns: table => new
                {
                    Entity1Id = table.Column<string>(type: "text", nullable: false),
                    Entity2Id = table.Column<int>(type: "integer", nullable: false),
                    RekomendasiBerikutnya = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KolaboratorKegiatanPrima", x => new { x.Entity1Id, x.Entity2Id });
                    table.ForeignKey(
                        name: "FK_KolaboratorKegiatanPrima_KegiatanPrima_Entity1Id",
                        column: x => x.Entity1Id,
                        principalTable: "KegiatanPrima",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KolaboratorKegiatanPrima_Kolaborator_Entity2Id",
                        column: x => x.Entity2Id,
                        principalTable: "Kolaborator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KolaboratorKegiatanPrima_Entity2Id",
                table: "KolaboratorKegiatanPrima",
                column: "Entity2Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KolaboratorKegiatanPrima");

            migrationBuilder.AddColumn<string>(
                name: "RekomendasiUntukKegiatanBerikutnya",
                table: "KegiatanPrima",
                type: "text",
                nullable: false,
                defaultValue: "");

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
    }
}
