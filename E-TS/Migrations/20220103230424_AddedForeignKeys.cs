using Microsoft.EntityFrameworkCore.Migrations;

namespace E_TS.Migrations
{
    public partial class AddedForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransportType",
                table: "ECardTrips");

            migrationBuilder.DropColumn(
                name: "TransportType",
                table: "ECards");

            migrationBuilder.AlterColumn<int>(
                name: "TransportNumber",
                table: "ECardTrips",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TransportTypeId",
                table: "ECardTrips",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TransportNumber",
                table: "ECards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TransportTypeId",
                table: "ECards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ECardTrips_TransportNumber",
                table: "ECardTrips",
                column: "TransportNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ECardTrips_TransportTypeId",
                table: "ECardTrips",
                column: "TransportTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ECards_TransportNumber",
                table: "ECards",
                column: "TransportNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ECards_TransportTypeId",
                table: "ECards",
                column: "TransportTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ECards_TransportLines_TransportNumber",
                table: "ECards",
                column: "TransportNumber",
                principalTable: "TransportLines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ECards_TransportTypes_TransportTypeId",
                table: "ECards",
                column: "TransportTypeId",
                principalTable: "TransportTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ECardTrips_TransportLines_TransportNumber",
                table: "ECardTrips",
                column: "TransportNumber",
                principalTable: "TransportLines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ECardTrips_TransportTypes_TransportTypeId",
                table: "ECardTrips",
                column: "TransportTypeId",
                principalTable: "TransportTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ECards_TransportLines_TransportNumber",
                table: "ECards");

            migrationBuilder.DropForeignKey(
                name: "FK_ECards_TransportTypes_TransportTypeId",
                table: "ECards");

            migrationBuilder.DropForeignKey(
                name: "FK_ECardTrips_TransportLines_TransportNumber",
                table: "ECardTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_ECardTrips_TransportTypes_TransportTypeId",
                table: "ECardTrips");

            migrationBuilder.DropIndex(
                name: "IX_ECardTrips_TransportNumber",
                table: "ECardTrips");

            migrationBuilder.DropIndex(
                name: "IX_ECardTrips_TransportTypeId",
                table: "ECardTrips");

            migrationBuilder.DropIndex(
                name: "IX_ECards_TransportNumber",
                table: "ECards");

            migrationBuilder.DropIndex(
                name: "IX_ECards_TransportTypeId",
                table: "ECards");

            migrationBuilder.DropColumn(
                name: "TransportTypeId",
                table: "ECardTrips");

            migrationBuilder.DropColumn(
                name: "TransportTypeId",
                table: "ECards");

            migrationBuilder.AlterColumn<int>(
                name: "TransportNumber",
                table: "ECardTrips",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransportType",
                table: "ECardTrips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TransportNumber",
                table: "ECards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransportType",
                table: "ECards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
