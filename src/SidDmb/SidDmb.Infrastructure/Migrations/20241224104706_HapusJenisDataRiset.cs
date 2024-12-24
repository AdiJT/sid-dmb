using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SidDmb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HapusJenisDataRiset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataRisetJenisDataRiset");

            migrationBuilder.DropTable(
                name: "JenisDataRiset");

            migrationBuilder.AddColumn<string[]>(
                name: "DaftarJenisDataRiset",
                table: "DataRiset",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DaftarJenisDataRiset",
                table: "DataRiset");

            migrationBuilder.CreateTable(
                name: "JenisDataRiset",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JenisDataRiset", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataRisetJenisDataRiset",
                columns: table => new
                {
                    DaftarDataRisetId = table.Column<string>(type: "text", nullable: false),
                    DaftarJenisDataRisetId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataRisetJenisDataRiset", x => new { x.DaftarDataRisetId, x.DaftarJenisDataRisetId });
                    table.ForeignKey(
                        name: "FK_DataRisetJenisDataRiset_DataRiset_DaftarDataRisetId",
                        column: x => x.DaftarDataRisetId,
                        principalTable: "DataRiset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataRisetJenisDataRiset_JenisDataRiset_DaftarJenisDataRiset~",
                        column: x => x.DaftarJenisDataRisetId,
                        principalTable: "JenisDataRiset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataRisetJenisDataRiset_DaftarJenisDataRisetId",
                table: "DataRisetJenisDataRiset",
                column: "DaftarJenisDataRisetId");
        }
    }
}
