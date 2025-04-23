using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rainbow.Migrations
{
    /// <inheritdoc />
    public partial class AddReviewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatePosted",
                table: "reviews");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "reviews",
                newName: "cakeid");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "reviews",
                newName: "star");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "reviews",
                newName: "Comment");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_cakeid",
                table: "reviews",
                column: "cakeid");

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_cakes_cakeid",
                table: "reviews",
                column: "cakeid",
                principalTable: "cakes",
                principalColumn: "CId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reviews_cakes_cakeid",
                table: "reviews");

            migrationBuilder.DropIndex(
                name: "IX_reviews_cakeid",
                table: "reviews");

            migrationBuilder.RenameColumn(
                name: "star",
                table: "reviews",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "cakeid",
                table: "reviews",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "reviews",
                newName: "Message");

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePosted",
                table: "reviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
