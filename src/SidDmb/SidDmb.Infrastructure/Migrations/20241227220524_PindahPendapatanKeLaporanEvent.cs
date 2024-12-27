using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SidDmb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PindahPendapatanKeLaporanEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pendapatan",
                table: "Event");

            migrationBuilder.AddColumn<double>(
                name: "PendapatanEvent",
                table: "LaporanEvent",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PendapatanEvent",
                table: "LaporanEvent");

            migrationBuilder.AddColumn<double>(
                name: "Pendapatan",
                table: "Event",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
