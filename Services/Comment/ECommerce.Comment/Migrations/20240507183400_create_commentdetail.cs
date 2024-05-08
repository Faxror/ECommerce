using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Comment.Migrations
{
    public partial class create_commentdetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommentDetail",
                table: "userComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentDetail",
                table: "userComments");
        }
    }
}
