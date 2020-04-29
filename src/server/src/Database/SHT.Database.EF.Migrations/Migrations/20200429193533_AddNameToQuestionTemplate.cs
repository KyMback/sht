using Microsoft.EntityFrameworkCore.Migrations;
using SHT.Database.EF.Migrations.Extensions;

namespace SHT.Database.EF.Migrations.Migrations
{
    public partial class AddNameToQuestionTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumnWithDefaultValue<string>(
                name: "Name",
                table: "QuestionTemplate",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "Name");
        }
    }
}
