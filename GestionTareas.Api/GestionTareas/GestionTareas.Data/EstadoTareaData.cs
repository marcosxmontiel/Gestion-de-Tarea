using GestionTareas.Data.Entity;
using GestionTareas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTareas.Data
{
    public class EstadoTareaData
    {
        private ControlTareasContext _db;

        public EstadoTareaData(ControlTareasContext db)
        {
            this._db = db;
        }

        public IEnumerable<EstadoTareaDTO> GetEstadoTarea(ref string msgError)
        {
            var response = new List<EstadoTareaDTO>();

            try
            {
                var qry = from estado in this._db.EstadoTareas
                          where estado.Activo == true
                          select new EstadoTareaDTO
                          {
                              IdEstadoTarea = estado.IdEstadoTarea,
                              NombreEstadoTarea = estado.NombreEstadoTarea
                          };

                response = qry.Distinct().ToList();
            }
            catch (Exception ex)
            {
                msgError = ex.Message;
            }

            return response;
        }
    }
}