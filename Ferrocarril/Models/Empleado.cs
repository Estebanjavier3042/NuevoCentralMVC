using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ferrocarril.Models;

public partial class Empleado
{
    [Key]
    public int Legajo { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public DateOnly FechaIngreso { get; set; }

    public int BaseOperativaId { get; set; }

    public int ServicioId { get; set; }
    public int CategoriaId { get; set; }    
    

    public virtual BaseOperativa BaseOperativa { get; set; } = null!;

    public virtual Categoria? Categoria { get; set; }

    public virtual Servicio Servicio { get; set; } = null!;

    public virtual Sueldo? Sueldo { get; set; }
}
