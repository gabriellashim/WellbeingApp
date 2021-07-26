using Microsoft.EntityFrameworkCore.Migrations;

namespace Quokka_App.Migrations
{
    public partial class EmotionForeignKeyFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Feeling",
                table: "StudentReports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentReports_Feeling",
                table: "StudentReports",
                column: "Feeling");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentReports_Emotion_Feeling",
                table: "StudentReports",
                column: "Feeling",
                principalTable: "Emotion",
                principalColumn: "EmotionID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentReports_Emotion_Feeling",
                table: "StudentReports");

            migrationBuilder.DropIndex(
                name: "IX_StudentReports_Feeling",
                table: "StudentReports");

            migrationBuilder.AlterColumn<string>(
                name: "Feeling",
                table: "StudentReports",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
