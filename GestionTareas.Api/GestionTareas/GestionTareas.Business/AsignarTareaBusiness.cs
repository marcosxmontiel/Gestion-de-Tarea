using GestionTareas.Data.Entity;
using GestionTareas.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionTareas.Domain.Models;
using GestionTareas.Domain.Models.Comun;

namespace GestionTareas.Business
{
    public class AsignarTareaBusiness
    {
        private AsignarTareaData _oData;

        public AsignarTareaBusiness(ControlTareasContext db)
        {
            this._oData = new AsignarTareaData(db);
        }

        public IEnumerable<AsignarTareaUsuarioDTO> GetAsignacionTarea(ref string msgError)
        {
            return this._oData.GetAsignacionTarea(ref msgError);
        }

        public AsignarTareaUsuarioDTO? GetAsignacionTareaxId(int id, ref string msgError)
        {
            return this._oData.GetAsignacionTareaxId(id, ref msgError);
        }

        public IEnumerable<AsignarTareaUsuarioDTO> GetAsignacionTareaxFiltro(FiltroDTO filtro, ref string msgError)
        {
            return this._oData.GetAsignacionTareaxFiltro(filtro, ref msgError);
        }

        public bool SaveAsignacionTarea(AsignarTareaUsuarioDTO asignarTareaUsuarioDTO, ref string msgError)
        {
            return this._oData.SaveAsignacionTarea(asignarTareaUsuarioDTO, ref msgError);
        }

        public bool CambiarEstadoAsignacionTarea(FiltroDTO filtro, ref string msgError)
        {
            return this._oData.CambiarEstadoAsignacionTarea(filtro, ref msgError);
        }

        public bool DeleteAsignacionTarea(int id, ref string msgError)
        {
            return this._oData.DeleteAsignacionTarea(id, ref msgError);
        }
    }
}