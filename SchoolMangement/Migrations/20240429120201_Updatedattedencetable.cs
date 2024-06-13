using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolMangement.Migrations
{
    /// <inheritdoc />
    public partial class Updatedattedencetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "StudentAttendences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "StudentAttendences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "StudentAttendences");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentAttendences");
        }
    }
}
