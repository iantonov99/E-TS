using Microsoft.EntityFrameworkCore.Migrations;

namespace E_TS.Migrations
{
    public partial class AddedForeignKeysForUserOnAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPrim",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Reservations",
                newName: "IsDeclined");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeclined",
                table: "Tickets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeclined",
                table: "ECardTrips",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ECardTrips",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeclined",
                table: "ECards",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ECards",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ECardTrips_UserId",
                table: "ECardTrips",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ECards_UserId",
                table: "ECards",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ECards_AspNetUsers_UserId",
                table: "ECards",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ECardTrips_AspNetUsers_UserId",
                table: "ECardTrips",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_UserId",
                table: "Tickets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ECards_AspNetUsers_UserId",
                table: "ECards");

            migrationBuilder.DropForeignKey(
                name: "FK_ECardTrips_AspNetUsers_UserId",
                table: "ECardTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_UserId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_ECardTrips_UserId",
                table: "ECardTrips");

            migrationBuilder.DropIndex(
                name: "IX_ECards_UserId",
                table: "ECards");

            migrationBuilder.DropColumn(
                name: "IsDeclined",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "IsDeclined",
                table: "ECardTrips");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ECardTrips");

            migrationBuilder.DropColumn(
                name: "IsDeclined",
                table: "ECards");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ECards");

            migrationBuilder.RenameColumn(
                name: "IsDeclined",
                table: "Reservations",
                newName: "IsActive");

            migrationBuilder.AddColumn<int>(
                name: "IdPrim",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
