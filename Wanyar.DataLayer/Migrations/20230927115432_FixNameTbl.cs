using Microsoft.EntityFrameworkCore.Migrations;

namespace Wanyar.DataLayer.Migrations
{
    public partial class FixNameTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CourseTitle",
                table: "Articles",
                newName: "ArticleTitle");

            migrationBuilder.RenameColumn(
                name: "CourseImageName",
                table: "Articles",
                newName: "ArticleImageName");

            migrationBuilder.RenameColumn(
                name: "CourseDescription",
                table: "Articles",
                newName: "ArticleDescription");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ArticleTitle",
                table: "Articles",
                newName: "CourseTitle");

            migrationBuilder.RenameColumn(
                name: "ArticleImageName",
                table: "Articles",
                newName: "CourseImageName");

            migrationBuilder.RenameColumn(
                name: "ArticleDescription",
                table: "Articles",
                newName: "CourseDescription");
        }
    }
}
