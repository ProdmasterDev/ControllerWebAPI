using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ControllerWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddArch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accesses_Readers_ReaderId",
                table: "Accesses");

            migrationBuilder.DropTable(
                name: "ControllerLocationHistory");

            migrationBuilder.DropTable(
                name: "Readers");

            migrationBuilder.DropIndex(
                name: "IX_Accesses_ReaderId",
                table: "Accesses");

            migrationBuilder.DropColumn(
                name: "ReaderId",
                table: "Accesses");

            migrationBuilder.AddColumn<bool>(
                name: "Arch",
                table: "Workers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Arch",
                table: "WorkerGroups",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Arch",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Arch",
                table: "Controllers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Arch",
                table: "ControllerLocations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Arch",
                table: "Cards",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Arch",
                table: "AccessGroup",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Arch",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Arch",
                table: "WorkerGroups");

            migrationBuilder.DropColumn(
                name: "Arch",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Arch",
                table: "Controllers");

            migrationBuilder.DropColumn(
                name: "Arch",
                table: "ControllerLocations");

            migrationBuilder.DropColumn(
                name: "Arch",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Arch",
                table: "AccessGroup");

            migrationBuilder.AddColumn<int>(
                name: "ReaderId",
                table: "Accesses",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Readers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ControllerId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Readers_Controllers_ControllerId",
                        column: x => x.ControllerId,
                        principalTable: "Controllers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ControllerLocationHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LocationId = table.Column<int>(type: "integer", nullable: false),
                    ReaderEnId = table.Column<int>(type: "integer", nullable: true),
                    ReaderExId = table.Column<int>(type: "integer", nullable: true),
                    DateBegin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControllerLocationHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControllerLocationHistory_ControllerLocations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "ControllerLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ControllerLocationHistory_Readers_ReaderEnId",
                        column: x => x.ReaderEnId,
                        principalTable: "Readers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ControllerLocationHistory_Readers_ReaderExId",
                        column: x => x.ReaderExId,
                        principalTable: "Readers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accesses_ReaderId",
                table: "Accesses",
                column: "ReaderId");

            migrationBuilder.CreateIndex(
                name: "IX_ControllerLocationHistory_LocationId",
                table: "ControllerLocationHistory",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ControllerLocationHistory_ReaderEnId",
                table: "ControllerLocationHistory",
                column: "ReaderEnId");

            migrationBuilder.CreateIndex(
                name: "IX_ControllerLocationHistory_ReaderExId",
                table: "ControllerLocationHistory",
                column: "ReaderExId");

            migrationBuilder.CreateIndex(
                name: "IX_Readers_ControllerId",
                table: "Readers",
                column: "ControllerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accesses_Readers_ReaderId",
                table: "Accesses",
                column: "ReaderId",
                principalTable: "Readers",
                principalColumn: "Id");
        }
    }
}
