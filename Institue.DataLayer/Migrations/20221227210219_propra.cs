using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Institue.DataLayer.Migrations
{
    public partial class propra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LessonPractice",
                columns: table => new
                {
                    LessonPracticeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonDetailId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    LessonPracticeFile = table.Column<string>(nullable: true),
                    LessonPracticeDescription = table.Column<string>(nullable: true),
                    UploadDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonPractice", x => x.LessonPracticeId);
                    table.ForeignKey(
                        name: "FK_LessonPractice_LessonDetails_LessonDetailId",
                        column: x => x.LessonDetailId,
                        principalTable: "LessonDetails",
                        principalColumn: "LessonDetailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LessonProject",
                columns: table => new
                {
                    LessonProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonDetailId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    LessonProjectFile = table.Column<string>(nullable: true),
                    LessonProjectDescription = table.Column<string>(nullable: true),
                    UploadDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonProject", x => x.LessonProjectId);
                    table.ForeignKey(
                        name: "FK_LessonProject_LessonDetails_LessonDetailId",
                        column: x => x.LessonDetailId,
                        principalTable: "LessonDetails",
                        principalColumn: "LessonDetailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessonPractice_LessonDetailId",
                table: "LessonPractice",
                column: "LessonDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonProject_LessonDetailId",
                table: "LessonProject",
                column: "LessonDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonPractice");

            migrationBuilder.DropTable(
                name: "LessonProject");
        }
    }
}
