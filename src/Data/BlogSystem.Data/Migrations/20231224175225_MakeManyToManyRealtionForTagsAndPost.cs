using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class MakeManyToManyRealtionForTagsAndPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostTags_BlogPosts_BlogPostId",
                table: "BlogPostTags");

            migrationBuilder.DropIndex(
                name: "IX_BlogPostTags_BlogPostId",
                table: "BlogPostTags");

            migrationBuilder.DropColumn(
                name: "BlogPostId",
                table: "BlogPostTags");

            migrationBuilder.CreateTable(
                name: "BlogPostBlogPostTag",
                columns: table => new
                {
                    BlogPostTagsId = table.Column<int>(type: "int", nullable: false),
                    BlogPostsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostBlogPostTag", x => new { x.BlogPostTagsId, x.BlogPostsId });
                    table.ForeignKey(
                        name: "FK_BlogPostBlogPostTag_BlogPostTags_BlogPostTagsId",
                        column: x => x.BlogPostTagsId,
                        principalTable: "BlogPostTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BlogPostBlogPostTag_BlogPosts_BlogPostsId",
                        column: x => x.BlogPostsId,
                        principalTable: "BlogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostBlogPostTag_BlogPostsId",
                table: "BlogPostBlogPostTag",
                column: "BlogPostsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPostBlogPostTag");

            migrationBuilder.AddColumn<int>(
                name: "BlogPostId",
                table: "BlogPostTags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostTags_BlogPostId",
                table: "BlogPostTags",
                column: "BlogPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostTags_BlogPosts_BlogPostId",
                table: "BlogPostTags",
                column: "BlogPostId",
                principalTable: "BlogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
