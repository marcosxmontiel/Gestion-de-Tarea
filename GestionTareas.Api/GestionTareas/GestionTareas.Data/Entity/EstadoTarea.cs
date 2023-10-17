using System;
using System.Collections.Generic;

namespace GestionTareas.Data.Entity;

public partial class EstadoTarea
{
    public string IdEstadoTarea { get; set; } = null!;

    public string NombreEstadoTarea { get; set; } = null!;

    public bool? Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }
}
