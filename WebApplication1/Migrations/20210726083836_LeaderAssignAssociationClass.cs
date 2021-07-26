using Microsoft.EntityFrameworkCore.Migrations;

namespace Quokka_App.Migrations
{
    public partial class LeaderAssignAssociationClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaderAssignedReport_AspNetUsers_Id",
                table: "LeaderAssignedReport");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaderAssignedReport_StudentReports_ReportID",
                table: "LeaderAssignedReport");

            migrationBuilder.DropIndex(
                name: "IX_LeaderAssignedReport_Id",
                table: "LeaderAssignedReport");

            migrationBuilder.DropIndex(
                name: "IX_LeaderAssignedReport_ReportID",
                table: "LeaderAssignedReport");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "LeaderAssignedReport");

            migrationBuilder.DropColumn(
                name: "ReportID",
                table: "LeaderAssignedReport");

            migrationBuilder.AddColumn<int>(
                name: "ReportChecked",
                table: "LeaderAssignedReport",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CheckedBy",
                table: "LeaderAssignedReport",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaderAssignedReport",
                table: "LeaderAssignedReport",
                columns: new[] { "ReportChecked", "CheckedBy" });

            migrationBuilder.CreateIndex(
                name: "IX_LeaderAssignedReport_CheckedBy",
                table: "LeaderAssignedReport",
                column: "CheckedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaderAssignedReport_AspNetUsers_CheckedBy",
                table: "LeaderAssignedReport",
                column: "CheckedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaderAssignedReport_StudentReports_ReportChecked",
                table: "LeaderAssignedReport",
                column: "ReportChecked",
                principalTable: "StudentReports",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaderAssignedReport_AspNetUsers_CheckedBy",
                table: "LeaderAssignedReport");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaderAssignedReport_StudentReports_ReportChecked",
                table: "LeaderAssignedReport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaderAssignedReport",
                table: "LeaderAssignedReport");

            migrationBuilder.DropIndex(
                name: "IX_LeaderAssignedReport_CheckedBy",
                table: "LeaderAssignedReport");

            migrationBuilder.DropColumn(
                name: "ReportChecked",
                table: "LeaderAssignedReport");

            migrationBuilder.DropColumn(
                name: "CheckedBy",
                table: "LeaderAssignedReport");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "LeaderAssignedReport",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportID",
                table: "LeaderAssignedReport",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LeaderAssignedReport_Id",
                table: "LeaderAssignedReport",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_LeaderAssignedReport_ReportID",
                table: "LeaderAssignedReport",
                column: "ReportID");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaderAssignedReport_AspNetUsers_Id",
                table: "LeaderAssignedReport",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaderAssignedReport_StudentReports_ReportID",
                table: "LeaderAssignedReport",
                column: "ReportID",
                principalTable: "StudentReports",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
