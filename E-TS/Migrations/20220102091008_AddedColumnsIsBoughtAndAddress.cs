using Microsoft.EntityFrameworkCore.Migrations;

namespace E_TS.Migrations
{
    public partial class AddedColumnsIsBoughtAndAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBought",
                table: "Tickets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBought",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsBought",
                table: "ECards",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBought",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "IsBought",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "IsBought",
                table: "ECards");
        }
    }
}
