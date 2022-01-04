using Microsoft.EntityFrameworkCore.Migrations;

namespace E_TS.Migrations
{
    public partial class AddIsExpiredFunctionality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isExpired",
                table: "Tickets",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isExpired",
                table: "Tickets");
        }
    }
}
