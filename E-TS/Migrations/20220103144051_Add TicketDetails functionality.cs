using Microsoft.EntityFrameworkCore.Migrations;

namespace E_TS.Migrations
{
    public partial class AddTicketDetailsfunctionality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bus",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "TicketDetailId",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TicketDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TicketName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketDetails", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketDetailId",
                table: "Tickets",
                column: "TicketDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketDetails_TicketDetailId",
                table: "Tickets",
                column: "TicketDetailId",
                principalTable: "TicketDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketDetails_TicketDetailId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "TicketDetails");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_TicketDetailId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketDetailId",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "Bus",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
