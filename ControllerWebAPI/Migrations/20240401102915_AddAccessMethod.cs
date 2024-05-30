using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ControllerWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddAccessMethod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccessMethodId",
                table: "Workers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Workers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccessGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccessMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccessGroupAccess",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ControllerLocationId = table.Column<int>(type: "integer", nullable: false),
                    AccessGroupId = table.Column<int>(type: "integer", nullable: false),
                    Enterance = table.Column<bool>(type: "boolean", nullable: false),
                    Exit = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessGroupAccess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessGroupAccess_AccessGroup_AccessGroupId",
                        column: x => x.AccessGroupId,
                        principalTable: "AccessGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessGroupAccess_ControllerLocations_ControllerLocationId",
                        column: x => x.ControllerLocationId,
                        principalTable: "ControllerLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workers_AccessMethodId",
                table: "Workers",
                column: "AccessMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_GroupId",
                table: "Workers",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessGroupAccess_AccessGroupId",
                table: "AccessGroupAccess",
                column: "AccessGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessGroupAccess_ControllerLocationId",
                table: "AccessGroupAccess",
                column: "ControllerLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_AccessMethods_AccessMethodId",
                table: "Workers",
                column: "AccessMethodId",
                principalTable: "AccessMethods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_WorkerGroups_GroupId",
                table: "Workers",
                column: "GroupId",
                principalTable: "WorkerGroups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_AccessMethods_AccessMethodId",
                table: "Workers");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_WorkerGroups_GroupId",
                table: "Workers");

            migrationBuilder.DropTable(
                name: "AccessGroupAccess");

            migrationBuilder.DropTable(
                name: "AccessMethods");

            migrationBuilder.DropTable(
                name: "AccessGroup");

            migrationBuilder.DropIndex(
                name: "IX_Workers_AccessMethodId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_GroupId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "AccessMethodId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Workers");
        }
    }
}
