using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ferrocarril.Models;

public partial class BaseOperativa
{
    [Key]
    public int IdBase { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Ubicacion { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
    
}
