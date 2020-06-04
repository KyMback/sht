using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHT.Database.EF.Migrations.Migrations
{
    public partial class AddImagesToQuestionsTemplates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionTemplateImage",
                schema: "sht",
                columns: table => new
                {
                    QuestionTemplateId = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTemplateImage", x => new { x.FileId, x.QuestionTemplateId });
                    table.ForeignKey(
                        name: "FK_QuestionTemplateImage_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "sht",
                        principalTable: "File",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionTemplateImage_QuestionTemplate_QuestionTemplateId",
                        column: x => x.QuestionTemplateId,
                        principalSchema: "sht",
                        principalTable: "QuestionTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTemplateImage_QuestionTemplateId",
                schema: "sht",
                table: "QuestionTemplateImage",
                column: "QuestionTemplateId");
        }
    }
}
