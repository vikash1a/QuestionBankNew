using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Data.Migrations
{
    public partial class QuestionUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionBankId",
                table: "Questions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionBankId",
                table: "Questions",
                column: "QuestionBankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_QuestionBanks_QuestionBankId",
                table: "Questions",
                column: "QuestionBankId",
                principalTable: "QuestionBanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_QuestionBanks_QuestionBankId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_QuestionBankId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionBankId",
                table: "Questions");
        }
    }
}
