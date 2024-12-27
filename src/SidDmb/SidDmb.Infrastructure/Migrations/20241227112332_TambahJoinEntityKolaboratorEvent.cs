using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SidDmb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TambahJoinEntityKolaboratorEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventKolaborator");

            migrationBuilder.CreateTable(
                name: "KolaboratorEvent",
                columns: table => new
                {
                    Entity1Id = table.Column<string>(type: "text", nullable: false),
                    Entity2Id = table.Column<int>(type: "integer", nullable: false),
                    MasukanKolaborator = table.Column<string>(type: "text", nullable: false),
                    RekomedasiEventBerikutnya = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KolaboratorEvent", x => new { x.Entity1Id, x.Entity2Id });
                    table.ForeignKey(
                        name: "FK_KolaboratorEvent_Event_Entity1Id",
                        column: x => x.Entity1Id,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KolaboratorEvent_Kolaborator_Entity2Id",
                        column: x => x.Entity2Id,
                        principalTable: "Kolaborator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KolaboratorEvent_Entity2Id",
                table: "KolaboratorEvent",
                column: "Entity2Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KolaboratorEvent");

            migrationBuilder.CreateTable(
                name: "EventKolaborator",
                columns: table => new
                {
                    DaftarEventId = table.Column<string>(type: "text", nullable: false),
                    DaftarKolaboratorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventKolaborator", x => new { x.DaftarEventId, x.DaftarKolaboratorId });
                    table.ForeignKey(
                        name: "FK_EventKolaborator_Event_DaftarEventId",
                        column: x => x.DaftarEventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventKolaborator_Kolaborator_DaftarKolaboratorId",
                        column: x => x.DaftarKolaboratorId,
                        principalTable: "Kolaborator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventKolaborator_DaftarKolaboratorId",
                table: "EventKolaborator",
                column: "DaftarKolaboratorId");
        }
    }
}
