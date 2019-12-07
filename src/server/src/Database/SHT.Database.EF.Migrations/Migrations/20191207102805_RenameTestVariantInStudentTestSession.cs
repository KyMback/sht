using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHT.Database.EF.Migrations.Migrations
{
    public partial class RenameTestVariantInStudentTestSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn("TestNumber", "StudentTestSession", "TestVariant");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            throw new NotSupportedException();
        }
    }
}
