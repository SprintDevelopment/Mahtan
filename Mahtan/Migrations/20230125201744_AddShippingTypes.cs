using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mahtan.Migrations
{
    /// <inheritdoc />
    public partial class AddShippingTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShippingTypes",
                columns: table => new
                {
                    ShippingTypeId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    DeliveryRange = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Cost = table.Column<long>(type: "bigint", nullable: false),
                    OptionalComment = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingTypes", x => x.ShippingTypeId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShippingTypes");
        }
    }
}
