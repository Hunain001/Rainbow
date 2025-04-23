using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rainbow.Migrations
{
    /// <inheritdoc />
    public partial class Bakersmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_cakes",
                table: "cakes");

            migrationBuilder.AlterColumn<int>(
                name: "CId",
                table: "cakes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "isspecial",
                table: "cakes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_cakes",
                table: "cakes",
                column: "CId");

            migrationBuilder.CreateIndex(
                name: "IX_cakes_id",
                table: "cakes",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_cakes",
                table: "cakes");

            migrationBuilder.DropIndex(
                name: "IX_cakes_id",
                table: "cakes");

            migrationBuilder.DropColumn(
                name: "isspecial",
                table: "cakes");

            migrationBuilder.AlterColumn<int>(
                name: "CId",
                table: "cakes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cakes",
                table: "cakes",
                column: "id");
        }
    }
}
