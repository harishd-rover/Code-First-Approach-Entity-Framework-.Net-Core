using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirst_EFCore.Migrations
{
    public partial class BookageAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Book_Age",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Book_Age",
                table: "Books");
        }
    }
}
