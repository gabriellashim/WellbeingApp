using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quokka_App.Migrations
{
    public partial class Addinginsertvalueinmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaderChecked",
                columns: table => new
                {
                    WebAppUserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentReportsID = table.Column<int>(type: "int", nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false),
                    CheckedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LeaderComment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaderChecked", x => new { x.StudentReportsID, x.WebAppUserID });
                    table.ForeignKey(
                        name: "FK_LeaderChecked_AspNetUsers_WebAppUserID",
                        column: x => x.WebAppUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaderChecked_StudentReports_StudentReportsID",
                        column: x => x.StudentReportsID,
                        principalTable: "StudentReports",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaderChecked_WebAppUserID",
                table: "LeaderChecked",
                column: "WebAppUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaderChecked");
        }
    }
}
