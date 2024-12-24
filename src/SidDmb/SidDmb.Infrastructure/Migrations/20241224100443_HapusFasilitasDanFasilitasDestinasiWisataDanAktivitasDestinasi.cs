using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SidDmb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HapusFasilitasDanFasilitasDestinasiWisataDanAktivitasDestinasi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AktivitasDestinasiWisataDestinasiWisata");

            migrationBuilder.DropTable(
                name: "DestinasiWisataFasilitasDestinasiWisata");

            migrationBuilder.DropTable(
                name: "FasilitasSeniBudaya");

            migrationBuilder.DropTable(
                name: "FasilitasSitusBudaya");

            migrationBuilder.DropTable(
                name: "FasilitasUpacaraBudaya");

            migrationBuilder.DropTable(
                name: "AktivitasDestinasiWisata");

            migrationBuilder.DropTable(
                name: "FasilitasDestinasiWisata");

            migrationBuilder.DropTable(
                name: "Fasilitas");

            migrationBuilder.AddColumn<string[]>(
                name: "FasilitasPendukung",
                table: "UpacaraBudaya",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.AddColumn<string[]>(
                name: "DaftarFasilitas",
                table: "SitusBudaya",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.AddColumn<string[]>(
                name: "FasilitasPertunjukan",
                table: "SeniBudaya",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.AddColumn<string[]>(
                name: "DaftarAktivitas",
                table: "DestinasiWisata",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.AddColumn<string[]>(
                name: "DaftarFasilitas",
                table: "DestinasiWisata",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FasilitasPendukung",
                table: "UpacaraBudaya");

            migrationBuilder.DropColumn(
                name: "DaftarFasilitas",
                table: "SitusBudaya");

            migrationBuilder.DropColumn(
                name: "FasilitasPertunjukan",
                table: "SeniBudaya");

            migrationBuilder.DropColumn(
                name: "DaftarAktivitas",
                table: "DestinasiWisata");

            migrationBuilder.DropColumn(
                name: "DaftarFasilitas",
                table: "DestinasiWisata");

            migrationBuilder.CreateTable(
                name: "AktivitasDestinasiWisata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AktivitasDestinasiWisata", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fasilitas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fasilitas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FasilitasDestinasiWisata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FasilitasDestinasiWisata", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AktivitasDestinasiWisataDestinasiWisata",
                columns: table => new
                {
                    DaftarAktivitasId = table.Column<int>(type: "integer", nullable: false),
                    DaftarDestinasiWisataId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AktivitasDestinasiWisataDestinasiWisata", x => new { x.DaftarAktivitasId, x.DaftarDestinasiWisataId });
                    table.ForeignKey(
                        name: "FK_AktivitasDestinasiWisataDestinasiWisata_AktivitasDestinasiW~",
                        column: x => x.DaftarAktivitasId,
                        principalTable: "AktivitasDestinasiWisata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AktivitasDestinasiWisataDestinasiWisata_DestinasiWisata_Daf~",
                        column: x => x.DaftarDestinasiWisataId,
                        principalTable: "DestinasiWisata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FasilitasSeniBudaya",
                columns: table => new
                {
                    DaftarSeniBudayaId = table.Column<string>(type: "text", nullable: false),
                    FasilitasPertunjukanId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FasilitasSeniBudaya", x => new { x.DaftarSeniBudayaId, x.FasilitasPertunjukanId });
                    table.ForeignKey(
                        name: "FK_FasilitasSeniBudaya_Fasilitas_FasilitasPertunjukanId",
                        column: x => x.FasilitasPertunjukanId,
                        principalTable: "Fasilitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FasilitasSeniBudaya_SeniBudaya_DaftarSeniBudayaId",
                        column: x => x.DaftarSeniBudayaId,
                        principalTable: "SeniBudaya",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FasilitasSitusBudaya",
                columns: table => new
                {
                    DaftarFasilitasId = table.Column<int>(type: "integer", nullable: false),
                    DaftarSitusBudayaId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FasilitasSitusBudaya", x => new { x.DaftarFasilitasId, x.DaftarSitusBudayaId });
                    table.ForeignKey(
                        name: "FK_FasilitasSitusBudaya_Fasilitas_DaftarFasilitasId",
                        column: x => x.DaftarFasilitasId,
                        principalTable: "Fasilitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FasilitasSitusBudaya_SitusBudaya_DaftarSitusBudayaId",
                        column: x => x.DaftarSitusBudayaId,
                        principalTable: "SitusBudaya",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FasilitasUpacaraBudaya",
                columns: table => new
                {
                    DaftarUpacaraBudayaId = table.Column<string>(type: "text", nullable: false),
                    FasilitasPendukungId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FasilitasUpacaraBudaya", x => new { x.DaftarUpacaraBudayaId, x.FasilitasPendukungId });
                    table.ForeignKey(
                        name: "FK_FasilitasUpacaraBudaya_Fasilitas_FasilitasPendukungId",
                        column: x => x.FasilitasPendukungId,
                        principalTable: "Fasilitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FasilitasUpacaraBudaya_UpacaraBudaya_DaftarUpacaraBudayaId",
                        column: x => x.DaftarUpacaraBudayaId,
                        principalTable: "UpacaraBudaya",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DestinasiWisataFasilitasDestinasiWisata",
                columns: table => new
                {
                    DaftarDestinasiWisataId = table.Column<string>(type: "text", nullable: false),
                    DaftarFasilitasId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinasiWisataFasilitasDestinasiWisata", x => new { x.DaftarDestinasiWisataId, x.DaftarFasilitasId });
                    table.ForeignKey(
                        name: "FK_DestinasiWisataFasilitasDestinasiWisata_DestinasiWisata_Daf~",
                        column: x => x.DaftarDestinasiWisataId,
                        principalTable: "DestinasiWisata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DestinasiWisataFasilitasDestinasiWisata_FasilitasDestinasiW~",
                        column: x => x.DaftarFasilitasId,
                        principalTable: "FasilitasDestinasiWisata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AktivitasDestinasiWisataDestinasiWisata_DaftarDestinasiWisa~",
                table: "AktivitasDestinasiWisataDestinasiWisata",
                column: "DaftarDestinasiWisataId");

            migrationBuilder.CreateIndex(
                name: "IX_DestinasiWisataFasilitasDestinasiWisata_DaftarFasilitasId",
                table: "DestinasiWisataFasilitasDestinasiWisata",
                column: "DaftarFasilitasId");

            migrationBuilder.CreateIndex(
                name: "IX_FasilitasSeniBudaya_FasilitasPertunjukanId",
                table: "FasilitasSeniBudaya",
                column: "FasilitasPertunjukanId");

            migrationBuilder.CreateIndex(
                name: "IX_FasilitasSitusBudaya_DaftarSitusBudayaId",
                table: "FasilitasSitusBudaya",
                column: "DaftarSitusBudayaId");

            migrationBuilder.CreateIndex(
                name: "IX_FasilitasUpacaraBudaya_FasilitasPendukungId",
                table: "FasilitasUpacaraBudaya",
                column: "FasilitasPendukungId");
        }
    }
}
