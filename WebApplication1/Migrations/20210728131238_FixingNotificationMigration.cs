using Microsoft.EntityFrameworkCore.Migrations;

namespace Quokka_App.Migrations
{
    public partial class FixingNotificationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentReports_AspNetUsers_UserID",
                table: "StudentReports");

            migrationBuilder.DropIndex(
                name: "IX_StudentReports_UserID",
                table: "StudentReports");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "StudentReports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SRWebAppUserId",
                table: "StudentReports",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentReports_SRWebAppUserId",
                table: "StudentReports",
                column: "SRWebAppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentReports_AspNetUsers_SRWebAppUserId",
                table: "StudentReports",
                column: "SRWebAppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentReports_AspNetUsers_SRWebAppUserId",
                table: "StudentReports");

            migrationBuilder.DropIndex(
                name: "IX_StudentReports_SRWebAppUserId",
                table: "StudentReports");

            migrationBuilder.DropColumn(
                name: "SRWebAppUserId",
                table: "StudentReports");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "StudentReports",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
