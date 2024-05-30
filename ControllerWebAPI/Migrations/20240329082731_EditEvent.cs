using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControllerWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class EditEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Cards_CardId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_CardId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "Card",
                table: "Events",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "WorkerId",
                table: "Events",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_WorkerId",
                table: "Events",
                column: "WorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Workers_WorkerId",
                table: "Events",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Workers_WorkerId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_WorkerId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Card",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "WorkerId",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "Events",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Events_CardId",
                table: "Events",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Cards_CardId",
                table: "Events",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
