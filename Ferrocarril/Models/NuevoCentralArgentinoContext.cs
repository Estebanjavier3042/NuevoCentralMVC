using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ferrocarril.Models;

public partial class NuevoCentralArgentinoContext : DbContext
{
    public NuevoCentralArgentinoContext()
    {
    }

    public NuevoCentralArgentinoContext(DbContextOptions<NuevoCentralArgentinoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BaseOperativa> BaseOperativas { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<Sueldo> Sueldos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=DESKTOP-50JVEVG\\SQLEXPRESS;database=NuevoCentralArgentino;Integrated Security=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        

      

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
