using System;
using System.Collections.Generic;

namespace GestionTareas.Data.Entity;

public partial class Tarea
{
    public int IdTarea { get; set; }

    public string CodTarea { get; set; } = null!;

    public string NombreTarea { get; set; } = null!;

    public string DescTarea { get; set; } = null!;

    public int IdCategoria { get; set; }

    public bool? Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual Categoria IdCategoriaNavigation { get; set; } = null!;
}
