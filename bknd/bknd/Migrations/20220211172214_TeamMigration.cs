using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bknd.Migrations
{
    public partial class TeamMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TeamLeadId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GithubLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_teams_users_TeamLeadId",
                        column: x => x.TeamLeadId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_teams_TeamLeadId",
                table: "teams",
                column: "TeamLeadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "teams");
        }
    }
}
