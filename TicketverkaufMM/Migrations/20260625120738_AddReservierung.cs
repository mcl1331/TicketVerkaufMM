using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketverkaufMM.Migrations
{
    /// <inheritdoc />
    public partial class AddReservierung : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservierung_Tisch_TischId",
                table: "Reservierung");

            migrationBuilder.DropTable(
                name: "EventReservierung");

            migrationBuilder.DropTable(
                name: "Tisch");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservierung",
                table: "Reservierung");

            migrationBuilder.DropIndex(
                name: "IX_Reservierung_TischId",
                table: "Reservierung");

            migrationBuilder.RenameTable(
                name: "Reservierung",
                newName: "Reservierungen");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Reservierungen",
                newName: "Personenanzahl");

            migrationBuilder.AddColumn<DateTime>(
                name: "Datum",
                table: "Reservierungen",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Reservierungen",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservierungen",
                table: "Reservierungen",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservierungen_EventId",
                table: "Reservierungen",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservierungen_Event_EventId",
                table: "Reservierungen",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservierungen_Event_EventId",
                table: "Reservierungen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservierungen",
                table: "Reservierungen");

            migrationBuilder.DropIndex(
                name: "IX_Reservierungen_EventId",
                table: "Reservierungen");

            migrationBuilder.DropColumn(
                name: "Datum",
                table: "Reservierungen");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Reservierungen");

            migrationBuilder.RenameTable(
                name: "Reservierungen",
                newName: "Reservierung");

            migrationBuilder.RenameColumn(
                name: "Personenanzahl",
                table: "Reservierung",
                newName: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservierung",
                table: "Reservierung",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EventReservierung",
                columns: table => new
                {
                    EventsEventId = table.Column<int>(type: "int", nullable: false),
                    ReservierungenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventReservierung", x => new { x.EventsEventId, x.ReservierungenId });
                    table.ForeignKey(
                        name: "FK_EventReservierung_Event_EventsEventId",
                        column: x => x.EventsEventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventReservierung_Reservierung_ReservierungenId",
                        column: x => x.ReservierungenId,
                        principalTable: "Reservierung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tisch",
                columns: table => new
                {
                    TischId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TischId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tisch", x => x.TischId);
                    table.ForeignKey(
                        name: "FK_Tisch_Tisch_TischId1",
                        column: x => x.TischId1,
                        principalTable: "Tisch",
                        principalColumn: "TischId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservierung_TischId",
                table: "Reservierung",
                column: "TischId");

            migrationBuilder.CreateIndex(
                name: "IX_EventReservierung_ReservierungenId",
                table: "EventReservierung",
                column: "ReservierungenId");

            migrationBuilder.CreateIndex(
                name: "IX_Tisch_TischId1",
                table: "Tisch",
                column: "TischId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservierung_Tisch_TischId",
                table: "Reservierung",
                column: "TischId",
                principalTable: "Tisch",
                principalColumn: "TischId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
