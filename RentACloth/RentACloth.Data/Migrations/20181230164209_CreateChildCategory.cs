using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentACloth.Data.Migrations
{
    public partial class CreateChildCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChildCategoryId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ChildCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ChildCategoryId",
                table: "Products",
                column: "ChildCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildCategories_CategoryId",
                table: "ChildCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ChildCategories_ChildCategoryId",
                table: "Products",
                column: "ChildCategoryId",
                principalTable: "ChildCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ChildCategories_ChildCategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ChildCategories");

            migrationBuilder.DropIndex(
                name: "IX_Products_ChildCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ChildCategoryId",
                table: "Products");
        }
    }
}
