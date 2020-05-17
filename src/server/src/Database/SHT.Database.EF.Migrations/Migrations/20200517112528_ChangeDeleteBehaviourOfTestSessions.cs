using Microsoft.EntityFrameworkCore.Migrations;

namespace SHT.Database.EF.Migrations.Migrations
{
    public partial class ChangeDeleteBehaviourOfTestSessions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assessment_TestSession_TestSessionId",
                schema: "sht",
                table: "Assessment");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentTestSession_TestSession_TestSessionId",
                schema: "sht",
                table: "StudentTestSession");

            migrationBuilder.DropForeignKey(
                name: "FK_TestSession_Instructor_InstructorId",
                schema: "sht",
                table: "TestSession");

            migrationBuilder.DropForeignKey(
                name: "FK_TestSessionVariantQuestion_TestSessionVariant_TestSessionVa~",
                schema: "sht",
                table: "TestSessionVariantQuestion");

            migrationBuilder.AddForeignKey(
                name: "FK_Assessment_TestSession_TestSessionId",
                schema: "sht",
                table: "Assessment",
                column: "TestSessionId",
                principalSchema: "sht",
                principalTable: "TestSession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTestSession_TestSession_TestSessionId",
                schema: "sht",
                table: "StudentTestSession",
                column: "TestSessionId",
                principalSchema: "sht",
                principalTable: "TestSession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestSession_Instructor_InstructorId",
                schema: "sht",
                table: "TestSession",
                column: "InstructorId",
                principalSchema: "sht",
                principalTable: "Instructor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestSessionVariantQuestion_TestSessionVariant_TestSessionVa~",
                schema: "sht",
                table: "TestSessionVariantQuestion",
                column: "TestSessionVariantId",
                principalSchema: "sht",
                principalTable: "TestSessionVariant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
