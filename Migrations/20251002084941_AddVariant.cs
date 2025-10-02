using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABLE_API.Migrations
{
    /// <inheritdoc />
    public partial class AddVariant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Variant",
                table: "ExperimentData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Variant",
                table: "ExperimentData");
        }
    }
}
