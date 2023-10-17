using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTareas.Domain.Models
{
    public class TareaDTO
    {
        public int IdTarea { get; set; }

        public string? CodTarea { get; set; }

        public string? NombreTarea { get; set; }

        public string? DescTarea { get; set; }

        public int IdCategoria { get; set; }

        public string? NombreCategoria { get; set; }

        public bool? Activo { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }
    }
}