using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHT.Database.EF.Migrations.Migrations
{
    public partial class AddStudentTestDuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "StudentTestDuration",
                schema: "sht",
                table: "TestSession",
                type: "interval",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ShouldEndAt",
                schema: "sht",
                table: "StudentTestSession",
                type: "timestamp without time zone",
                nullable: true);
        }
    }
}
