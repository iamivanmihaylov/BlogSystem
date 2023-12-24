using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveImagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPostImages");

            migrationBuilder.RenameColumn(
                name: "HeadingImage",
                table: "BlogPosts",
                newName: "HeadingImageUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HeadingImageUrl",
                table: "BlogPosts",
                newName: "HeadingImage");

            migrationBuilder.CreateTable(
                name: "BlogPostImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogPostId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPostImages_BlogPosts_BlogPostId",
                        column: x => x.BlogPostId,
                        principalTable: "BlogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostImages_BlogPostId",
                table: "BlogPostImages",
                column: "BlogPostId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostImages_IsDeleted",
                table: "BlogPostImages",
                column: "IsDeleted");
        }
    }
}
