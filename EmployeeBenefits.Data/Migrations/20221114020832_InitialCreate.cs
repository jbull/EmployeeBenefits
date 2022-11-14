using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeBenefits.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dependent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    DependentType = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dependent_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 1, "John", "Smith" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 2, "Betty", "Jones" });

            migrationBuilder.InsertData(
                table: "Dependent",
                columns: new[] { "Id", "DependentType", "EmployeeId", "FirstName", "LastName" },
                values: new object[] { 1, 0, 1, "becky", "Jones" });

            migrationBuilder.InsertData(
                table: "Dependent",
                columns: new[] { "Id", "DependentType", "EmployeeId", "FirstName", "LastName" },
                values: new object[] { 2, 0, 1, "Andy", "Jones" });

            migrationBuilder.CreateIndex(
                name: "IX_Dependent_EmployeeId",
                table: "Dependent",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dependent");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
