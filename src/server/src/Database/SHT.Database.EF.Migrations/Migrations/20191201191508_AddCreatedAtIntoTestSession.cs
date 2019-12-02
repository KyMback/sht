using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHT.Database.EF.Migrations.Migrations
{
    public partial class AddCreatedAtIntoTestSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TestSession",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            throw new NotImplementedException();
        }
    }
}
