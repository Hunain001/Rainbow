using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rainbow.Migrations
{
    /// <inheritdoc />
    public partial class reviewmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reviews_cakes_Cakeid",
                table: "reviews");

            migrationBuilder.DropIndex(
                name: "IX_reviews_Cakeid",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "Cakeid",
                table: "reviews");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cakeid",
                table: "reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_reviews_Cakeid",
                table: "reviews",
                column: "Cakeid");

          
        }
    }
}
