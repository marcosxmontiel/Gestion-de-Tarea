using GestionTareas.Data.Entity;
using GestionTareas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTareas.Data
{
    public class CategoriaData
    {
        private ControlTareasContext _db;

        public CategoriaData(ControlTareasContext db)
        {
            this._db = db;
        }

        public IEnumerable<CategoriaDTO> GetCategoria(ref string msgError)
        {
            var response = new List<CategoriaDTO>();

            try
            {
                var qry = from categoria in this._db.Categorias
                          where categoria.Activo == true
                          select new CategoriaDTO
                          {
                              IdCategoria = categoria.IdCategoria,
                              CodCategoria = categoria.CodCategoria,
                              NombreCategoria = categoria.NombreCategoria
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