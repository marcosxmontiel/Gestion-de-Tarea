using GestionTareas.Data.Entity;
using GestionTareas.Data;
using GestionTareas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTareas.Business
{
    public class EstadoTareaBusiness
    {
        private EstadoTareaData _oData;

        public EstadoTareaBusiness(ControlTareasContext db)
        {
            this._oData = new EstadoTareaData(db);
        }

        public IEnumerable<EstadoTareaDTO> GetEstadoTarea(ref string msgError)
        {
            return this._oData.GetEstadoTarea(ref msgError);
        }
    }
}