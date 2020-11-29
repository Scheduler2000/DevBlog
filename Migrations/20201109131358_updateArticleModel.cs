using Microsoft.EntityFrameworkCore.Migrations;

namespace DevBlog.Migrations
{
    public partial class updateArticleModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentUrl",
                table: "Articles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentUrl",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
