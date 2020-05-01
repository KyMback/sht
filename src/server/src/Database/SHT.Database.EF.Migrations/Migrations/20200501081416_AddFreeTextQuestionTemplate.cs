using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHT.Database.EF.Migrations.Migrations
{
    public partial class AddFreeTextQuestionTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "QuestionTemplate");

            migrationBuilder.CreateTable(
                name: "FreeTextQuestionTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Question = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false),
                    QuestionTemplateId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreeTextQuestionTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FreeTextQuestionTemplate_QuestionTemplate_QuestionTemplateId",
                        column: x => x.QuestionTemplateId,
                        principalTable: "QuestionTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FreeTextQuestionTemplate_QuestionTemplateId",
                table: "FreeTextQuestionTemplate",
                column: "QuestionTemplateId",
                unique: true);
        }
    }
}
