using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wanyar.DataLayer.Migrations
{
    public partial class firstMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleGroups",
                columns: table => new
                {
                    groupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    groupTitle = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    parentId = table.Column<int>(type: "int", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleGroups", x => x.groupId);
                    table.ForeignKey(
                        name: "FK_ArticleGroups_ArticleGroups_parentId",
                        column: x => x.parentId,
                        principalTable: "ArticleGroups",
                        principalColumn: "groupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: false),
                    email = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    activeCode = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    registeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Isdelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    articleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    SubGroup = table.Column<int>(type: "int", nullable: true),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    CourseTitle = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CourseDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    CourseImageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Visit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.articleId);
                    table.ForeignKey(
                        name: "FK_Articles_ArticleGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "ArticleGroups",
                        principalColumn: "groupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_ArticleGroups_SubGroup",
                        column: x => x.SubGroup,
                        principalTable: "ArticleGroups",
                        principalColumn: "groupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articles_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleGroups_parentId",
                table: "ArticleGroups",
                column: "parentId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_GroupId",
                table: "Articles",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_SubGroup",
                table: "Articles",
                column: "SubGroup");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_TeacherId",
                table: "Articles",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "ArticleGroups");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
