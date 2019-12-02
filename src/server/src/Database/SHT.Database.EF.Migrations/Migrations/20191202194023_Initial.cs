using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SHT.Database.EF.Migrations.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    Password = table.Column<string>(maxLength: 255, nullable: false),
                    UserType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestVariant",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestVariant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructor_Account_Id",
                        column: x => x.Id,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Group = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Account_Id",
                        column: x => x.Id,
                        principalTable: "Account",
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
                name: "TestSession",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    InstructorId = table.Column<Guid>(nullable: false),
                    State = table.Column<string>(maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestSession_Instructor_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentTestSession",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: false),
                    TestSessionId = table.Column<Guid>(nullable: false),
                    State = table.Column<string>(maxLength: 255, nullable: false),
                    TestNumber = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTestSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentTestSession_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
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
                    Answer = table.Column<string>(maxLength: 4000, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Grade = table.Column<double>(nullable: true),
                    State = table.Column<string>(maxLength: 255, nullable: false),
                    StudentTestSessionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentQuestion_StudentTestSession_StudentTestSessionId",
                        column: x => x.StudentTestSessionId,
                        principalTable: "StudentTestSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_Email",
                table: "Account",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_TestVariantId",
                table: "Question",
                column: "TestVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuestion_StudentTestSessionId",
                table: "StudentQuestion",
                column: "StudentTestSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTestSession_StudentId",
                table: "StudentTestSession",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTestSession_TestSessionId",
                table: "StudentTestSession",
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
                name: "TestSessionTestVariant");

            migrationBuilder.DropTable(
                name: "StudentTestSession");

            migrationBuilder.DropTable(
                name: "TestVariant");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "TestSession");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
