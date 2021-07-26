using Microsoft.EntityFrameworkCore.Migrations;

namespace Quokka_App.Migrations
{
    public partial class Fixingmanytomanyrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaderChecked_AspNetUsers_WebAppUserID",
                table: "LeaderChecked");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaderChecked",
                table: "LeaderChecked");

            migrationBuilder.AlterColumn<string>(
                name: "WebAppUserID",
                table: "LeaderChecked",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaderChecked",
                table: "LeaderChecked",
                columns: new[] { "StudentReportsID", "WebAppUserID" });

            migrationBuilder.AddForeignKey(
                name: "FK_LeaderChecked_AspNetUsers_WebAppUserID",
                table: "LeaderChecked",
                column: "WebAppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaderChecked_AspNetUsers_WebAppUserID",
                table: "LeaderChecked");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaderChecked",
                table: "LeaderChecked");

            migrationBuilder.AlterColumn<string>(
                name: "WebAppUserID",
                table: "LeaderChecked",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaderChecked",
                table: "LeaderChecked",
                column: "StudentReportsID");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaderChecked_AspNetUsers_WebAppUserID",
                table: "LeaderChecked",
                column: "WebAppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
