using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ferrocarril.Models;

public partial class Sueldo
{
    [Key]
    public int IdSueldo { get; set; }

    public int CantServicios { get; set; }

    public decimal Total { get; set; }
    public int EmpleadoId { get; set; } 

    public DateOnly FechaDeLiquidacion { get; set; }

    public virtual Empleado Empleado { get; set; } = null!;
}
