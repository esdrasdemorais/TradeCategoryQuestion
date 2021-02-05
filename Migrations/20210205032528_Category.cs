using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeCategoryQuestion.Migrations
{
    public partial class Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientSector",
                table: "Trade",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NextPaymentDate",
                table: "Trade",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Value",
                table: "Trade",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "GreaterThan",
                table: "Category",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<short>(
                name: "Period",
                table: "Category",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<int>(
                name: "Sector",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientSector",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "NextPaymentDate",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "GreaterThan",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Sector",
                table: "Category");
        }
    }
}
