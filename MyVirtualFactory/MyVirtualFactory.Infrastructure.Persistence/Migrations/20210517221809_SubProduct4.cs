using Microsoft.EntityFrameworkCore.Migrations;

namespace MyVirtualFactory.Infrastructure.Persistence.Migrations
{
    public partial class SubProduct4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmountOfProduct",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountOfProduct",
                table: "Products");
        }
    }
}
