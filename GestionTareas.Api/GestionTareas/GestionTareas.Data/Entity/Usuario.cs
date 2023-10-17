using System;
using System.Collections.Generic;

namespace GestionTareas.Data.Entity;

public partial class Usuario
{
    public string IdUsuario { get; set; } = null!;

    public string NombreUsuario { get; set; } = null!;

    public bool? Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }
}
