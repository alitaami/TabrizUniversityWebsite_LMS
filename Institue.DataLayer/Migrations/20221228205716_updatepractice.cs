using Microsoft.EntityFrameworkCore.Migrations;

namespace Institue.DataLayer.Migrations
{
    public partial class updatepractice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "LessonPractice",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "LessonPractice");
        }
    }
}
