using Microsoft.EntityFrameworkCore.Migrations;

namespace SHT.Database.EF.Migrations.Migrations
{
    public partial class AddQuestionTextForAssessmentQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAnswered",
                schema: "sht",
                table: "StudentQuestionAnswer",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "QuestionText",
                schema: "sht",
                table: "AnswersAssessmentQuestion",
                type: "character varying(4000)",
                maxLength: 4000,
                nullable: false);
        }
    }
}
