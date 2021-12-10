using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations.Migrations
{
    public partial class UserProductUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shop_Categories_CategoriesId",
                table: "Shop");

            migrationBuilder.DropForeignKey(
                name: "FK_Shop_Products_ProductsId",
                table: "Shop");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shop",
                table: "Shop");

            migrationBuilder.RenameTable(
                name: "Shop",
                newName: "ProductCategory");

            migrationBuilder.RenameIndex(
                name: "IX_Shop_ProductsId",
                table: "ProductCategory",
                newName: "IX_ProductCategory_ProductsId");

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Into",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory",
                columns: new[] { "CategoriesId", "ProductsId" });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdcutUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdcutUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdcutUser_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdcutUser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdcutUser_ProductId",
                table: "ProdcutUser",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdcutUser_UserId",
                table: "ProdcutUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategory_Categories_CategoriesId",
                table: "ProductCategory",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategory_Products_ProductsId",
                table: "ProductCategory",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_Categories_CategoriesId",
                table: "ProductCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_Products_ProductsId",
                table: "ProductCategory");

            migrationBuilder.DropTable(
                name: "ProdcutUser");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory");

            migrationBuilder.RenameTable(
                name: "ProductCategory",
                newName: "Shop");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategory_ProductsId",
                table: "Shop",
                newName: "IX_Shop_ProductsId");

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "Into");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shop",
                table: "Shop",
                columns: new[] { "CategoriesId", "ProductsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Shop_Categories_CategoriesId",
                table: "Shop",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shop_Products_ProductsId",
                table: "Shop",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
