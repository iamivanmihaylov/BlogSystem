using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSessionToReactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Session",
                table: "BlogPostReactions",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Session",
                table: "BlogPostReactions");
        }
    }
}
