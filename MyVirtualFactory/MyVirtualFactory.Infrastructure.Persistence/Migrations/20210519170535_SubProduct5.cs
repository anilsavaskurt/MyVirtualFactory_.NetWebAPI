using Microsoft.EntityFrameworkCore.Migrations;

namespace MyVirtualFactory.Infrastructure.Persistence.Migrations
{
    public partial class SubProduct5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubProducTrees_Products_ProductId",
                table: "SubProducTrees");

            migrationBuilder.DropForeignKey(
                name: "FK_SubProducTrees_Products_SubProductId",
                table: "SubProducTrees");

            migrationBuilder.DropIndex(
                name: "IX_SubProducTrees_SubProductId",
                table: "SubProducTrees");

            migrationBuilder.AddForeignKey(
                name: "FK_SubProducTrees_Products_ProductId",
                table: "SubProducTrees",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubProducTrees_Products_ProductId",
                table: "SubProducTrees");

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
    }
}
