using Microsoft.EntityFrameworkCore.Migrations;

namespace Quokka_App.Migrations
{
    public partial class FixEmotionPrimaryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentReports_AspNetUsers_SRWebAppUserId",
                table: "StudentReports");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentReports_Emotion_Feeling",
                table: "StudentReports");

            migrationBuilder.DropIndex(
                name: "IX_StudentReports_Feeling",
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

            migrationBuilder.AlterColumn<string>(
                name: "Feeling",
                table: "StudentReports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EmotionID",
                table: "StudentReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StudentID",
                table: "LeaderAssignedReport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    AssignmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WellbeingLeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Student = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => x.AssignmentID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentReports_EmotionID",
                table: "StudentReports",
                column: "EmotionID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_StudentReports_Emotion_EmotionID",
                table: "StudentReports",
                column: "EmotionID",
                principalTable: "Emotion",
                principalColumn: "EmotionID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentReports_AspNetUsers_UserID",
                table: "StudentReports");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentReports_Emotion_EmotionID",
                table: "StudentReports");

            migrationBuilder.DropTable(
                name: "Assignment");

            migrationBuilder.DropIndex(
                name: "IX_StudentReports_EmotionID",
                table: "StudentReports");

            migrationBuilder.DropIndex(
                name: "IX_StudentReports_UserID",
                table: "StudentReports");

            migrationBuilder.DropColumn(
                name: "EmotionID",
                table: "StudentReports");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "LeaderAssignedReport");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "StudentReports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Feeling",
                table: "StudentReports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SRWebAppUserId",
                table: "StudentReports",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentReports_Feeling",
                table: "StudentReports",
                column: "Feeling");

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

            migrationBuilder.AddForeignKey(
                name: "FK_StudentReports_Emotion_Feeling",
                table: "StudentReports",
                column: "Feeling",
                principalTable: "Emotion",
                principalColumn: "EmotionID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
