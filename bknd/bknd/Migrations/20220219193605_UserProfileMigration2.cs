using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bknd.Migrations
{
    public partial class UserProfileMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Teams",
                table: "userprofiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "birthday",
                table: "userprofiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "fbLink",
                table: "userprofiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "phoneNum",
                table: "userprofiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "picture",
                table: "userprofiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "userprofiles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_userprofiles_userId",
                table: "userprofiles",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_userprofiles_users_userId",
                table: "userprofiles",
                column: "userId",
                principalTable: "users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userprofiles_users_userId",
                table: "userprofiles");

            migrationBuilder.DropIndex(
                name: "IX_userprofiles_userId",
                table: "userprofiles");

            migrationBuilder.DropColumn(
                name: "Teams",
                table: "userprofiles");

            migrationBuilder.DropColumn(
                name: "birthday",
                table: "userprofiles");

            migrationBuilder.DropColumn(
                name: "fbLink",
                table: "userprofiles");

            migrationBuilder.DropColumn(
                name: "phoneNum",
                table: "userprofiles");

            migrationBuilder.DropColumn(
                name: "picture",
                table: "userprofiles");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "userprofiles");
        }
    }
}
