using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ferrocarril.Migrations
{
    /// <inheritdoc />
    public partial class Ids1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Sueldos_SueldoId",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_SueldoId",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "SueldoId",
                table: "Empleados");

            migrationBuilder.AddColumn<int>(
                name: "EmpleadoId",
                table: "Sueldos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sueldos_EmpleadoId",
                table: "Sueldos",
                column: "EmpleadoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sueldos_Empleados_EmpleadoId",
                table: "Sueldos",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "Legajo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sueldos_Empleados_EmpleadoId",
                table: "Sueldos");

            migrationBuilder.DropIndex(
                name: "IX_Sueldos_EmpleadoId",
                table: "Sueldos");

            migrationBuilder.DropColumn(
                name: "EmpleadoId",
                table: "Sueldos");

            migrationBuilder.AddColumn<int>(
                name: "SueldoId",
                table: "Empleados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_SueldoId",
                table: "Empleados",
                column: "SueldoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Sueldos_SueldoId",
                table: "Empleados",
                column: "SueldoId",
                principalTable: "Sueldos",
                principalColumn: "IdSueldo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
