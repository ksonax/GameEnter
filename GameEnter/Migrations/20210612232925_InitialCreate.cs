using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameEnter.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LobbyModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LobbyGameId = table.Column<int>(type: "int", nullable: true),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LobbyModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameEnterUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    LobbyId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameEnterUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameEnterUser_LobbyModel_LobbyId",
                        column: x => x.LobbyId,
                        principalTable: "LobbyModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserGamesModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGamesModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGamesModel_GameEnterUser_UserId",
                        column: x => x.UserId,
                        principalTable: "GameEnterUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GamePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UserGamesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameModel_UserGamesModel_UserGamesId",
                        column: x => x.UserGamesId,
                        principalTable: "UserGamesModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameEnterUser_LobbyId",
                table: "GameEnterUser",
                column: "LobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_GameModel_UserGamesId",
                table: "GameModel",
                column: "UserGamesId");

            migrationBuilder.CreateIndex(
                name: "IX_LobbyModel_LobbyGameId",
                table: "LobbyModel",
                column: "LobbyGameId");

            migrationBuilder.CreateIndex(
                name: "IX_LobbyModel_OwnerId",
                table: "LobbyModel",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGamesModel_UserId",
                table: "UserGamesModel",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LobbyModel_GameEnterUser_OwnerId",
                table: "LobbyModel",
                column: "OwnerId",
                principalTable: "GameEnterUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LobbyModel_GameModel_LobbyGameId",
                table: "LobbyModel",
                column: "LobbyGameId",
                principalTable: "GameModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameEnterUser_LobbyModel_LobbyId",
                table: "GameEnterUser");

            migrationBuilder.DropTable(
                name: "LobbyModel");

            migrationBuilder.DropTable(
                name: "GameModel");

            migrationBuilder.DropTable(
                name: "UserGamesModel");

            migrationBuilder.DropTable(
                name: "GameEnterUser");
        }
    }
}
