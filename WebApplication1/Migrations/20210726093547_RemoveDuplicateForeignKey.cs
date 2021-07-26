using Microsoft.EntityFrameworkCore.Migrations;

namespace Quokka_App.Migrations
{
    public partial class RemoveDuplicateForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaderAssignedReport_AspNetUsers_CheckedBy",
                table: "LeaderAssignedReport");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaderAssignedReport_StudentReports_ReportChecked",
                table: "LeaderAssignedReport");

            migrationBuilder.RenameColumn(
                name: "CheckedBy",
                table: "LeaderAssignedReport",
                newName: "LeaderID");

            migrationBuilder.RenameColumn(
                name: "ReportChecked",
                table: "LeaderAssignedReport",
                newName: "ReportID");

            migrationBuilder.RenameIndex(
                name: "IX_LeaderAssignedReport_CheckedBy",
                table: "LeaderAssignedReport",
                newName: "IX_LeaderAssignedReport_LeaderID");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaderAssignedReport_AspNetUsers_LeaderID",
                table: "LeaderAssignedReport",
                column: "LeaderID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaderAssignedReport_StudentReports_ReportID",
                table: "LeaderAssignedReport",
                column: "ReportID",
                principalTable: "StudentReports",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaderAssignedReport_AspNetUsers_LeaderID",
                table: "LeaderAssignedReport");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaderAssignedReport_StudentReports_ReportID",
                table: "LeaderAssignedReport");

            migrationBuilder.RenameColumn(
                name: "LeaderID",
                table: "LeaderAssignedReport",
                newName: "CheckedBy");

            migrationBuilder.RenameColumn(
                name: "ReportID",
                table: "LeaderAssignedReport",
                newName: "ReportChecked");

            migrationBuilder.RenameIndex(
                name: "IX_LeaderAssignedReport_LeaderID",
                table: "LeaderAssignedReport",
                newName: "IX_LeaderAssignedReport_CheckedBy");

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
    }
}
