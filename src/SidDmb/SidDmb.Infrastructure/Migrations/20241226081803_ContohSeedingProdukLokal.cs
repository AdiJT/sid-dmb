using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace SidDmb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ContohSeedingProdukLokal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UnitUsaha",
                columns: new[] { "Id", "Alamat", "Dekripsi", "JumlahKaryawan", "Kategori", "KontakInformasi", "Legalitas", "MediaPromosi", "Nama", "PemilikUsaha", "TanggalBerdiri", "TanggalDiinputkan", "TanggalPembaruanData", "TitikKoordinat" },
                values: new object[] { "UU001", "Jl. Raya Gilang No. 15, Bantul", "Unit usaha yang memproduksi batik tulis dengan motif khas Gilangharjo.", 10, 0, "+62 812-3456-7890", 0, "/assets/produklokal-test.png", "Batik Gilang Sejahtera", "Ibu Siti Aisyah", new DateOnly(2015, 7, 15), new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (110.329 -7.917)") });

            migrationBuilder.InsertData(
                table: "ProdukLokal",
                columns: new[] { "Id", "BahanUtama", "Dekripsi", "Harga", "Kategori", "KontakInformasi", "LegalitasDanSertifikat", "MediaPromosi", "Nama", "StatusKetersediaan", "TanggalDiinputkan", "TanggalKadaluarsa", "TanggalPembaruanData", "TanggalProduksiTerakhir", "UnitUsahaId" },
                values: new object[] { "PL001", "Katun, Pewarna Alami", "Batik tulis berbahan katun dengan motif khas Desa Gilangharjo.", 150000.0, 0, "+62 812-3456-7890", "PIRT 12345/2024, Halal MUI", "/assets/produklokal2-test.png", "Batik Tulis Motif Gilang", 0, new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UU001" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProdukLokal",
                keyColumn: "Id",
                keyValue: "PL001");

            migrationBuilder.DeleteData(
                table: "UnitUsaha",
                keyColumn: "Id",
                keyValue: "UU001");
        }
    }
}
