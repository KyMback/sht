using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHT.Database.EF.Migrations.Migrations
{
    public partial class ReworkedTestVariantsInfra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_TestVariant_TestVariantId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_TestVariantId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "TestVariantId",
                table: "Question");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "TestVariant",
                nullable: false);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Question",
                nullable: false);

            migrationBuilder.CreateTable(
                name: "TestVariantQuestion",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TestVariantId = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(maxLength: 4000, nullable: false),
                    Number = table.Column<string>(maxLength: 50, nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestVariantQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestVariantQuestion_TestVariant_TestVariantId",
                        column: x => x.TestVariantId,
                        principalTable: "TestVariant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestVariant_CreatedById",
                table: "TestVariant",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Question_CreatedById",
                table: "Question",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TestVariantQuestion_TestVariantId",
                table: "TestVariantQuestion",
                column: "TestVariantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Instructor_CreatedById",
                table: "Question",
                column: "CreatedById",
                principalTable: "Instructor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestVariant_Instructor_CreatedById",
                table: "TestVariant",
                column: "CreatedById",
                principalTable: "Instructor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            throw new NotSupportedException();
        }
    }
}