using Microsoft.EntityFrameworkCore.Migrations;

namespace Quokka_App.Migrations
{
    public partial class OneToManyUserReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "StudentReports");

            migrationBuilder.DropColumn(
                name: "IsChecked",
                table: "LeaderChecked");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "StudentReports",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentReports_UserID",
                table: "StudentReports",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentReports_AspNetUsers_UserID",
                table: "StudentReports",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentReports_AspNetUsers_UserID",
                table: "StudentReports");

            migrationBuilder.DropIndex(
                name: "IX_StudentReports_UserID",
                table: "StudentReports");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "StudentReports");

            migrationBuilder.AddColumn<string>(
                name: "StudentID",
                table: "StudentReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsChecked",
                table: "LeaderChecked",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
