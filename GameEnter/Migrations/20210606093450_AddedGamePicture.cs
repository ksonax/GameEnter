using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameEnter.Migrations
{
    public partial class AddedGamePicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "GamePicture",
                table: "GameModel",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GamePicture",
                table: "GameModel");
        }
    }
}
