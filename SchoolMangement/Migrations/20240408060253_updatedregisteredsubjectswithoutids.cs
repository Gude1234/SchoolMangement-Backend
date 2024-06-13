using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolMangement.Migrations
{
    /// <inheritdoc />
    public partial class updatedregisteredsubjectswithoutids : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Course_Id",
                table: "RegisteredSubjects");

            migrationBuilder.DropColumn(
                name: "Student_Id",
                table: "RegisteredSubjects");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "RegisteredSubjects",
                newName: "SubjectName");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "RegisteredSubjects",
                newName: "SubjectCode");

            migrationBuilder.AddColumn<string>(
                name: "Course",
                table: "RegisteredSubjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RollNumber",
                table: "RegisteredSubjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "RegisteredSubjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Course",
                table: "RegisteredSubjects");

            migrationBuilder.DropColumn(
                name: "RollNumber",
                table: "RegisteredSubjects");

            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "RegisteredSubjects");

            migrationBuilder.RenameColumn(
                name: "SubjectName",
                table: "RegisteredSubjects",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "SubjectCode",
                table: "RegisteredSubjects",
                newName: "Code");

            migrationBuilder.AddColumn<int>(
                name: "Course_Id",
                table: "RegisteredSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Student_Id",
                table: "RegisteredSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
