using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mahtan.Migrations
{
    /// <inheritdoc />
    public partial class AddRegisterDateTimeToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RegisterDateTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegisterDateTime",
                table: "AspNetUsers");
        }
    }
}
