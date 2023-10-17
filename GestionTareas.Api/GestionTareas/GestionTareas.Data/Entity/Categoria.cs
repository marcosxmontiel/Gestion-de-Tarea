using System;
using System.Collections.Generic;

namespace GestionTareas.Data.Entity;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string CodCategoria { get; set; } = null!;

    public string NombreCategoria { get; set; } = null!;

    public string DescCategoria { get; set; } = null!;

    public bool? Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}
