using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservationsManager.Migrations
{
    public partial class TableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationsClients_ClientsSet_ClientsClientId",
                table: "ReservationsClients");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationsClients_ReservationsSet_ClientReservationsReservationId",
                table: "ReservationsClients");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationsRooms_ReservationsSet_RoomReservationsReservationId",
                table: "ReservationsRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationsRooms_RoomsSet_RoomsRoomId",
                table: "ReservationsRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationsSet_UsersSet_UserId",
                table: "ReservationsSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersSet",
                table: "UsersSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomsSet",
                table: "RoomsSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservationsSet",
                table: "ReservationsSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientsSet",
                table: "ClientsSet");

            migrationBuilder.RenameTable(
                name: "UsersSet",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "RoomsSet",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "ReservationsSet",
                newName: "Reservations");

            migrationBuilder.RenameTable(
                name: "ClientsSet",
                newName: "Clients");

            migrationBuilder.RenameIndex(
                name: "IX_ReservationsSet_UserId",
                table: "Reservations",
                newName: "IX_Reservations_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "ReservationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationsClients_Clients_ClientsClientId",
                table: "ReservationsClients",
                column: "ClientsClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationsClients_Reservations_ClientReservationsReservationId",
                table: "ReservationsClients",
                column: "ClientReservationsReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationsRooms_Reservations_RoomReservationsReservationId",
                table: "ReservationsRooms",
                column: "RoomReservationsReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationsRooms_Rooms_RoomsRoomId",
                table: "ReservationsRooms",
                column: "RoomsRoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationsClients_Clients_ClientsClientId",
                table: "ReservationsClients");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationsClients_Reservations_ClientReservationsReservationId",
                table: "ReservationsClients");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationsRooms_Reservations_RoomReservationsReservationId",
                table: "ReservationsRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationsRooms_Rooms_RoomsRoomId",
                table: "ReservationsRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UsersSet");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "RoomsSet");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "ReservationsSet");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "ClientsSet");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_UserId",
                table: "ReservationsSet",
                newName: "IX_ReservationsSet_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersSet",
                table: "UsersSet",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomsSet",
                table: "RoomsSet",
                column: "RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservationsSet",
                table: "ReservationsSet",
                column: "ReservationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientsSet",
                table: "ClientsSet",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationsClients_ClientsSet_ClientsClientId",
                table: "ReservationsClients",
                column: "ClientsClientId",
                principalTable: "ClientsSet",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationsClients_ReservationsSet_ClientReservationsReservationId",
                table: "ReservationsClients",
                column: "ClientReservationsReservationId",
                principalTable: "ReservationsSet",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationsRooms_ReservationsSet_RoomReservationsReservationId",
                table: "ReservationsRooms",
                column: "RoomReservationsReservationId",
                principalTable: "ReservationsSet",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationsRooms_RoomsSet_RoomsRoomId",
                table: "ReservationsRooms",
                column: "RoomsRoomId",
                principalTable: "RoomsSet",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationsSet_UsersSet_UserId",
                table: "ReservationsSet",
                column: "UserId",
                principalTable: "UsersSet",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
