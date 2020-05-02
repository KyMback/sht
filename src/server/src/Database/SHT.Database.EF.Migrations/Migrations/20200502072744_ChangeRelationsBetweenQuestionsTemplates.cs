using Microsoft.EntityFrameworkCore.Migrations;

namespace SHT.Database.EF.Migrations.Migrations
{
    public partial class ChangeRelationsBetweenQuestionsTemplates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChoiceQuestionTemplateOption",
                table: "ChoiceQuestionTemplateOption");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChoiceQuestionTemplateOption",
                table: "ChoiceQuestionTemplateOption",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ChoiceQuestionTemplateOption_ChoiceQuestionTemplateId",
                table: "ChoiceQuestionTemplateOption",
                column: "ChoiceQuestionTemplateId");
        }
    }
}
