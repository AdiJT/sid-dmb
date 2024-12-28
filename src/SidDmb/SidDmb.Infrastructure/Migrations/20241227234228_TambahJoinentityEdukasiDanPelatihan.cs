using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SidDmb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahJoinentityEdukasiDanPelatihan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KolaboratorMateri_Kolaborator_DaftarKolaboratorId",
                table: "KolaboratorMateri");

            migrationBuilder.DropForeignKey(
                name: "FK_KolaboratorMateri_Materi_DaftarMateriId",
                table: "KolaboratorMateri");

            migrationBuilder.DropForeignKey(
                name: "FK_KolaboratorPelatihan_Kolaborator_DaftarKolaboratorId",
                table: "KolaboratorPelatihan");

            migrationBuilder.DropForeignKey(
                name: "FK_KolaboratorPelatihan_Pelatihan_DaftarPelatihanId",
                table: "KolaboratorPelatihan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KolaboratorPelatihan",
                table: "KolaboratorPelatihan");

            migrationBuilder.DropIndex(
                name: "IX_KolaboratorPelatihan_DaftarPelatihanId",
                table: "KolaboratorPelatihan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KolaboratorMateri",
                table: "KolaboratorMateri");

            migrationBuilder.DropIndex(
                name: "IX_KolaboratorMateri_DaftarMateriId",
                table: "KolaboratorMateri");

            migrationBuilder.DropColumn(
                name: "RekomendasiUntukPelatihanBerikutnya",
                table: "Pelatihan");

            migrationBuilder.DropColumn(
                name: "RekomendasiPembaruanMateri",
                table: "Materi");

            migrationBuilder.RenameColumn(
                name: "DaftarPelatihanId",
                table: "KolaboratorPelatihan",
                newName: "RekomendasiUntukPelatihanBerikutnya");

            migrationBuilder.RenameColumn(
                name: "DaftarKolaboratorId",
                table: "KolaboratorPelatihan",
                newName: "Entity2Id");

            migrationBuilder.RenameColumn(
                name: "DaftarMateriId",
                table: "KolaboratorMateri",
                newName: "RekomendasiPembaruanMateri");

            migrationBuilder.RenameColumn(
                name: "DaftarKolaboratorId",
                table: "KolaboratorMateri",
                newName: "Entity2Id");

            migrationBuilder.AddColumn<string>(
                name: "Entity1Id",
                table: "KolaboratorPelatihan",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Entity1Id",
                table: "KolaboratorMateri",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KolaboratorPelatihan",
                table: "KolaboratorPelatihan",
                columns: new[] { "Entity1Id", "Entity2Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_KolaboratorMateri",
                table: "KolaboratorMateri",
                columns: new[] { "Entity1Id", "Entity2Id" });

            migrationBuilder.CreateIndex(
                name: "IX_KolaboratorPelatihan_Entity2Id",
                table: "KolaboratorPelatihan",
                column: "Entity2Id");

            migrationBuilder.CreateIndex(
                name: "IX_KolaboratorMateri_Entity2Id",
                table: "KolaboratorMateri",
                column: "Entity2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KolaboratorMateri_Kolaborator_Entity2Id",
                table: "KolaboratorMateri",
                column: "Entity2Id",
                principalTable: "Kolaborator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KolaboratorMateri_Materi_Entity1Id",
                table: "KolaboratorMateri",
                column: "Entity1Id",
                principalTable: "Materi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KolaboratorPelatihan_Kolaborator_Entity2Id",
                table: "KolaboratorPelatihan",
                column: "Entity2Id",
                principalTable: "Kolaborator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KolaboratorPelatihan_Pelatihan_Entity1Id",
                table: "KolaboratorPelatihan",
                column: "Entity1Id",
                principalTable: "Pelatihan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KolaboratorMateri_Kolaborator_Entity2Id",
                table: "KolaboratorMateri");

            migrationBuilder.DropForeignKey(
                name: "FK_KolaboratorMateri_Materi_Entity1Id",
                table: "KolaboratorMateri");

            migrationBuilder.DropForeignKey(
                name: "FK_KolaboratorPelatihan_Kolaborator_Entity2Id",
                table: "KolaboratorPelatihan");

            migrationBuilder.DropForeignKey(
                name: "FK_KolaboratorPelatihan_Pelatihan_Entity1Id",
                table: "KolaboratorPelatihan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KolaboratorPelatihan",
                table: "KolaboratorPelatihan");

            migrationBuilder.DropIndex(
                name: "IX_KolaboratorPelatihan_Entity2Id",
                table: "KolaboratorPelatihan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KolaboratorMateri",
                table: "KolaboratorMateri");

            migrationBuilder.DropIndex(
                name: "IX_KolaboratorMateri_Entity2Id",
                table: "KolaboratorMateri");

            migrationBuilder.DropColumn(
                name: "Entity1Id",
                table: "KolaboratorPelatihan");

            migrationBuilder.DropColumn(
                name: "Entity1Id",
                table: "KolaboratorMateri");

            migrationBuilder.RenameColumn(
                name: "RekomendasiUntukPelatihanBerikutnya",
                table: "KolaboratorPelatihan",
                newName: "DaftarPelatihanId");

            migrationBuilder.RenameColumn(
                name: "Entity2Id",
                table: "KolaboratorPelatihan",
                newName: "DaftarKolaboratorId");

            migrationBuilder.RenameColumn(
                name: "RekomendasiPembaruanMateri",
                table: "KolaboratorMateri",
                newName: "DaftarMateriId");

            migrationBuilder.RenameColumn(
                name: "Entity2Id",
                table: "KolaboratorMateri",
                newName: "DaftarKolaboratorId");

            migrationBuilder.AddColumn<string>(
                name: "RekomendasiUntukPelatihanBerikutnya",
                table: "Pelatihan",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RekomendasiPembaruanMateri",
                table: "Materi",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KolaboratorPelatihan",
                table: "KolaboratorPelatihan",
                columns: new[] { "DaftarKolaboratorId", "DaftarPelatihanId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_KolaboratorMateri",
                table: "KolaboratorMateri",
                columns: new[] { "DaftarKolaboratorId", "DaftarMateriId" });

            migrationBuilder.CreateIndex(
                name: "IX_KolaboratorPelatihan_DaftarPelatihanId",
                table: "KolaboratorPelatihan",
                column: "DaftarPelatihanId");

            migrationBuilder.CreateIndex(
                name: "IX_KolaboratorMateri_DaftarMateriId",
                table: "KolaboratorMateri",
                column: "DaftarMateriId");

            migrationBuilder.AddForeignKey(
                name: "FK_KolaboratorMateri_Kolaborator_DaftarKolaboratorId",
                table: "KolaboratorMateri",
                column: "DaftarKolaboratorId",
                principalTable: "Kolaborator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KolaboratorMateri_Materi_DaftarMateriId",
                table: "KolaboratorMateri",
                column: "DaftarMateriId",
                principalTable: "Materi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KolaboratorPelatihan_Kolaborator_DaftarKolaboratorId",
                table: "KolaboratorPelatihan",
                column: "DaftarKolaboratorId",
                principalTable: "Kolaborator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KolaboratorPelatihan_Pelatihan_DaftarPelatihanId",
                table: "KolaboratorPelatihan",
                column: "DaftarPelatihanId",
                principalTable: "Pelatihan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
