using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservationsManager.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientsSet",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Adult = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientsSet", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "RoomsSet",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    PriceAdults = table.Column<decimal>(type: "money", nullable: false),
                    PriceChildren = table.Column<decimal>(type: "money", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomsSet", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "UsersSet",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    EGN = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Admin = table.Column<bool>(type: "bit", nullable: false),
                    HireDate = table.Column<DateTime>(type: "date", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    DismissalDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersSet", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ReservationsSet",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Room = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "date", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "date", nullable: false),
                    Breakfast = table.Column<bool>(type: "bit", nullable: false),
                    AllInclusive = table.Column<bool>(type: "bit", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationsSet", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_ReservationsSet_UsersSet_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersSet",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationsClients",
                columns: table => new
                {
                    ClientReservationsReservationId = table.Column<int>(type: "int", nullable: false),
                    ClientsClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationsClients", x => new { x.ClientReservationsReservationId, x.ClientsClientId });
                    table.ForeignKey(
                        name: "FK_ReservationsClients_ClientsSet_ClientsClientId",
                        column: x => x.ClientsClientId,
                        principalTable: "ClientsSet",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationsClients_ReservationsSet_ClientReservationsReservationId",
                        column: x => x.ClientReservationsReservationId,
                        principalTable: "ReservationsSet",
                        principalColumn: "ReservationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationsRooms",
                columns: table => new
                {
                    RoomReservationsReservationId = table.Column<int>(type: "int", nullable: false),
                    RoomsRoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationsRooms", x => new { x.RoomReservationsReservationId, x.RoomsRoomId });
                    table.ForeignKey(
                        name: "FK_ReservationsRooms_ReservationsSet_RoomReservationsReservationId",
                        column: x => x.RoomReservationsReservationId,
                        principalTable: "ReservationsSet",
                        principalColumn: "ReservationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationsRooms_RoomsSet_RoomsRoomId",
                        column: x => x.RoomsRoomId,
                        principalTable: "RoomsSet",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservationsClients_ClientsClientId",
                table: "ReservationsClients",
                column: "ClientsClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationsRooms_RoomsRoomId",
                table: "ReservationsRooms",
                column: "RoomsRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationsSet_UserId",
                table: "ReservationsSet",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationsClients");

            migrationBuilder.DropTable(
                name: "ReservationsRooms");

            migrationBuilder.DropTable(
                name: "ClientsSet");

            migrationBuilder.DropTable(
                name: "ReservationsSet");

            migrationBuilder.DropTable(
                name: "RoomsSet");

            migrationBuilder.DropTable(
                name: "UsersSet");
        }
    }
}
