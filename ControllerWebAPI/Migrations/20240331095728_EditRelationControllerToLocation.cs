using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControllerWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class EditRelationControllerToLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControllerLocationHistory_Controllers_ControllerId",
                table: "ControllerLocationHistory");

            migrationBuilder.DropIndex(
                name: "IX_ControllerLocationHistory_ControllerId",
                table: "ControllerLocationHistory");

            migrationBuilder.DropColumn(
                name: "ControllerId",
                table: "ControllerLocationHistory");

            migrationBuilder.AddColumn<int>(
                name: "ControllerLocationId",
                table: "Controllers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Controllers_ControllerLocationId",
                table: "Controllers",
                column: "ControllerLocationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Controllers_ControllerLocations_ControllerLocationId",
                table: "Controllers",
                column: "ControllerLocationId",
                principalTable: "ControllerLocations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Controllers_ControllerLocations_ControllerLocationId",
                table: "Controllers");

            migrationBuilder.DropIndex(
                name: "IX_Controllers_ControllerLocationId",
                table: "Controllers");

            migrationBuilder.DropColumn(
                name: "ControllerLocationId",
                table: "Controllers");

            migrationBuilder.AddColumn<int>(
                name: "ControllerId",
                table: "ControllerLocationHistory",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ControllerLocationHistory_ControllerId",
                table: "ControllerLocationHistory",
                column: "ControllerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ControllerLocationHistory_Controllers_ControllerId",
                table: "ControllerLocationHistory",
                column: "ControllerId",
                principalTable: "Controllers",
                principalColumn: "Id");
        }
    }
}
