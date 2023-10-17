using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTareas.Domain.Models.Comun
{
    public class FiltroDTO
    {
        public int IdAsignacionTarea { get; set; }
        public int IdTarea { get; set; }
        public string? estado { get; set; }
        public int Idcategoria { get; set; }
    }
}