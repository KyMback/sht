using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHT.Database.EF.Migrations.Migrations
{
    public partial class AddFilesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StudentQuestionAnswerId1",
                schema: "sht",
                table: "QuestionAnswerAssessment",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "File",
                schema: "sht",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StorageType = table.Column<byte>(type: "smallint", nullable: false),
                    Reference = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ContentType = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    OriginalName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    SizeBytes = table.Column<long>(type: "bigint", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_Account_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "sht",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswerAssessment_StudentQuestionAnswerId1",
                schema: "sht",
                table: "QuestionAnswerAssessment",
                column: "StudentQuestionAnswerId1");

            migrationBuilder.CreateIndex(
                name: "IX_File_CreatedById",
                schema: "sht",
                table: "File",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_File_Reference",
                schema: "sht",
                table: "File",
                column: "Reference",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswerAssessment_StudentQuestionAnswer_StudentQues~1",
                schema: "sht",
                table: "QuestionAnswerAssessment",
                column: "StudentQuestionAnswerId1",
                principalSchema: "sht",
                principalTable: "StudentQuestionAnswer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
