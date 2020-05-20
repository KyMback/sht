using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHT.Database.EF.Migrations.Migrations
{
    public partial class AddTablesAndColumnsForFutureFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KeyWords",
                schema: "sht",
                table: "TestSessionVariantFreeTextQuestion",
                type: "character varying(4000)",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRequired",
                schema: "sht",
                table: "TestSessionVariantChoiceQuestionOption",
                type: "boolean",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "sht",
                table: "StudentTestSessionQuestion",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                schema: "sht",
                table: "StudentQuestionAnswer",
                type: "timestamp without time zone",
                nullable: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "sht",
                table: "QuestionTemplate",
                type: "timestamp without time zone",
                nullable: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsShareable",
                schema: "sht",
                table: "QuestionTemplate",
                type: "boolean",
                nullable: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                schema: "sht",
                table: "QuestionTemplate",
                type: "timestamp without time zone",
                nullable: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRequired",
                schema: "sht",
                table: "ChoiceQuestionTemplateOption",
                type: "boolean",
                nullable: false);

            migrationBuilder.AddColumn<bool>(
                name: "VerifyImmediately",
                schema: "sht",
                table: "Assessment",
                type: "boolean",
                nullable: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActivatedAt",
                schema: "sht",
                table: "Account",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "sht",
                table: "Account",
                type: "timestamp without time zone",
                nullable: false);

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationId",
                schema: "sht",
                table: "Account",
                type: "uuid",
                nullable: false);

            migrationBuilder.CreateTable(
                name: "Organization",
                schema: "sht",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                schema: "sht",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionTemplate_Tag",
                schema: "sht",
                columns: table => new
                {
                    QuestionTemplateId = table.Column<Guid>(type: "uuid", nullable: false),
                    TagId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTemplate_Tag", x => new { x.TagId, x.QuestionTemplateId });
                    table.ForeignKey(
                        name: "FK_QuestionTemplate_Tag_QuestionTemplate_QuestionTemplateId",
                        column: x => x.QuestionTemplateId,
                        principalSchema: "sht",
                        principalTable: "QuestionTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionTemplate_Tag_Tag_TagId",
                        column: x => x.TagId,
                        principalSchema: "sht",
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_OrganizationId",
                schema: "sht",
                table: "Account",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_Name",
                schema: "sht",
                table: "Organization",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTemplate_Tag_QuestionTemplateId",
                schema: "sht",
                table: "QuestionTemplate_Tag",
                column: "QuestionTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Organization_OrganizationId",
                schema: "sht",
                table: "Account",
                column: "OrganizationId",
                principalSchema: "sht",
                principalTable: "Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
