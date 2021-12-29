using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Data.Migrations
{
    public partial class QuestionTextSpellingCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuesitonText",
                table: "Questions",
                newName: "QuestionText");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuestionText",
                table: "Questions",
                newName: "QuesitonText");
        }
    }
}
