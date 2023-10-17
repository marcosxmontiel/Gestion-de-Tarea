using GestionTareas.Data.Entity;
using GestionTareas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GestionTareas.Data
{
    public class TareaData
    {
        private ControlTareasContext _db;

        public TareaData(ControlTareasContext db) 
        {
            this._db = db;
        }

        public IEnumerable<TareaDTO> GetTareas(ref string msgError)
        {
            var response = new List<TareaDTO>();

            try
            {
                var qry = from tarea in this._db.Tareas
                          join categoria in this._db.Categorias on tarea.IdCategoria equals categoria.IdCategoria
                          where tarea.Activo == true
                          select new TareaDTO
                          {
                              IdTarea = tarea.IdTarea,
                              CodTarea = tarea.CodTarea,
                              NombreTarea = tarea.NombreTarea,
                              DescTarea = tarea.DescTarea,
                              IdCategoria = tarea.IdCategoria,
                              NombreCategoria = categoria.NombreCategoria,
                              Activo = tarea.Activo,
                              FechaCreacion = tarea.FechaCreacion,
                              FechaModificacion = tarea.FechaModificacion
                          };

                response = qry.Distinct().ToList();
            }
            catch (Exception ex)
            {
                msgError = ex.Message;
            }

            return response;
        }

        public TareaDTO? GetTarea(int id, ref string msgError)
        {
            var response = new TareaDTO();

            try
            {
                var qry = from tarea in this._db.Tareas
                          join categoria in this._db.Categorias on tarea.IdCategoria equals categoria.IdCategoria
                          where tarea.Activo == true
                          && tarea.IdTarea == id
                          select new TareaDTO
                          {
                              IdTarea = tarea.IdTarea,
                              CodTarea = tarea.CodTarea,
                              NombreTarea = tarea.NombreTarea,
                              DescTarea = tarea.DescTarea,
                              IdCategoria = tarea.IdCategoria,
                              NombreCategoria = categoria.NombreCategoria,
                              Activo = tarea.Activo,
                              FechaCreacion = tarea.FechaCreacion,
                              FechaModificacion = tarea.FechaModificacion
                          };

                response = qry.FirstOrDefault();
            }
            catch (Exception ex)
            {
                msgError = ex.Message;
            }

            return response;
        }

        public bool SaveTarea(TareaDTO tareaDTO, ref string msgError)
        {
            try
            {
                var objTarea = new Tarea();
                objTarea.CodTarea = tareaDTO.CodTarea ?? "";
                objTarea.NombreTarea = tareaDTO.NombreTarea ?? "";
                objTarea.DescTarea = tareaDTO.DescTarea ?? "";
                objTarea.IdCategoria = tareaDTO.IdCategoria;
                objTarea.Activo = true;
                objTarea.FechaCreacion = DateTime.Now;

                this._db.Tareas.Add(objTarea);
                this._db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                msgError = ex.Message;
                return false;
            }
        }

        public bool DeleteTarea(int id, ref string msgError)
        {
            try
            {
                Tarea? existsTarea = null;
                existsTarea = this._db.Tareas
                    .FirstOrDefault(p => p.IdTarea == id);

                if(existsTarea != null)
                {
                    existsTarea.Activo = false;
                    existsTarea.FechaModificacion = DateTime.Now;

                    this._db.Entry(existsTarea).State = EntityState.Modified;
                    this._db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                msgError = ex.Message;
                return false;
            }
        }
    }
}