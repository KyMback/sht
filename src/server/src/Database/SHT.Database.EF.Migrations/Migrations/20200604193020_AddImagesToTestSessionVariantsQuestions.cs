using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHT.Database.EF.Migrations.Migrations
{
    public partial class AddImagesToTestSessionVariantsQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionTemplateImage_QuestionTemplate_QuestionTemplateId",
                schema: "sht",
                table: "QuestionTemplateImage");

            migrationBuilder.CreateTable(
                name: "TestSessionVariantQuestionImage",
                schema: "sht",
                columns: table => new
                {
                    TestSessionVariantQuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestSessionVariantQuestionImage", x => new { x.FileId, x.TestSessionVariantQuestionId });
                    table.ForeignKey(
                        name: "FK_TestSessionVariantQuestionImage_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "sht",
                        principalTable: "File",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestSessionVariantQuestionImage_TestSessionVariantQuestion_~",
                        column: x => x.TestSessionVariantQuestionId,
                        principalSchema: "sht",
                        principalTable: "TestSessionVariantQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestSessionVariantQuestionImage_TestSessionVariantQuestionId",
                schema: "sht",
                table: "TestSessionVariantQuestionImage",
                column: "TestSessionVariantQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionTemplateImage_QuestionTemplate_QuestionTemplateId",
                schema: "sht",
                table: "QuestionTemplateImage",
                column: "QuestionTemplateId",
                principalSchema: "sht",
                principalTable: "QuestionTemplate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
