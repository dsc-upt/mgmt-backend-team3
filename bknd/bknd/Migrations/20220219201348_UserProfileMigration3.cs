using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bknd.Migrations
{
    public partial class UserProfileMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Teams",
                table: "userprofiles");

            migrationBuilder.AddColumn<string>(
                name: "teamId",
                table: "userprofiles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_userprofiles_teamId",
                table: "userprofiles",
                column: "teamId");

            migrationBuilder.AddForeignKey(
                name: "FK_userprofiles_teams_teamId",
                table: "userprofiles",
                column: "teamId",
                principalTable: "teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userprofiles_teams_teamId",
                table: "userprofiles");

            migrationBuilder.DropIndex(
                name: "IX_userprofiles_teamId",
                table: "userprofiles");

            migrationBuilder.DropColumn(
                name: "teamId",
                table: "userprofiles");

            migrationBuilder.AddColumn<string>(
                name: "Teams",
                table: "userprofiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
