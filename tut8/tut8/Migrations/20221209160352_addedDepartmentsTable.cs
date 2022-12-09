﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tut8.Migrations
{
    /// <inheritdoc />
    public partial class addedDepartmentsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentIdDepartment",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    IdDepartment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.IdDepartment);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentIdDepartment",
                table: "Employees",
                column: "DepartmentIdDepartment");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentIdDepartment",
                table: "Employees",
                column: "DepartmentIdDepartment",
                principalTable: "Departments",
                principalColumn: "IdDepartment",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentIdDepartment",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepartmentIdDepartment",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartmentIdDepartment",
                table: "Employees");
        }
    }
}
