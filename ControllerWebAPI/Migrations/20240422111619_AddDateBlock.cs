using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControllerWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDateBlock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateBlock",
                table: "Workers",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateBlock",
                table: "Workers");
        }
    }
}
