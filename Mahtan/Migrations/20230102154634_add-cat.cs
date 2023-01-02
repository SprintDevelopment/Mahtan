using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mahtan.Migrations
{
    /// <inheritdoc />
    public partial class addcat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentCategoryId = table.Column<short>(type: "smallint", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    CountUnitTitle = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    IconGuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionalComment = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
