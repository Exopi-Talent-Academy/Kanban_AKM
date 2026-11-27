using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kanban_AKM.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class dbContextUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColumnEntity_Boards_BoardEntityId",
                table: "ColumnEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_ColumnEntity_ColumnEntityId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ColumnEntity",
                table: "ColumnEntity");

            migrationBuilder.RenameTable(
                name: "ColumnEntity",
                newName: "Columns");

            migrationBuilder.RenameIndex(
                name: "IX_ColumnEntity_BoardEntityId",
                table: "Columns",
                newName: "IX_Columns_BoardEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Columns",
                table: "Columns",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Columns_Boards_BoardEntityId",
                table: "Columns",
                column: "BoardEntityId",
                principalTable: "Boards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Columns_ColumnEntityId",
                table: "Tasks",
                column: "ColumnEntityId",
                principalTable: "Columns",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Columns_Boards_BoardEntityId",
                table: "Columns");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Columns_ColumnEntityId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Columns",
                table: "Columns");

            migrationBuilder.RenameTable(
                name: "Columns",
                newName: "ColumnEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Columns_BoardEntityId",
                table: "ColumnEntity",
                newName: "IX_ColumnEntity_BoardEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColumnEntity",
                table: "ColumnEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ColumnEntity_Boards_BoardEntityId",
                table: "ColumnEntity",
                column: "BoardEntityId",
                principalTable: "Boards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_ColumnEntity_ColumnEntityId",
                table: "Tasks",
                column: "ColumnEntityId",
                principalTable: "ColumnEntity",
                principalColumn: "Id");
        }
    }
}
