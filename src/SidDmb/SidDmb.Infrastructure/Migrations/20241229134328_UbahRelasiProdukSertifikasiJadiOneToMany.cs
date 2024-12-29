using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SidDmb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UbahRelasiProdukSertifikasiJadiOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sertifikasi_ProdukId",
                table: "Sertifikasi");

            migrationBuilder.DropColumn(
                name: "LegalitasProduk",
                table: "Produk");

            migrationBuilder.CreateIndex(
                name: "IX_Sertifikasi_ProdukId",
                table: "Sertifikasi",
                column: "ProdukId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sertifikasi_ProdukId",
                table: "Sertifikasi");

            migrationBuilder.AddColumn<string>(
                name: "LegalitasProduk",
                table: "Produk",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Produk",
                keyColumn: "Id",
                keyValue: "MP001",
                column: "LegalitasProduk",
                value: "PIRT 12345/2024, Halal MUI");

            migrationBuilder.CreateIndex(
                name: "IX_Sertifikasi_ProdukId",
                table: "Sertifikasi",
                column: "ProdukId",
                unique: true);
        }
    }
}
