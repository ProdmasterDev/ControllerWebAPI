using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ControllerWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddControllerLocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accesses_AccessPoints_AccessPointId",
                table: "Accesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Workers_WorkerId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Controllers_ControllerId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupAccesses_AccessPoints_AccessPointId",
                table: "GroupAccesses");

            migrationBuilder.DropTable(
                name: "AccessPoints");

            migrationBuilder.RenameColumn(
                name: "AccessPointId",
                table: "GroupAccesses",
                newName: "ControllerLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupAccesses_AccessPointId",
                table: "GroupAccesses",
                newName: "IX_GroupAccesses_ControllerLocationId");

            migrationBuilder.RenameColumn(
                name: "AccessPointId",
                table: "Accesses",
                newName: "ControllerLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Accesses_AccessPointId",
                table: "Accesses",
                newName: "IX_Accesses_ControllerLocationId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateBlock",
                table: "QuickAccess",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enterance",
                table: "GroupAccesses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Exit",
                table: "GroupAccesses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "ControllerId",
                table: "Events",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "ControllerLocationId",
                table: "Events",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "WorkerId",
                table: "Cards",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateBlock",
                table: "Accesses",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ControllerLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControllerLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ControllerLocationHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReaderEnId = table.Column<int>(type: "integer", nullable: false),
                    ReaderExId = table.Column<int>(type: "integer", nullable: false),
                    LocationId = table.Column<int>(type: "integer", nullable: false),
                    DateBegin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ControllerLocationId = table.Column<int>(type: "integer", nullable: true),
                    ControllerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControllerLocationHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControllerLocationHistory_ControllerLocations_ControllerLoc~",
                        column: x => x.ControllerLocationId,
                        principalTable: "ControllerLocations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ControllerLocationHistory_Controllers_ControllerId",
                        column: x => x.ControllerId,
                        principalTable: "Controllers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ControllerLocationHistory_Readers_ReaderEnId",
                        column: x => x.ReaderEnId,
                        principalTable: "Readers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ControllerLocationHistory_Readers_ReaderExId",
                        column: x => x.ReaderExId,
                        principalTable: "Readers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_ControllerLocationId",
                table: "Events",
                column: "ControllerLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ControllerLocationHistory_ControllerId",
                table: "ControllerLocationHistory",
                column: "ControllerId");

            migrationBuilder.CreateIndex(
                name: "IX_ControllerLocationHistory_ControllerLocationId",
                table: "ControllerLocationHistory",
                column: "ControllerLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ControllerLocationHistory_ReaderEnId",
                table: "ControllerLocationHistory",
                column: "ReaderEnId");

            migrationBuilder.CreateIndex(
                name: "IX_ControllerLocationHistory_ReaderExId",
                table: "ControllerLocationHistory",
                column: "ReaderExId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accesses_ControllerLocations_ControllerLocationId",
                table: "Accesses",
                column: "ControllerLocationId",
                principalTable: "ControllerLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Workers_WorkerId",
                table: "Cards",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_ControllerLocations_ControllerLocationId",
                table: "Events",
                column: "ControllerLocationId",
                principalTable: "ControllerLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Controllers_ControllerId",
                table: "Events",
                column: "ControllerId",
                principalTable: "Controllers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupAccesses_ControllerLocations_ControllerLocationId",
                table: "GroupAccesses",
                column: "ControllerLocationId",
                principalTable: "ControllerLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accesses_ControllerLocations_ControllerLocationId",
                table: "Accesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Workers_WorkerId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_ControllerLocations_ControllerLocationId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Controllers_ControllerId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupAccesses_ControllerLocations_ControllerLocationId",
                table: "GroupAccesses");

            migrationBuilder.DropTable(
                name: "ControllerLocationHistory");

            migrationBuilder.DropTable(
                name: "ControllerLocations");

            migrationBuilder.DropIndex(
                name: "IX_Events_ControllerLocationId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "DateBlock",
                table: "QuickAccess");

            migrationBuilder.DropColumn(
                name: "Enterance",
                table: "GroupAccesses");

            migrationBuilder.DropColumn(
                name: "Exit",
                table: "GroupAccesses");

            migrationBuilder.DropColumn(
                name: "ControllerLocationId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "DateBlock",
                table: "Accesses");

            migrationBuilder.RenameColumn(
                name: "ControllerLocationId",
                table: "GroupAccesses",
                newName: "AccessPointId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupAccesses_ControllerLocationId",
                table: "GroupAccesses",
                newName: "IX_GroupAccesses_AccessPointId");

            migrationBuilder.RenameColumn(
                name: "ControllerLocationId",
                table: "Accesses",
                newName: "AccessPointId");

            migrationBuilder.RenameIndex(
                name: "IX_Accesses_ControllerLocationId",
                table: "Accesses",
                newName: "IX_Accesses_AccessPointId");

            migrationBuilder.AlterColumn<int>(
                name: "ControllerId",
                table: "Events",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WorkerId",
                table: "Cards",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AccessPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReaderId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessPoints_Readers_ReaderId",
                        column: x => x.ReaderId,
                        principalTable: "Readers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessPoints_ReaderId",
                table: "AccessPoints",
                column: "ReaderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Accesses_AccessPoints_AccessPointId",
                table: "Accesses",
                column: "AccessPointId",
                principalTable: "AccessPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Workers_WorkerId",
                table: "Cards",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Controllers_ControllerId",
                table: "Events",
                column: "ControllerId",
                principalTable: "Controllers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupAccesses_AccessPoints_AccessPointId",
                table: "GroupAccesses",
                column: "AccessPointId",
                principalTable: "AccessPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
