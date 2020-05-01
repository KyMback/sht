using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHT.Database.EF.Migrations.Migrations
{
    public partial class AddChoiceQuestionTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChoiceQuestionTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionText = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false),
                    QuestionTemplateId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChoiceQuestionTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChoiceQuestionTemplate_QuestionTemplate_QuestionTemplateId",
                        column: x => x.QuestionTemplateId,
                        principalTable: "QuestionTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChoiceQuestionTemplateOption",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ChoiceQuestionTemplateId = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChoiceQuestionTemplateOption", x => new { x.ChoiceQuestionTemplateId, x.Id });
                    table.ForeignKey(
                        name: "FK_ChoiceQuestionTemplateOption_ChoiceQuestionTemplate_ChoiceQ~",
                        column: x => x.ChoiceQuestionTemplateId,
                        principalTable: "ChoiceQuestionTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChoiceQuestionTemplate_QuestionTemplateId",
                table: "ChoiceQuestionTemplate",
                column: "QuestionTemplateId",
                unique: true);
        }
    }
}
