using Microsoft.EntityFrameworkCore.Migrations;
using SHT.Database.EF.Migrations.Extensions;

namespace SHT.Database.EF.Migrations.Migrations
{
    public partial class AddSecurityStampToAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumnWithDefaultValue<string>(
                name: "SecurityStamp",
                table: "Account",
                maxLength: 50,
                nullable: false,
                defaultValue: "204E8BFB-647D-4712-B2F6-C4A822859D45");
        }
    }
}
