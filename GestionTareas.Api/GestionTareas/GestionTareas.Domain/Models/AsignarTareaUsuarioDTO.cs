using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTareas.Domain.Models
{
    public class AsignarTareaUsuarioDTO
    {
        public int IdAsignarTareaUsuario { get; set; }


        public string? IdUsuario { get; set; }

        public string? NombreUsuario { get; set; }


        public int IdTarea { get; set; }

        public string? NombreTarea { get; set; }


        public string? EstadoTarea { get; set; }

        public string? NombreEstadoTarea { get; set; }

        public int IdCategoria { get; set; }

        public string? NombreCategoria { get; set; }


        public DateTime FechaMaxEntrega { get; set; }


        public bool? Activo { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }
    }
}