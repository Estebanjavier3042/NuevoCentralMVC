using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ferrocarril.Models;

public partial class Servicio
{
    [Key]
    public int IdServicio { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Item { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
