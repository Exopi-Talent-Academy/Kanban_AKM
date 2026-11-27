using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Kanban_AKM.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingColumnEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Boards_BoardEntityId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "BoardEntityId",
                table: "Tasks",
                newName: "ColumnEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_BoardEntityId",
                table: "Tasks",
                newName: "IX_Tasks_ColumnEntityId");

            migrationBuilder.CreateTable(
                name: "ColumnEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    BoardEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColumnEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColumnEntity_Boards_BoardEntityId",
                        column: x => x.BoardEntityId,
                        principalTable: "Boards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColumnEntity_BoardEntityId",
                table: "ColumnEntity",
                column: "BoardEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_ColumnEntity_ColumnEntityId",
                table: "Tasks",
                column: "ColumnEntityId",
                principalTable: "ColumnEntity",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_ColumnEntity_ColumnEntityId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "ColumnEntity");

            migrationBuilder.RenameColumn(
                name: "ColumnEntityId",
                table: "Tasks",
                newName: "BoardEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_ColumnEntityId",
                table: "Tasks",
                newName: "IX_Tasks_BoardEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Boards_BoardEntityId",
                table: "Tasks",
                column: "BoardEntityId",
                principalTable: "Boards",
                principalColumn: "Id");
        }
    }
}
