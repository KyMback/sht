using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHT.Database.EF.Migrations.Migrations
{
    public partial class ReworkTestSessionStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestSessionTestVariant");

            migrationBuilder.AddColumn<Guid>(
                name: "SourceTestVariantId",
                table: "StudentTestSession",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TestSessionVariant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    TestSessionId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsRandomOrder = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestSessionVariant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestSessionVariant_TestSession_TestSessionId",
                        column: x => x.TestSessionId,
                        principalTable: "TestSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestSessionVariantQuestion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    TestSessionVariantId = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceQuestionId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestSessionVariantQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestSessionVariantQuestion_QuestionTemplate_SourceQuestionId",
                        column: x => x.SourceQuestionId,
                        principalTable: "QuestionTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TestSessionVariantQuestion_TestSessionVariant_TestSessionVa~",
                        column: x => x.TestSessionVariantId,
                        principalTable: "TestSessionVariant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestSessionVariantChoiceQuestion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionText = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestSessionVariantChoiceQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestSessionVariantChoiceQuestion_TestSessionVariantQuestion~",
                        column: x => x.Id,
                        principalTable: "TestSessionVariantQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestSessionVariantFreeTextQuestion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QuestionText = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestSessionVariantFreeTextQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestSessionVariantFreeTextQuestion_TestSessionVariantQuesti~",
                        column: x => x.Id,
                        principalTable: "TestSessionVariantQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestSessionVariantChoiceQuestionOption",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false),
                    QuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestSessionVariantChoiceQuestionOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestSessionVariantChoiceQuestionOption_TestSessionVariantCh~",
                        column: x => x.QuestionId,
                        principalTable: "TestSessionVariantChoiceQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentTestSession_SourceTestVariantId",
                table: "StudentTestSession",
                column: "SourceTestVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_TestSessionVariant_Name_TestSessionId",
                table: "TestSessionVariant",
                columns: new[] { "Name", "TestSessionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestSessionVariant_TestSessionId",
                table: "TestSessionVariant",
                column: "TestSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_TestSessionVariantChoiceQuestionOption_QuestionId",
                table: "TestSessionVariantChoiceQuestionOption",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TestSessionVariantQuestion_SourceQuestionId",
                table: "TestSessionVariantQuestion",
                column: "SourceQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TestSessionVariantQuestion_TestSessionVariantId",
                table: "TestSessionVariantQuestion",
                column: "TestSessionVariantId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTestSession_TestSessionVariant_SourceTestVariantId",
                table: "StudentTestSession",
                column: "SourceTestVariantId",
                principalTable: "TestSessionVariant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
