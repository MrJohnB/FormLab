using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiteBulb.FormLab.Infrastructure.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddFormNameAndDescriptionFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FormSubmission",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FormSubmission",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FormDefinition",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FormDefinition",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "FormSubmission");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "FormSubmission");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "FormDefinition");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "FormDefinition");
        }
    }
}
