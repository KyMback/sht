using Microsoft.EntityFrameworkCore.Migrations;

namespace SHT.Database.EF.Migrations.Migrations
{
    public partial class ChangeAnswersRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AnswersRatingItem_AnswersRatingId_Rating",
                schema: "sht",
                table: "AnswersRatingItem");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                schema: "sht",
                table: "AnswersRatingItem",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
