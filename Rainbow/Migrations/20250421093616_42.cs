using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rainbow.Migrations
{
    /// <inheritdoc />
    public partial class _42 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cakes_categoury_id",
                table: "cakes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categoury",
                table: "categoury");

            migrationBuilder.RenameTable(
                name: "categoury",
                newName: "categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categories",
                table: "categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_cakes_categories_id",
                table: "cakes",
                column: "id",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cakes_categories_id",
                table: "cakes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categories",
                table: "categories");

            migrationBuilder.RenameTable(
                name: "categories",
                newName: "categoury");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categoury",
                table: "categoury",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_cakes_categoury_id",
                table: "cakes",
                column: "id",
                principalTable: "categoury",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
