using Microsoft.EntityFrameworkCore.Migrations;

namespace MyVirtualFactory.Infrastructure.Persistence.Migrations
{
    public partial class SubProduct3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "SubProducTrees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubProductId",
                table: "SubProducTrees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SubProducTrees_ProductId",
                table: "SubProducTrees",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SubProducTrees_SubProductId",
                table: "SubProducTrees",
                column: "SubProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubProducTrees_Products_ProductId",
                table: "SubProducTrees",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubProducTrees_Products_SubProductId",
                table: "SubProducTrees",
                column: "SubProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubProducTrees_Products_ProductId",
                table: "SubProducTrees");

            migrationBuilder.DropForeignKey(
                name: "FK_SubProducTrees_Products_SubProductId",
                table: "SubProducTrees");

            migrationBuilder.DropIndex(
                name: "IX_SubProducTrees_ProductId",
                table: "SubProducTrees");

            migrationBuilder.DropIndex(
                name: "IX_SubProducTrees_SubProductId",
                table: "SubProducTrees");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "SubProducTrees");

            migrationBuilder.DropColumn(
                name: "SubProductId",
                table: "SubProducTrees");
        }
    }
}
