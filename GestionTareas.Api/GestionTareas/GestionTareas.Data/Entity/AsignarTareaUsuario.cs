using System;
using System.Collections.Generic;

namespace GestionTareas.Data.Entity;

public partial class AsignarTareaUsuario
{
    public int IdAsignarTareaUsuario { get; set; }

    public string IdUsuario { get; set; } = null!;

    public int IdTarea { get; set; }

    public string EstadoTarea { get; set; } = null!;

    public DateTime FechaMaxEntrega { get; set; }

    public bool? Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }
}
