using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarConfiguratorAPI.Migrations
{
    public partial class removeimagecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Wheels");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Paints");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Optionals");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Engines");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Wheels",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Paints",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Optionals",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Engines",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
