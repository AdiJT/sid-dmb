using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SidDmb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahDataProduk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Produk",
                columns: new[] { "Id", "Dekripsi", "HargaProduk", "Kategori", "LegalitasProduk", "MediaPromosi", "Nama", "StatusKetersediaan", "StokAwal", "StokSaatIni", "TanggalDiinputkan", "TanggalKadaluarsa", "TanggalPembaruanData", "TanggalProduksiTerakhir", "UnitUsahaTerkait" },
                values: new object[] { "MP001", "Batik tulis dengan pewarna alami dan motif khas Desa Gilangharjo.", 150000.0, 0, "PIRT 12345/2024, Halal MUI", "/assets/produklokal2-test.png", "Batik Tulis Gilang", 0, 100, 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2024, 12, 1), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2024, 12, 1), "Batik Gilang Sejahtera" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produk",
                keyColumn: "Id",
                keyValue: "MP001");
        }
    }
}
