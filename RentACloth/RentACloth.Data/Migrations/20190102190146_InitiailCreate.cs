using Microsoft.EntityFrameworkCore.Migrations;

namespace RentACloth.Data.Migrations
{
    public partial class InitiailCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildCategories_Products_ProductId",
                table: "ChildCategories");

            migrationBuilder.DropIndex(
                name: "IX_ChildCategories_ProductId",
                table: "ChildCategories");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ChildCategories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ChildCategories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ChildCategories_ProductId",
                table: "ChildCategories",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildCategories_Products_ProductId",
                table: "ChildCategories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
