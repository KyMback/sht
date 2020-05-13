using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHT.Database.EF.Migrations.Migrations
{
    public partial class ReworkStudentQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentTestSession_TestSessionVariant_SourceTestVariantId",
                table: "StudentTestSession");

            migrationBuilder.DropTable(
                name: "StudentQuestion");

            migrationBuilder.DropIndex(
                name: "IX_StudentTestSession_SourceTestVariantId",
                table: "StudentTestSession");

            migrationBuilder.DropColumn(
                name: "SourceTestVariantId",
                table: "StudentTestSession");

            migrationBuilder.DropColumn(
                name: "TestVariant",
                table: "StudentTestSession");

            migrationBuilder.AddColumn<Guid>(
                name: "TestVariantId",
                table: "StudentTestSession",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StudentTestSessionQuestion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentTestSessionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTestSessionQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentTestSessionQuestion_StudentTestSession_StudentTestSe~",
                        column: x => x.StudentTestSessionId,
                        principalTable: "StudentTestSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTestSessionQuestion_TestSessionVariantQuestion_Quest~",
                        column: x => x.QuestionId,
                        principalTable: "TestSessionVariantQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentQuestionAnswer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentQuestionAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentQuestionAnswer_StudentTestSessionQuestion_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "StudentTestSessionQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentChoiceQuestionAnswer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentQuestionAnswerId = table.Column<Guid>(type: "uuid", nullable: false),
                    OptionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentChoiceQuestionAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentChoiceQuestionAnswer_StudentQuestionAnswer_StudentQu~",
                        column: x => x.StudentQuestionAnswerId,
                        principalTable: "StudentQuestionAnswer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentChoiceQuestionAnswer_TestSessionVariantChoiceQuestio~",
                        column: x => x.OptionId,
                        principalTable: "TestSessionVariantChoiceQuestionOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentFreeTextQuestionAnswer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Answer = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentFreeTextQuestionAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentFreeTextQuestionAnswer_StudentQuestionAnswer_Id",
                        column: x => x.Id,
                        principalTable: "StudentQuestionAnswer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentTestSession_TestVariantId",
                table: "StudentTestSession",
                column: "TestVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentChoiceQuestionAnswer_OptionId_StudentQuestionAnswerId",
                table: "StudentChoiceQuestionAnswer",
                columns: new[] { "OptionId", "StudentQuestionAnswerId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentChoiceQuestionAnswer_StudentQuestionAnswerId",
                table: "StudentChoiceQuestionAnswer",
                column: "StudentQuestionAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuestionAnswer_QuestionId",
                table: "StudentQuestionAnswer",
                column: "QuestionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentTestSessionQuestion_QuestionId",
                table: "StudentTestSessionQuestion",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTestSessionQuestion_StudentTestSessionId",
                table: "StudentTestSessionQuestion",
                column: "StudentTestSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTestSession_TestSessionVariant_TestVariantId",
                table: "StudentTestSession",
                column: "TestVariantId",
                principalTable: "TestSessionVariant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
