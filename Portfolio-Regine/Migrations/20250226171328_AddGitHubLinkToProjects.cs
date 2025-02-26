using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio_Regine.Migrations
{
    /// <inheritdoc />
    public partial class AddGitHubLinkToProjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GitHubLink",
                table: "Projects",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GitHubLink",
                table: "Projects");
        }
    }
}
