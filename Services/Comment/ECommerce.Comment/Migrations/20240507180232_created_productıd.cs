using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Comment.Migrations
{
    public partial class created_productıd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "userComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "userComments");
        }
    }
}
