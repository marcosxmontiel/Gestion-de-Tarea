using GestionTareas.Data.Entity;
using GestionTareas.Domain.Models;
using GestionTareas.Domain.Models.Comun;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTareas.Data
{
    public class AsignarTareaData
    {
        private ControlTareasContext _db;

        public AsignarTareaData(ControlTareasContext db)
        {
            this._db = db;
        }

        public IEnumerable<AsignarTareaUsuarioDTO> GetAsignacionTarea(ref string msgError)
        {
            var response = new List<AsignarTareaUsuarioDTO>();

            try
            {
                var qry = from asignar in this._db.AsignarTareaUsuarios
                          join usuario in this._db.Usuarios on asignar.IdUsuario equals usuario.IdUsuario
                          join estadoTarea in this._db.EstadoTareas on asignar.EstadoTarea equals estadoTarea.IdEstadoTarea
                          join tarea in this._db.Tareas on asignar.IdTarea equals tarea.IdTarea
                          join categoria in this._db.Categorias on tarea.IdCategoria equals categoria.IdCategoria
                          where asignar.Activo == true 
                          && tarea.Activo == true 
                          && usuario.Activo == true
                          select new AsignarTareaUsuarioDTO
                          {
                              IdAsignarTareaUsuario = asignar.IdAsignarTareaUsuario,
                              IdUsuario = asignar.IdUsuario,
                              NombreUsuario = usuario.NombreUsuario,
                              IdTarea = asignar.IdTarea,
                              NombreTarea = tarea.NombreTarea,
                              EstadoTarea = asignar.EstadoTarea,
                              NombreEstadoTarea = estadoTarea.NombreEstadoTarea,
                              IdCategoria = categoria.IdCategoria,
                              NombreCategoria = categoria.NombreCategoria,
                              FechaMaxEntrega = asignar.FechaMaxEntrega,
                              Activo = asignar.Activo,
                              FechaCreacion = asignar.FechaCreacion,
                              FechaModificacion = asignar.FechaModificacion
                          };

                response = qry.Distinct().ToList();
            }
            catch (Exception ex)
            {
                msgError = ex.Message;
            }

            return response;
        }

        public AsignarTareaUsuarioDTO? GetAsignacionTareaxId(int id, ref string msgError)
        {
            var response = new AsignarTareaUsuarioDTO();

            try
            {
                var qry = from asignar in this._db.AsignarTareaUsuarios
                          join usuario in this._db.Usuarios on asignar.IdUsuario equals usuario.IdUsuario
                          join estadoTarea in this._db.EstadoTareas on asignar.EstadoTarea equals estadoTarea.IdEstadoTarea
                          join tarea in this._db.Tareas on asignar.IdTarea equals tarea.IdTarea
                          join categoria in this._db.Categorias on tarea.IdCategoria equals categoria.IdCategoria
                          where asignar.IdAsignarTareaUsuario == id
                          && asignar.Activo == true 
                          && tarea.Activo == true 
                          && usuario.Activo == true
                          select new AsignarTareaUsuarioDTO
                          {
                              IdAsignarTareaUsuario = asignar.IdAsignarTareaUsuario,
                              IdUsuario = asignar.IdUsuario,
                              NombreUsuario = usuario.NombreUsuario,
                              IdTarea = asignar.IdTarea,
                              NombreTarea = tarea.NombreTarea,
                              EstadoTarea = asignar.EstadoTarea,
                              NombreEstadoTarea = estadoTarea.NombreEstadoTarea,
                              IdCategoria = categoria.IdCategoria,
                              NombreCategoria = categoria.NombreCategoria,
                              FechaMaxEntrega = asignar.FechaMaxEntrega,
                              Activo = asignar.Activo,
                              FechaCreacion = asignar.FechaCreacion,
                              FechaModificacion = asignar.FechaModificacion
                          };

                response = qry.FirstOrDefault();
            }
            catch (Exception ex)
            {
                msgError = ex.Message;
            }

            return response;
        }

        public IEnumerable<AsignarTareaUsuarioDTO> GetAsignacionTareaxFiltro(FiltroDTO filtro, ref string msgError)
        {
            var response = new List<AsignarTareaUsuarioDTO>();

            try
            {
                var qry = from asignar in this._db.AsignarTareaUsuarios
                          join usuario in this._db.Usuarios on asignar.IdUsuario equals usuario.IdUsuario
                          join estadoTarea in this._db.EstadoTareas on asignar.EstadoTarea equals estadoTarea.IdEstadoTarea
                          join tarea in this._db.Tareas on asignar.IdTarea equals tarea.IdTarea
                          join categoria in this._db.Categorias on tarea.IdCategoria equals categoria.IdCategoria
                          where asignar.Activo == true 
                          && tarea.Activo == true 
                          && usuario.Activo == true
                          select new AsignarTareaUsuarioDTO
                          {
                              IdAsignarTareaUsuario = asignar.IdAsignarTareaUsuario,
                              IdUsuario = asignar.IdUsuario,
                              NombreUsuario = usuario.NombreUsuario,
                              IdTarea = asignar.IdTarea,
                              NombreTarea = tarea.NombreTarea,
                              EstadoTarea = asignar.EstadoTarea,
                              NombreEstadoTarea = estadoTarea.NombreEstadoTarea,
                              IdCategoria = categoria.IdCategoria,
                              NombreCategoria = categoria.NombreCategoria,
                              FechaMaxEntrega = asignar.FechaMaxEntrega,
                              Activo = asignar.Activo,
                              FechaCreacion = asignar.FechaCreacion,
                              FechaModificacion = asignar.FechaModificacion
                          };

                response = qry.Distinct().ToList();

                if(filtro.Idcategoria != 0)
                {
                    response = response.Where(x => x.IdCategoria == filtro.Idcategoria).ToList();
                }

                if (!string.IsNullOrEmpty(filtro.estado))
                {
                    response = response.Where(x => x.EstadoTarea == filtro.estado).ToList();
                }
            }
            catch (Exception ex)
            {
                msgError = ex.Message;
            }

            return response;
        }

        public bool SaveAsignacionTarea(AsignarTareaUsuarioDTO asignarTareaUsuarioDTO, ref string msgError)
        {
            try
            {
                if(asignarTareaUsuarioDTO.IdAsignarTareaUsuario == 0)
                {
                    var objAsignarTarea = new AsignarTareaUsuario();
                    objAsignarTarea.IdUsuario = asignarTareaUsuarioDTO.IdUsuario ?? "";
                    objAsignarTarea.IdTarea = asignarTareaUsuarioDTO.IdTarea;
                    objAsignarTarea.EstadoTarea = asignarTareaUsuarioDTO.EstadoTarea ?? "";
                    objAsignarTarea.FechaMaxEntrega = asignarTareaUsuarioDTO.FechaMaxEntrega;
                    objAsignarTarea.Activo = true;
                    objAsignarTarea.FechaCreacion = DateTime.Now;

                    this._db.AsignarTareaUsuarios.Add(objAsignarTarea);
                    this._db.SaveChanges();
                }
                else
                {
                    AsignarTareaUsuario? existsAsignarTarea = null;
                    existsAsignarTarea = this._db.AsignarTareaUsuarios
                        .FirstOrDefault(p => p.IdAsignarTareaUsuario == asignarTareaUsuarioDTO.IdAsignarTareaUsuario);

                    if (existsAsignarTarea != null)
                    {
                        existsAsignarTarea.IdUsuario = asignarTareaUsuarioDTO.IdUsuario ?? "";
                        existsAsignarTarea.IdTarea = asignarTareaUsuarioDTO.IdTarea;
                        existsAsignarTarea.EstadoTarea = asignarTareaUsuarioDTO.EstadoTarea ?? "";
                        existsAsignarTarea.FechaMaxEntrega = asignarTareaUsuarioDTO.FechaMaxEntrega;
                        existsAsignarTarea.FechaModificacion = DateTime.Now;

                        this._db.Entry(existsAsignarTarea).State = EntityState.Modified;
                        this._db.SaveChanges();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                msgError = ex.Message;
                return false;
            }
        }

        public bool CambiarEstadoAsignacionTarea(FiltroDTO filtro, ref string msgError)
        {
            try
            {
                AsignarTareaUsuario? existsAsignarTarea = null;
                existsAsignarTarea = this._db.AsignarTareaUsuarios
                    .FirstOrDefault(p => p.IdAsignarTareaUsuario == filtro.IdAsignacionTarea);

                if (existsAsignarTarea != null)
                {
                    existsAsignarTarea.EstadoTarea = string.IsNullOrEmpty(filtro.estado) ? "PE" : filtro.estado.ToUpper();
                    existsAsignarTarea.FechaModificacion = DateTime.Now;

                    this._db.Entry(existsAsignarTarea).State = EntityState.Modified;
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

        public bool DeleteAsignacionTarea(int id, ref string msgError)
        {
            try
            {
                AsignarTareaUsuario? existsAsignarTarea = null;
                existsAsignarTarea = this._db.AsignarTareaUsuarios
                    .FirstOrDefault(p => p.IdAsignarTareaUsuario == id);

                if (existsAsignarTarea != null)
                {
                    existsAsignarTarea.Activo = false;
                    existsAsignarTarea.FechaModificacion = DateTime.Now;

                    this._db.Entry(existsAsignarTarea).State = EntityState.Modified;
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