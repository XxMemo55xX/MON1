using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tut8.Migrations
{
    public partial class revert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentIdDepartment",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentIdDepartment",
                table: "Employees",
                column: "DepartmentIdDepartment");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentIdDepartment",
                table: "Employees",
                column: "DepartmentIdDepartment",
                principalTable: "Departments",
                principalColumn: "IdDepartment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentIdDepartment",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepartmentIdDepartment",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartmentIdDepartment",
                table: "Employees");
        }
    }
}
