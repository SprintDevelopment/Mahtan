﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mahtan.Migrations
{
    /// <inheritdoc />
    public partial class AddOptionalCodeToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OptionalCode",
                table: "Products",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OptionalCode",
                table: "Products");
        }
    }
}
