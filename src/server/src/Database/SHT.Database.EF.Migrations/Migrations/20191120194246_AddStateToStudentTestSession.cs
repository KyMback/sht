using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHT.Database.EF.Migrations.Migrations
{
    public partial class AddStateToStudentTestSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuestion_StudentTestVariant_StudentTestVariantId",
                table: "StudentQuestion");

            migrationBuilder.DropTable(
                name: "StudentTestVariant");

            migrationBuilder.DropIndex(
                name: "IX_StudentQuestion_StudentTestVariantId",
                table: "StudentQuestion");

            migrationBuilder.DropColumn(
                name: "StudentTestVariantId",
                table: "StudentQuestion");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "StudentTestSession",
                maxLength: 255,
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "TestNumber",
                table: "StudentTestSession",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentTestSessionId",
                table: "StudentQuestion",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuestion_StudentTestSessionId",
                table: "StudentQuestion",
                column: "StudentTestSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentQuestion_StudentTestSession_StudentTestSessionId",
                table: "StudentQuestion",
                column: "StudentTestSessionId",
                principalTable: "StudentTestSession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            throw new NotImplementedException();
        }
    }
}
