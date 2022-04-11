using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bknd.Migrations
{
    public partial class worshopsMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkshopId",
                table: "users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "workshops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    trainerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    coverImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    seats = table.Column<int>(type: "int", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    presentation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workshops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_workshops_users_trainerId",
                        column: x => x.trainerId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_WorkshopId",
                table: "users",
                column: "WorkshopId");

            migrationBuilder.CreateIndex(
                name: "IX_workshops_trainerId",
                table: "workshops",
                column: "trainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_workshops_WorkshopId",
                table: "users",
                column: "WorkshopId",
                principalTable: "workshops",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_workshops_WorkshopId",
                table: "users");

            migrationBuilder.DropTable(
                name: "workshops");

            migrationBuilder.DropIndex(
                name: "IX_users_WorkshopId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "WorkshopId",
                table: "users");
        }
    }
}
