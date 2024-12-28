using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SidDmb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahSemuaJoinEntityKeKolaborator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KolaboratorRekomendasi_Kolaborator_DaftarKolaboratorId",
                table: "KolaboratorRekomendasi");

            migrationBuilder.DropForeignKey(
                name: "FK_KolaboratorRekomendasi_Rekomendasi_DaftarRekomendasiId",
                table: "KolaboratorRekomendasi");

            migrationBuilder.DropForeignKey(
                name: "FK_KolaboratorSertifikasi_Kolaborator_DaftarKolaboratorId",
                table: "KolaboratorSertifikasi");

            migrationBuilder.DropForeignKey(
                name: "FK_KolaboratorSertifikasi_Sertifikasi_DaftarSertifikasiId",
                table: "KolaboratorSertifikasi");

            migrationBuilder.DropTable(
                name: "DataRisetKolaborator");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KolaboratorSertifikasi",
                table: "KolaboratorSertifikasi");

            migrationBuilder.DropIndex(
                name: "IX_KolaboratorSertifikasi_DaftarSertifikasiId",
                table: "KolaboratorSertifikasi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KolaboratorRekomendasi",
                table: "KolaboratorRekomendasi");

            migrationBuilder.DropIndex(
                name: "IX_KolaboratorRekomendasi_DaftarRekomendasiId",
                table: "KolaboratorRekomendasi");

            migrationBuilder.DropColumn(
                name: "Komentar",
                table: "Sertifikasi");

            migrationBuilder.DropColumn(
                name: "FeedbackKolaborator",
                table: "Rekomendasi");

            migrationBuilder.DropColumn(
                name: "FeedbackKolaborator",
                table: "DataRiset");

            migrationBuilder.RenameColumn(
                name: "DaftarSertifikasiId",
                table: "KolaboratorSertifikasi",
                newName: "Komentar");

            migrationBuilder.RenameColumn(
                name: "DaftarKolaboratorId",
                table: "KolaboratorSertifikasi",
                newName: "Entity2Id");

            migrationBuilder.RenameColumn(
                name: "DaftarRekomendasiId",
                table: "KolaboratorRekomendasi",
                newName: "FeedbackKolaborator");

            migrationBuilder.RenameColumn(
                name: "DaftarKolaboratorId",
                table: "KolaboratorRekomendasi",
                newName: "Entity2Id");

            migrationBuilder.AddColumn<string>(
                name: "Entity1Id",
                table: "KolaboratorSertifikasi",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Entity1Id",
                table: "KolaboratorRekomendasi",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KolaboratorSertifikasi",
                table: "KolaboratorSertifikasi",
                columns: new[] { "Entity1Id", "Entity2Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_KolaboratorRekomendasi",
                table: "KolaboratorRekomendasi",
                columns: new[] { "Entity1Id", "Entity2Id" });

            migrationBuilder.CreateTable(
                name: "KolaboratorDataRiset",
                columns: table => new
                {
                    Entity1Id = table.Column<string>(type: "text", nullable: false),
                    Entity2Id = table.Column<int>(type: "integer", nullable: false),
                    FeedbackKolaborator = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KolaboratorDataRiset", x => new { x.Entity1Id, x.Entity2Id });
                    table.ForeignKey(
                        name: "FK_KolaboratorDataRiset_DataRiset_Entity1Id",
                        column: x => x.Entity1Id,
                        principalTable: "DataRiset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KolaboratorDataRiset_Kolaborator_Entity2Id",
                        column: x => x.Entity2Id,
                        principalTable: "Kolaborator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KolaboratorSertifikasi_Entity2Id",
                table: "KolaboratorSertifikasi",
                column: "Entity2Id");

            migrationBuilder.CreateIndex(
                name: "IX_KolaboratorRekomendasi_Entity2Id",
                table: "KolaboratorRekomendasi",
                column: "Entity2Id");

            migrationBuilder.CreateIndex(
                name: "IX_KolaboratorDataRiset_Entity2Id",
                table: "KolaboratorDataRiset",
                column: "Entity2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KolaboratorRekomendasi_Kolaborator_Entity2Id",
                table: "KolaboratorRekomendasi",
                column: "Entity2Id",
                principalTable: "Kolaborator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KolaboratorRekomendasi_Rekomendasi_Entity1Id",
                table: "KolaboratorRekomendasi",
                column: "Entity1Id",
                principalTable: "Rekomendasi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KolaboratorSertifikasi_Kolaborator_Entity2Id",
                table: "KolaboratorSertifikasi",
                column: "Entity2Id",
                principalTable: "Kolaborator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KolaboratorSertifikasi_Sertifikasi_Entity1Id",
                table: "KolaboratorSertifikasi",
                column: "Entity1Id",
                principalTable: "Sertifikasi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KolaboratorRekomendasi_Kolaborator_Entity2Id",
                table: "KolaboratorRekomendasi");

            migrationBuilder.DropForeignKey(
                name: "FK_KolaboratorRekomendasi_Rekomendasi_Entity1Id",
                table: "KolaboratorRekomendasi");

            migrationBuilder.DropForeignKey(
                name: "FK_KolaboratorSertifikasi_Kolaborator_Entity2Id",
                table: "KolaboratorSertifikasi");

            migrationBuilder.DropForeignKey(
                name: "FK_KolaboratorSertifikasi_Sertifikasi_Entity1Id",
                table: "KolaboratorSertifikasi");

            migrationBuilder.DropTable(
                name: "KolaboratorDataRiset");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KolaboratorSertifikasi",
                table: "KolaboratorSertifikasi");

            migrationBuilder.DropIndex(
                name: "IX_KolaboratorSertifikasi_Entity2Id",
                table: "KolaboratorSertifikasi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KolaboratorRekomendasi",
                table: "KolaboratorRekomendasi");

            migrationBuilder.DropIndex(
                name: "IX_KolaboratorRekomendasi_Entity2Id",
                table: "KolaboratorRekomendasi");

            migrationBuilder.DropColumn(
                name: "Entity1Id",
                table: "KolaboratorSertifikasi");

            migrationBuilder.DropColumn(
                name: "Entity1Id",
                table: "KolaboratorRekomendasi");

            migrationBuilder.RenameColumn(
                name: "Komentar",
                table: "KolaboratorSertifikasi",
                newName: "DaftarSertifikasiId");

            migrationBuilder.RenameColumn(
                name: "Entity2Id",
                table: "KolaboratorSertifikasi",
                newName: "DaftarKolaboratorId");

            migrationBuilder.RenameColumn(
                name: "FeedbackKolaborator",
                table: "KolaboratorRekomendasi",
                newName: "DaftarRekomendasiId");

            migrationBuilder.RenameColumn(
                name: "Entity2Id",
                table: "KolaboratorRekomendasi",
                newName: "DaftarKolaboratorId");

            migrationBuilder.AddColumn<string>(
                name: "Komentar",
                table: "Sertifikasi",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FeedbackKolaborator",
                table: "Rekomendasi",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FeedbackKolaborator",
                table: "DataRiset",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KolaboratorSertifikasi",
                table: "KolaboratorSertifikasi",
                columns: new[] { "DaftarKolaboratorId", "DaftarSertifikasiId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_KolaboratorRekomendasi",
                table: "KolaboratorRekomendasi",
                columns: new[] { "DaftarKolaboratorId", "DaftarRekomendasiId" });

            migrationBuilder.CreateTable(
                name: "DataRisetKolaborator",
                columns: table => new
                {
                    DaftarDataRisetId = table.Column<string>(type: "text", nullable: false),
                    DaftarKolaboratorPenelitianId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataRisetKolaborator", x => new { x.DaftarDataRisetId, x.DaftarKolaboratorPenelitianId });
                    table.ForeignKey(
                        name: "FK_DataRisetKolaborator_DataRiset_DaftarDataRisetId",
                        column: x => x.DaftarDataRisetId,
                        principalTable: "DataRiset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataRisetKolaborator_Kolaborator_DaftarKolaboratorPenelitia~",
                        column: x => x.DaftarKolaboratorPenelitianId,
                        principalTable: "Kolaborator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KolaboratorSertifikasi_DaftarSertifikasiId",
                table: "KolaboratorSertifikasi",
                column: "DaftarSertifikasiId");

            migrationBuilder.CreateIndex(
                name: "IX_KolaboratorRekomendasi_DaftarRekomendasiId",
                table: "KolaboratorRekomendasi",
                column: "DaftarRekomendasiId");

            migrationBuilder.CreateIndex(
                name: "IX_DataRisetKolaborator_DaftarKolaboratorPenelitianId",
                table: "DataRisetKolaborator",
                column: "DaftarKolaboratorPenelitianId");

            migrationBuilder.AddForeignKey(
                name: "FK_KolaboratorRekomendasi_Kolaborator_DaftarKolaboratorId",
                table: "KolaboratorRekomendasi",
                column: "DaftarKolaboratorId",
                principalTable: "Kolaborator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KolaboratorRekomendasi_Rekomendasi_DaftarRekomendasiId",
                table: "KolaboratorRekomendasi",
                column: "DaftarRekomendasiId",
                principalTable: "Rekomendasi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KolaboratorSertifikasi_Kolaborator_DaftarKolaboratorId",
                table: "KolaboratorSertifikasi",
                column: "DaftarKolaboratorId",
                principalTable: "Kolaborator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KolaboratorSertifikasi_Sertifikasi_DaftarSertifikasiId",
                table: "KolaboratorSertifikasi",
                column: "DaftarSertifikasiId",
                principalTable: "Sertifikasi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
