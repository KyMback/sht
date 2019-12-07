using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHT.Database.EF.Migrations.Migrations
{
    public partial class AddNameToTestSessionTestVariant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TestSessionTestVariant",
                maxLength: 255,
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_TestSessionTestVariant_Name_TestSessionId",
                table: "TestSessionTestVariant",
                columns: new[] { "Name", "TestSessionId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            throw new NotSupportedException();
        }
    }
}
