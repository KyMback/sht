using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHT.Database.EF.Migrations.Migrations
{
    public partial class AddedTestsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestSession",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    InstructorId = table.Column<Guid>(nullable: false),
                    State = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestSession_User_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestVariant",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestVariant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentTestSession",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: false),
                    TestSessionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTestSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentTestSession_User_StudentId",
                        column: x => x.StudentId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentTestSession_TestSession_TestSessionId",
                        column: x => x.TestSessionId,
                        principalTable: "TestSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentTestVariant",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: false),
                    TestSessionId = table.Column<Guid>(nullable: false),
                    State = table.Column<string>(maxLength: 255, nullable: false),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTestVariant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentTestVariant_User_StudentId",
                        column: x => x.StudentId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentTestVariant_TestSession_TestSessionId",
                        column: x => x.TestSessionId,
                        principalTable: "TestSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(maxLength: 4000, nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    TestVariantId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_TestVariant_TestVariantId",
                        column: x => x.TestVariantId,
                        principalTable: "TestVariant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestSessionTestVariant",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TestVariantId = table.Column<Guid>(nullable: false),
                    TestSessionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestSessionTestVariant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestSessionTestVariant_TestSession_TestSessionId",
                        column: x => x.TestSessionId,
                        principalTable: "TestSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestSessionTestVariant_TestVariant_TestVariantId",
                        column: x => x.TestVariantId,
                        principalTable: "TestVariant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentQuestion",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(maxLength: 4000, nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Answer = table.Column<string>(maxLength: 4000, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Grade = table.Column<double>(nullable: false),
                    State = table.Column<string>(maxLength: 255, nullable: false),
                    StudentTestVariantId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentQuestion_StudentTestVariant_StudentTestVariantId",
                        column: x => x.StudentTestVariantId,
                        principalTable: "StudentTestVariant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Question_TestVariantId",
                table: "Question",
                column: "TestVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuestion_StudentTestVariantId",
                table: "StudentQuestion",
                column: "StudentTestVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTestSession_StudentId",
                table: "StudentTestSession",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTestSession_TestSessionId",
                table: "StudentTestSession",
                column: "TestSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTestVariant_StudentId",
                table: "StudentTestVariant",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTestVariant_TestSessionId",
                table: "StudentTestVariant",
                column: "TestSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_TestSession_InstructorId",
                table: "TestSession",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_TestSessionTestVariant_TestSessionId",
                table: "TestSessionTestVariant",
                column: "TestSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_TestSessionTestVariant_TestVariantId",
                table: "TestSessionTestVariant",
                column: "TestVariantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "StudentQuestion");

            migrationBuilder.DropTable(
                name: "StudentTestSession");

            migrationBuilder.DropTable(
                name: "TestSessionTestVariant");

            migrationBuilder.DropTable(
                name: "StudentTestVariant");

            migrationBuilder.DropTable(
                name: "TestVariant");

            migrationBuilder.DropTable(
                name: "TestSession");
        }
    }
}
