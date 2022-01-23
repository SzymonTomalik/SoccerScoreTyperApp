using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSTDataAccessLibrary.Migrations
{
    public partial class InitialDBCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SoccerMatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompetitionGroup = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MatchResult = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    HomeTeamId = table.Column<int>(type: "int", nullable: false),
                    HomeTeam = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HomeTeamScore = table.Column<int>(type: "int", nullable: false),
                    AwayTeamId = table.Column<int>(type: "int", nullable: false),
                    AwayTeam = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AwayTeamScore = table.Column<int>(type: "int", nullable: false),
                    MatchDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoccerMatches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TyperGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TyperGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Typers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Typers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TyperGroupAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TyperId = table.Column<int>(type: "int", nullable: false),
                    TyperGroupId = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TyperGroupAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TyperGroupAccounts_TyperGroups_TyperGroupId",
                        column: x => x.TyperGroupId,
                        principalTable: "TyperGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TyperGroupAccounts_Typers_TyperId",
                        column: x => x.TyperId,
                        principalTable: "Typers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScoreTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypedHomeTeamResult = table.Column<int>(type: "int", nullable: false),
                    TypedAwayTeamResult = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    TyperGroupAccountId = table.Column<int>(type: "int", nullable: false),
                    SoccerMatchId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScoreTypes_SoccerMatches_SoccerMatchId",
                        column: x => x.SoccerMatchId,
                        principalTable: "SoccerMatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScoreTypes_TyperGroupAccounts_TyperGroupAccountId",
                        column: x => x.TyperGroupAccountId,
                        principalTable: "TyperGroupAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScoreTypes_SoccerMatchId",
                table: "ScoreTypes",
                column: "SoccerMatchId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreTypes_TyperGroupAccountId",
                table: "ScoreTypes",
                column: "TyperGroupAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TyperGroupAccounts_TyperGroupId",
                table: "TyperGroupAccounts",
                column: "TyperGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TyperGroupAccounts_TyperId",
                table: "TyperGroupAccounts",
                column: "TyperId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScoreTypes");

            migrationBuilder.DropTable(
                name: "SoccerMatches");

            migrationBuilder.DropTable(
                name: "TyperGroupAccounts");

            migrationBuilder.DropTable(
                name: "TyperGroups");

            migrationBuilder.DropTable(
                name: "Typers");
        }
    }
}
