using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio_Regine.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionFrenchAndSkillsToProjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescriptionFrench",
                table: "Projects",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Skills",
                table: "Projects",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionFrench",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Skills",
                table: "Projects");
        }
    }
}
