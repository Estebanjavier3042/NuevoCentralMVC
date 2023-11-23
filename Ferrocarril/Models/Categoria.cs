using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ferrocarril.Models;

public partial class Categoria
{
    [Key]
    public int IdCategoria { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Art2000 { get; set; }

    

    public decimal SueldoBasico { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
