using Microsoft.EntityFrameworkCore.Migrations;

namespace Quokka_App.Migrations
{
    public partial class AddManytomanyrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaderChecked_AspNetUsers_Id",
                table: "LeaderChecked");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaderChecked_StudentReports_ReportID",
                table: "LeaderChecked");

            migrationBuilder.DropIndex(
                name: "IX_LeaderChecked_ReportID",
                table: "LeaderChecked");

            migrationBuilder.DropColumn(
                name: "ReportID",
                table: "LeaderChecked");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LeaderChecked",
                newName: "WebAppUserID");

            migrationBuilder.RenameIndex(
                name: "IX_LeaderChecked_Id",
                table: "LeaderChecked",
                newName: "IX_LeaderChecked_WebAppUserID");

            migrationBuilder.AddColumn<int>(
                name: "StudentReportsID",
                table: "LeaderChecked",
                type: "int",
                nullable: false,
                defaultValue: 0);

            //migrationBuilder.AlterColumn<string>(
            //    name: "Name",
            //    table: "AspNetUserTokens",
            //    type: "nvarchar(128)",
            //    maxLength: 128,
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(450)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "LoginProvider",
            //    table: "AspNetUserTokens",
            //    type: "nvarchar(128)",
            //    maxLength: 128,
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(450)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ProviderKey",
            //    table: "AspNetUserLogins",
            //    type: "nvarchar(128)",
            //    maxLength: 128,
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(450)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "LoginProvider",
            //    table: "AspNetUserLogins",
            //    type: "nvarchar(128)",
            //    maxLength: 128,
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(450)");

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

            migrationBuilder.AddForeignKey(
                name: "FK_LeaderChecked_StudentReports_StudentReportsID",
                table: "LeaderChecked",
                column: "StudentReportsID",
                principalTable: "StudentReports",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaderChecked_AspNetUsers_WebAppUserID",
                table: "LeaderChecked");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaderChecked_StudentReports_StudentReportsID",
                table: "LeaderChecked");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaderChecked",
                table: "LeaderChecked");

            migrationBuilder.DropColumn(
                name: "StudentReportsID",
                table: "LeaderChecked");

            migrationBuilder.RenameColumn(
                name: "WebAppUserID",
                table: "LeaderChecked",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_LeaderChecked_WebAppUserID",
                table: "LeaderChecked",
                newName: "IX_LeaderChecked_Id");

            migrationBuilder.AddColumn<int>(
                name: "ReportID",
                table: "LeaderChecked",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateIndex(
                name: "IX_LeaderChecked_ReportID",
                table: "LeaderChecked",
                column: "ReportID");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaderChecked_AspNetUsers_Id",
                table: "LeaderChecked",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaderChecked_StudentReports_ReportID",
                table: "LeaderChecked",
                column: "ReportID",
                principalTable: "StudentReports",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
