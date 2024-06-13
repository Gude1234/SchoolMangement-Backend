using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolMangement.Migrations
{
    /// <inheritdoc />
    public partial class updatedregisteredsubjectstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Subject_Id",
                table: "RegisteredSubjects",
                newName: "Staff_Id");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "RegisteredSubjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Course_Id",
                table: "RegisteredSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RegisteredSubjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Semester",
                table: "RegisteredSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "RegisteredSubjects");

            migrationBuilder.DropColumn(
                name: "Course_Id",
                table: "RegisteredSubjects");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "RegisteredSubjects");

            migrationBuilder.DropColumn(
                name: "Semester",
                table: "RegisteredSubjects");

            migrationBuilder.RenameColumn(
                name: "Staff_Id",
                table: "RegisteredSubjects",
                newName: "Subject_Id");
        }
    }
}
