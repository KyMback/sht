using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHT.Database.EF.Migrations.Migrations
{
    public partial class AddTestSessionAssessment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assessment",
                schema: "sht",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TestSessionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assessment_TestSession_TestSessionId",
                        column: x => x.TestSessionId,
                        principalSchema: "sht",
                        principalTable: "TestSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnswersAssessmentQuestion",
                schema: "sht",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AssessmentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswersAssessmentQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswersAssessmentQuestion_Assessment_AssessmentId",
                        column: x => x.AssessmentId,
                        principalSchema: "sht",
                        principalTable: "Assessment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionAnswerAssessment",
                schema: "sht",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AssessmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentQuestionAnswerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Correctness = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAnswerAssessment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionAnswerAssessment_Assessment_AssessmentId",
                        column: x => x.AssessmentId,
                        principalSchema: "sht",
                        principalTable: "Assessment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestionAnswerAssessment_StudentQuestionAnswer_StudentQuest~",
                        column: x => x.StudentQuestionAnswerId,
                        principalSchema: "sht",
                        principalTable: "StudentQuestionAnswer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnswersAssessmentQuestion_TestSessionVariantQuestion",
                schema: "sht",
                columns: table => new
                {
                    TestSessionVariantQuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    AnswersAssessmentQuestionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswersAssessmentQuestion_TestSessionVariantQuestion", x => new { x.AnswersAssessmentQuestionId, x.TestSessionVariantQuestionId });
                    table.ForeignKey(
                        name: "FK_AnswersAssessmentQuestion_TestSessionVariantQuestion_Answer~",
                        column: x => x.AnswersAssessmentQuestionId,
                        principalSchema: "sht",
                        principalTable: "AnswersAssessmentQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnswersAssessmentQuestion_TestSessionVariantQuestion_TestSe~",
                        column: x => x.TestSessionVariantQuestionId,
                        principalSchema: "sht",
                        principalTable: "TestSessionVariantQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnswersRating",
                schema: "sht",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AnswersAssessmentQuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswersRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswersRating_AnswersAssessmentQuestion_AnswersAssessmentQu~",
                        column: x => x.AnswersAssessmentQuestionId,
                        principalSchema: "sht",
                        principalTable: "AnswersAssessmentQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnswersRating_Student_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "sht",
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnswersRatingItem",
                schema: "sht",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AnswersRatingId = table.Column<Guid>(type: "uuid", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    StudentQuestionAnswerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswersRatingItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswersRatingItem_AnswersRating_AnswersRatingId",
                        column: x => x.AnswersRatingId,
                        principalSchema: "sht",
                        principalTable: "AnswersRating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnswersRatingItem_StudentQuestionAnswer_StudentQuestionAnsw~",
                        column: x => x.StudentQuestionAnswerId,
                        principalSchema: "sht",
                        principalTable: "StudentQuestionAnswer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswersAssessmentQuestion_AssessmentId",
                schema: "sht",
                table: "AnswersAssessmentQuestion",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswersAssessmentQuestion_TestSessionVariantQuestion_TestSe~",
                schema: "sht",
                table: "AnswersAssessmentQuestion_TestSessionVariantQuestion",
                column: "TestSessionVariantQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswersRating_AnswersAssessmentQuestionId",
                schema: "sht",
                table: "AnswersRating",
                column: "AnswersAssessmentQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswersRating_StudentId",
                schema: "sht",
                table: "AnswersRating",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswersRatingItem_AnswersRatingId_Rating",
                schema: "sht",
                table: "AnswersRatingItem",
                columns: new[] { "AnswersRatingId", "Rating" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnswersRatingItem_AnswersRatingId_StudentQuestionAnswerId",
                schema: "sht",
                table: "AnswersRatingItem",
                columns: new[] { "AnswersRatingId", "StudentQuestionAnswerId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnswersRatingItem_StudentQuestionAnswerId",
                schema: "sht",
                table: "AnswersRatingItem",
                column: "StudentQuestionAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessment_TestSessionId",
                schema: "sht",
                table: "Assessment",
                column: "TestSessionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswerAssessment_AssessmentId",
                schema: "sht",
                table: "QuestionAnswerAssessment",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswerAssessment_StudentQuestionAnswerId",
                schema: "sht",
                table: "QuestionAnswerAssessment",
                column: "StudentQuestionAnswerId",
                unique: true);
        }
    }
}
