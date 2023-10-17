using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTareas.Domain.Models
{
    public class CategoriaDTO
    {
        public int IdCategoria { get; set; }

        public string CodCategoria { get; set; } = null!;

        public string NombreCategoria { get; set; } = null!;
    }
}