using Microsoft.EntityFrameworkCore.Migrations;

namespace E_TS.Migrations
{
    public partial class ECardTripsTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPeriod",
                table: "ECards");

            migrationBuilder.DropColumn(
                name: "Trips",
                table: "ECards");

            migrationBuilder.CreateTable(
                name: "ECardTrips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransportType = table.Column<int>(type: "int", nullable: true),
                    TransportNumber = table.Column<int>(type: "int", nullable: true),
                    Trips = table.Column<int>(type: "int", nullable: true),
                    IsBought = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ECardTrips", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ECardTrips");

            migrationBuilder.AddColumn<bool>(
                name: "IsPeriod",
                table: "ECards",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Trips",
                table: "ECards",
                type: "int",
                nullable: true);
        }
    }
}
