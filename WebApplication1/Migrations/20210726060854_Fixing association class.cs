using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quokka_App.Migrations
{
    public partial class Fixingassociationclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaderChecked");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaderChecked",
                columns: table => new
                {
                    StudentReportsID = table.Column<int>(type: "int", nullable: false),
                    WebAppUserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CheckedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false)
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
    }
}
