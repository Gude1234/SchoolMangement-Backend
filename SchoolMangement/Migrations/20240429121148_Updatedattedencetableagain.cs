using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolMangement.Migrations
{
    /// <inheritdoc />
    public partial class Updatedattedencetableagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Course",
                table: "StudentAttendences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Course",
                table: "StudentAttendences");
        }
    }
}
