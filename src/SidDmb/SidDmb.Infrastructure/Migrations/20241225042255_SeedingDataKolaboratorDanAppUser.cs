using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SidDmb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataKolaboratorDanAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "PasswordHash", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, "AQAAAAIAAYagAAAAEIvnLFelRQItxw7VYqY6lQ23tSsOmnZ3FMifozrOmDHUmPCZrAYjnbzfDR07zgFJjw==", "ADMIN", "Admin" },
                    { 2, "AQAAAAIAAYagAAAAEJhTWHliTZKRD57TRJFPsWpZgZsWxU21omcBx/HdNuyMFsj+2Ibhs2z2aCYVGwEUsw==", "KOLABORATOR", "Dinas Pariwisata" },
                    { 3, "AQAAAAIAAYagAAAAEJhTWHliTZKRD57TRJFPsWpZgZsWxU21omcBx/HdNuyMFsj+2Ibhs2z2aCYVGwEUsw==", "KOLABORATOR", "Dinas Kebudayaan" },
                    { 4, "AQAAAAIAAYagAAAAEJhTWHliTZKRD57TRJFPsWpZgZsWxU21omcBx/HdNuyMFsj+2Ibhs2z2aCYVGwEUsw==", "KOLABORATOR", "Dinas Koperasi UMKM" },
                    { 5, "AQAAAAIAAYagAAAAEJhTWHliTZKRD57TRJFPsWpZgZsWxU21omcBx/HdNuyMFsj+2Ibhs2z2aCYVGwEUsw==", "KOLABORATOR", "DP3AP2" },
                    { 6, "AQAAAAIAAYagAAAAEJhTWHliTZKRD57TRJFPsWpZgZsWxU21omcBx/HdNuyMFsj+2Ibhs2z2aCYVGwEUsw==", "KOLABORATOR", "Assosiacation" },
                    { 7, "AQAAAAIAAYagAAAAEJhTWHliTZKRD57TRJFPsWpZgZsWxU21omcBx/HdNuyMFsj+2Ibhs2z2aCYVGwEUsw==", "KOLABORATOR", "BPOM" },
                    { 8, "AQAAAAIAAYagAAAAEJhTWHliTZKRD57TRJFPsWpZgZsWxU21omcBx/HdNuyMFsj+2Ibhs2z2aCYVGwEUsw==", "KOLABORATOR", "Academics" },
                    { 9, "AQAAAAIAAYagAAAAEJhTWHliTZKRD57TRJFPsWpZgZsWxU21omcBx/HdNuyMFsj+2Ibhs2z2aCYVGwEUsw==", "KOLABORATOR", "Media" }
                });

            migrationBuilder.InsertData(
                table: "Kolaborator",
                columns: new[] { "Id", "AppUserId", "Nama" },
                values: new object[,]
                {
                    { 2, 2, "Dinas Pariwisata" },
                    { 3, 3, "Dinas Kebudayaan" },
                    { 4, 4, "Dinas Koperasi UMKM" },
                    { 5, 5, "DP3AP2" },
                    { 6, 6, "Assosiacation" },
                    { 7, 7, "BPOM" },
                    { 8, 8, "Academics" },
                    { 9, 9, "Media" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kolaborator",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Kolaborator",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Kolaborator",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Kolaborator",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Kolaborator",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Kolaborator",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Kolaborator",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Kolaborator",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
