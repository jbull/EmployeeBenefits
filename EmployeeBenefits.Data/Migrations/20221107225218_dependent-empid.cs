using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeBenefits.Data.Migrations
{
    public partial class dependentempid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Dependents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Dependents");
        }
    }
}
