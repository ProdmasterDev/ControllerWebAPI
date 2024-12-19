using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ControllerWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class WorkerGroupAccess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkerGroupAccess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkerGroupId = table.Column<int>(type: "integer", nullable: false),
                    AccessGroupId = table.Column<int>(type: "integer", nullable: false),
                    isActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerGroupAccess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkerGroupAccess_AccessGroup_AccessGroupId",
                        column: x => x.AccessGroupId,
                        principalTable: "AccessGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkerGroupAccess_WorkerGroups_WorkerGroupId",
                        column: x => x.WorkerGroupId,
                        principalTable: "WorkerGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkerGroupAccess_AccessGroupId",
                table: "WorkerGroupAccess",
                column: "AccessGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerGroupAccess_WorkerGroupId",
                table: "WorkerGroupAccess",
                column: "WorkerGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkerGroupAccess");
        }
    }
}
