using GestionTareas.Data;
using GestionTareas.Data.Entity;
using GestionTareas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTareas.Business
{
    public class TareaBusiness
    {
        private TareaData _oData;

        public TareaBusiness(ControlTareasContext db)
        {
            this._oData = new TareaData(db);
        }

        public IEnumerable<TareaDTO> GetTareas(ref string msgError)
        {
            return this._oData.GetTareas(ref msgError);
        }

        public TareaDTO? GetTarea(int id, ref string msgError)
        {
            return this._oData.GetTarea(id, ref msgError);
        }

        public bool SaveTarea(TareaDTO tareaDTO, ref string msgError)
        {
            return this._oData.SaveTarea(tareaDTO, ref msgError);
        }

        public bool DeleteTarea(int id, ref string msgError)
        {
            return this._oData.DeleteTarea(id, ref msgError);
        }
    }
}