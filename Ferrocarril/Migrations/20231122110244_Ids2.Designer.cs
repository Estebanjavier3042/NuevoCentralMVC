﻿// <auto-generated />
using System;
using Ferrocarril.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ferrocarril.Migrations
{
    [DbContext(typeof(NuevoCentralArgentinoContext))]
    [Migration("20231122110244_Ids2")]
    partial class Ids2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ferrocarril.Models.BaseOperativa", b =>
                {
                    b.Property<int>("IdBase")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBase"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdBase");

                    b.ToTable("BaseOperativas");
                });

            modelBuilder.Entity("Ferrocarril.Models.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategoria"));

                    b.Property<bool>("Art2000")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SueldoBasico")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdCategoria");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Ferrocarril.Models.Empleado", b =>
                {
                    b.Property<int>("Legajo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Legajo"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BaseOperativaId")
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("FechaIngreso")
                        .HasColumnType("date");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServicioId")
                        .HasColumnType("int");

                    b.HasKey("Legajo");

                    b.HasIndex("BaseOperativaId");

                    b.HasIndex("CategoriaId")
                        .IsUnique();

                    b.HasIndex("ServicioId");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("Ferrocarril.Models.Servicio", b =>
                {
                    b.Property<int>("IdServicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdServicio"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Item")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdServicio");

                    b.ToTable("Servicios");
                });

            modelBuilder.Entity("Ferrocarril.Models.Sueldo", b =>
                {
                    b.Property<int>("IdSueldo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSueldo"));

                    b.Property<int>("CantServicios")
                        .HasColumnType("int");

                    b.Property<int>("EmpleadoId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("FechaDeLiquidacion")
                        .HasColumnType("date");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdSueldo");

                    b.HasIndex("EmpleadoId")
                        .IsUnique();

                    b.ToTable("Sueldos");
                });

            modelBuilder.Entity("Ferrocarril.Models.Empleado", b =>
                {
                    b.HasOne("Ferrocarril.Models.BaseOperativa", "BaseOperativa")
                        .WithMany("Empleados")
                        .HasForeignKey("BaseOperativaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ferrocarril.Models.Categoria", "Categoria")
                        .WithOne("Empleado")
                        .HasForeignKey("Ferrocarril.Models.Empleado", "CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ferrocarril.Models.Servicio", "Servicio")
                        .WithMany("Empleados")
                        .HasForeignKey("ServicioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BaseOperativa");

                    b.Navigation("Categoria");

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("Ferrocarril.Models.Sueldo", b =>
                {
                    b.HasOne("Ferrocarril.Models.Empleado", "Empleado")
                        .WithOne("Sueldo")
                        .HasForeignKey("Ferrocarril.Models.Sueldo", "EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("Ferrocarril.Models.BaseOperativa", b =>
                {
                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("Ferrocarril.Models.Categoria", b =>
                {
                    b.Navigation("Empleado")
                        .IsRequired();
                });

            modelBuilder.Entity("Ferrocarril.Models.Empleado", b =>
                {
                    b.Navigation("Sueldo");
                });

            modelBuilder.Entity("Ferrocarril.Models.Servicio", b =>
                {
                    b.Navigation("Empleados");
                });
#pragma warning restore 612, 618
        }
    }
}
