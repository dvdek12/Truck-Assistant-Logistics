using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckAssistant.Migrations
{
    public partial class Truck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<int>(
                name: "DriverBreaksLength",
                table: "Truck",
                nullable: false,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DriverBreaksInterval",
                table: "Truck",
                nullable: false,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "Truck");
        }
    }
}
