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
    public class CategoriaBusiness
    {
        private CategoriaData _oData;

        public CategoriaBusiness(ControlTareasContext db)
        {
            this._oData = new CategoriaData(db);
        }

        public IEnumerable<CategoriaDTO> GetCategoria(ref string msgError)
        {
            return this._oData.GetCategoria(ref msgError);
        }
    }
}