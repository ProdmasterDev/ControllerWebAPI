using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControllerWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationLocationToHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControllerLocationHistory_ControllerLocations_ControllerLoc~",
                table: "ControllerLocationHistory");

            migrationBuilder.DropIndex(
                name: "IX_ControllerLocationHistory_ControllerLocationId",
                table: "ControllerLocationHistory");

            migrationBuilder.DropColumn(
                name: "ControllerLocationId",
                table: "ControllerLocationHistory");

            migrationBuilder.CreateIndex(
                name: "IX_ControllerLocationHistory_LocationId",
                table: "ControllerLocationHistory",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ControllerLocationHistory_ControllerLocations_LocationId",
                table: "ControllerLocationHistory",
                column: "LocationId",
                principalTable: "ControllerLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControllerLocationHistory_ControllerLocations_LocationId",
                table: "ControllerLocationHistory");

            migrationBuilder.DropIndex(
                name: "IX_ControllerLocationHistory_LocationId",
                table: "ControllerLocationHistory");

            migrationBuilder.AddColumn<int>(
                name: "ControllerLocationId",
                table: "ControllerLocationHistory",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ControllerLocationHistory_ControllerLocationId",
                table: "ControllerLocationHistory",
                column: "ControllerLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ControllerLocationHistory_ControllerLocations_ControllerLoc~",
                table: "ControllerLocationHistory",
                column: "ControllerLocationId",
                principalTable: "ControllerLocations",
                principalColumn: "Id");
        }
    }
}
