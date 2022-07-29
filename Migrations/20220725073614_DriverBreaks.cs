using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruckAssistant.Migrations
{
    public partial class DriverBreaks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trip_Truck_TruckId",
                table: "Trip");

            migrationBuilder.RenameColumn(
                name: "DriverBreaks",
                table: "Truck",
                newName: "DriverBreaksLength");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Truck",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DriverBreaksInterval",
                table: "Truck",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Truck",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DriverBreaksInterval",
                table: "Truck",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TruckId",
                table: "Trip",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Trip",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_Truck_TruckId",
                table: "Trip",
                column: "TruckId",
                principalTable: "Truck",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trip_Truck_TruckId",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "DriverBreaksInterval",
                table: "Truck");

            migrationBuilder.RenameColumn(
                name: "DriverBreaksLength",
                table: "Truck",
                newName: "DriverBreaks");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Truck",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Truck",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TruckId",
                table: "Trip",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Trip",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_Truck_TruckId",
                table: "Trip",
                column: "TruckId",
                principalTable: "Truck",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
