﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ferrocarril.Migrations
{
    /// <inheritdoc />
    public partial class Categorialist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Empleados_CategoriaId",
                table: "Empleados");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_CategoriaId",
                table: "Empleados",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Empleados_CategoriaId",
                table: "Empleados");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_CategoriaId",
                table: "Empleados",
                column: "CategoriaId",
                unique: true);
        }
    }
}
