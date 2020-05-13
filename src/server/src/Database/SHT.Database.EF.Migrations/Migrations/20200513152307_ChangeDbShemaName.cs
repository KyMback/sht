using Microsoft.EntityFrameworkCore.Migrations;

namespace SHT.Database.EF.Migrations.Migrations
{
    public partial class ChangeDbShemaName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sht");

            migrationBuilder.RenameTable(
                name: "TestVariantQuestion",
                newName: "TestVariantQuestion",
                newSchema: "sht");

            migrationBuilder.RenameTable(
                name: "TestVariant",
                newName: "TestVariant",
                newSchema: "sht");

            migrationBuilder.RenameTable(
                name: "TestSessionVariantQuestion",
                newName: "TestSessionVariantQuestion",
                newSchema: "sht");

            migrationBuilder.RenameTable(
                name: "TestSessionVariantFreeTextQuestion",
                newName: "TestSessionVariantFreeTextQuestion",
                newSchema: "sht");

            migrationBuilder.RenameTable(
                name: "TestSessionVariantChoiceQuestionOption",
                newName: "TestSessionVariantChoiceQuestionOption",
                newSchema: "sht");

            migrationBuilder.RenameTable(
                name: "TestSessionVariantChoiceQuestion",
                newName: "TestSessionVariantChoiceQuestion",
                newSchema: "sht");

            migrationBuilder.RenameTable(
                name: "TestSessionVariant",
                newName: "TestSessionVariant",
                newSchema: "sht");

            migrationBuilder.RenameTable(
                name: "TestSession",
                newName: "TestSession",
                newSchema: "sht");

            migrationBuilder.RenameTable(
                name: "StudentTestSessionQuestion",
                newName: "StudentTestSessionQuestion",
                newSchema: "sht");

            migrationBuilder.RenameTable(
                name: "StudentTestSession",
                newName: "StudentTestSession",
                newSchema: "sht");

            migrationBuilder.RenameTable(
                name: "StudentQuestionAnswer",
                newName: "StudentQuestionAnswer",
                newSchema: "sht");

            migrationBuilder.RenameTable(
                name: "StudentFreeTextQuestionAnswer",
                newName: "StudentFreeTextQuestionAnswer",
                newSchema: "sht");

            migrationBuilder.RenameTable(
                name: "StudentChoiceQuestionAnswer",
                newName: "StudentChoiceQuestionAnswer",
                newSchema: "sht");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Student",
                newSchema: "sht");

            migrationBuilder.RenameTable(
                name: "QuestionTemplate",
                newName: "QuestionTemplate",
                newSchema: "sht");

            migrationBuilder.RenameTable(
                name: "Instructor",
                newName: "Instructor",
                newSchema: "sht");

            migrationBuilder.RenameTable(
                name: "FreeTextQuestionTemplate",
                newName: "FreeTextQuestionTemplate",
                newSchema: "sht");

            migrationBuilder.RenameTable(
                name: "DataProtectionKeys",
                newName: "DataProtectionKeys",
                newSchema: "sht");

            migrationBuilder.RenameTable(
                name: "ChoiceQuestionTemplateOption",
                newName: "ChoiceQuestionTemplateOption",
                newSchema: "sht");

            migrationBuilder.RenameTable(
                name: "ChoiceQuestionTemplate",
                newName: "ChoiceQuestionTemplate",
                newSchema: "sht");

            migrationBuilder.RenameTable(
                name: "Account",
                newName: "Account",
                newSchema: "sht");
        }
    }
}
