using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreEFMVCApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangedEmployeeEntityName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emploees_Departments_DepartmentId",
                table: "Emploees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Emploees",
                table: "Emploees");

            migrationBuilder.RenameTable(
                name: "Emploees",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_Emploees_DepartmentId",
                table: "Employees",
                newName: "IX_Employees_DepartmentId");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Emploees");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DepartmentId",
                table: "Emploees",
                newName: "IX_Emploees_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emploees",
                table: "Emploees",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emploees_Departments_DepartmentId",
                table: "Emploees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
