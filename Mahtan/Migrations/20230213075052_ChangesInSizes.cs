using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mahtan.Migrations
{
    /// <inheritdoc />
    public partial class ChangesInSizes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Sizes",
                table: "Products",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<short>(
                name: "ProductSizeId",
                table: "Categories",
                type: "smallint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductSizes",
                columns: table => new
                {
                    ProductSizeId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSizes", x => x.ProductSizeId);
                });

            migrationBuilder.CreateTable(
                name: "ProductSizeItems",
                columns: table => new
                {
                    ProductSizeItemId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductSizeId = table.Column<short>(type: "smallint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    DisplayOrder = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSizeItems", x => x.ProductSizeItemId);
                    table.ForeignKey(
                        name: "FK_ProductSizeItems_ProductSizes_ProductSizeId",
                        column: x => x.ProductSizeId,
                        principalTable: "ProductSizes",
                        principalColumn: "ProductSizeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ProductSizeId",
                table: "Categories",
                column: "ProductSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizeItems_ProductSizeId",
                table: "ProductSizeItems",
                column: "ProductSizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_ProductSizes_ProductSizeId",
                table: "Categories",
                column: "ProductSizeId",
                principalTable: "ProductSizes",
                principalColumn: "ProductSizeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_ProductSizes_ProductSizeId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "ProductSizeItems");

            migrationBuilder.DropTable(
                name: "ProductSizes");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ProductSizeId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ProductSizeId",
                table: "Categories");

            migrationBuilder.AlterColumn<int>(
                name: "Sizes",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
