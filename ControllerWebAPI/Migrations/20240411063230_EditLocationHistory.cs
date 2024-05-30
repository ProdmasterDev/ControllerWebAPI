using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControllerWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class EditLocationHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControllerLocationHistory_Readers_ReaderEnId",
                table: "ControllerLocationHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ControllerLocationHistory_Readers_ReaderExId",
                table: "ControllerLocationHistory");

            migrationBuilder.AlterColumn<int>(
                name: "ReaderExId",
                table: "ControllerLocationHistory",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ReaderEnId",
                table: "ControllerLocationHistory",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_ControllerLocationHistory_Readers_ReaderEnId",
                table: "ControllerLocationHistory",
                column: "ReaderEnId",
                principalTable: "Readers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ControllerLocationHistory_Readers_ReaderExId",
                table: "ControllerLocationHistory",
                column: "ReaderExId",
                principalTable: "Readers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControllerLocationHistory_Readers_ReaderEnId",
                table: "ControllerLocationHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ControllerLocationHistory_Readers_ReaderExId",
                table: "ControllerLocationHistory");

            migrationBuilder.AlterColumn<int>(
                name: "ReaderExId",
                table: "ControllerLocationHistory",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReaderEnId",
                table: "ControllerLocationHistory",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ControllerLocationHistory_Readers_ReaderEnId",
                table: "ControllerLocationHistory",
                column: "ReaderEnId",
                principalTable: "Readers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ControllerLocationHistory_Readers_ReaderExId",
                table: "ControllerLocationHistory",
                column: "ReaderExId",
                principalTable: "Readers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
