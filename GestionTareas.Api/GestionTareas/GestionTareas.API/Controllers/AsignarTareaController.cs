using GestionTareas.Business;
using GestionTareas.Data;
using GestionTareas.Data.Entity;
using GestionTareas.Domain.Models;
using GestionTareas.Domain.Models.Comun;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionTareas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AsignarTareaController : ControllerBase
    {
        private readonly ILogger<AsignarTareaController> _logger;
        private AsignarTareaBusiness _oBusiness;

        public AsignarTareaController(ILogger<AsignarTareaController> logger, ControlTareasContext db)
        {
            this._logger = logger;
            this._oBusiness = new AsignarTareaBusiness(db);
        }

        [HttpGet]
        [Route("GetAsignacionTarea")]
        public IActionResult Get()
        {
            string msgError = "";
            var result = this._oBusiness.GetAsignacionTarea(ref msgError);

            if (!string.IsNullOrEmpty(msgError))
            {
                return Ok(new
                {
                    Success = false,
                    MensajeError = msgError
                });
            }

            return Ok(new
            {
                Success = true,
                Tareas = result
            });
        }

        [HttpGet]
        [Route("GetAsignacionTareaxId")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return BadRequest();

            string msgError = "";
            var result = this._oBusiness.GetAsignacionTareaxId(id, ref msgError);

            if (!string.IsNullOrEmpty(msgError))
            {
                return Ok(new
                {
                    Success = false,
                    MensajeError = msgError
                });
            }

            if (result == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                Success = true,
                Tarea = result ?? new AsignarTareaUsuarioDTO()
            });
        }

        [HttpGet]
        [Route("GetAsignacionTareaxCategoria")]
        public IActionResult GetxCategoria(int IdCategoria)
        {
            if (IdCategoria == 0)
                return BadRequest();

            string msgError = "";

            FiltroDTO filtro = new FiltroDTO();
            filtro.Idcategoria = IdCategoria;

            var result = this._oBusiness.GetAsignacionTareaxFiltro(filtro, ref msgError);

            if (!string.IsNullOrEmpty(msgError))
            {
                return Ok(new
                {
                    Success = false,
                    MensajeError = msgError
                });
            }

            return Ok(new
            {
                Success = true,
                Tareas = result
            });
        }

        [HttpGet]
        [Route("GetAsignacionTareaxEstado")]
        public IActionResult Get(string estado)
        {
            if (string.IsNullOrEmpty(estado))
                return BadRequest();

            string msgError = "";

            FiltroDTO filtro = new FiltroDTO();
            filtro.estado = estado.ToUpper();

            var result = this._oBusiness.GetAsignacionTareaxFiltro(filtro, ref msgError);

            if (!string.IsNullOrEmpty(msgError))
            {
                return Ok(new
                {
                    Success = false,
                    MensajeError = msgError
                });
            }

            return Ok(new
            {
                Success = true,
                Tareas = result
            });
        }

        [HttpPost]
        [Route("GuardarAsignacionTarea")]
        public IActionResult Post([FromBody] AsignarTareaUsuarioDTO asignarTareaUsuarioDTO)
        {
            if (asignarTareaUsuarioDTO == null)
                return BadRequest();

            string msgError = "";
            this._oBusiness.SaveAsignacionTarea(asignarTareaUsuarioDTO, ref msgError);

            if (!string.IsNullOrEmpty(msgError))
            {
                return Ok(new
                {
                    Success = false,
                    MensajeError = msgError
                });
            }

            return Ok(new
            {
                Success = true
            });
        }

        [HttpPost]
        [Route("CambiarEstadoAsignacionTarea")]
        public IActionResult Post([FromBody] FiltroDTO filtro)
        {
            string msgError = "";
            this._oBusiness.CambiarEstadoAsignacionTarea(filtro, ref msgError);

            if (!string.IsNullOrEmpty(msgError))
            {
                return Ok(new
                {
                    Success = false,
                    MensajeError = msgError
                });
            }

            return Ok(new
            {
                Success = true
            });
        }

        [HttpDelete("{id}")]
        //[Route("EliminarAsignacionTarea")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            string msgError = "";
            this._oBusiness.DeleteAsignacionTarea(id, ref msgError);

            if (!string.IsNullOrEmpty(msgError))
            {
                return Ok(new
                {
                    Success = false,
                    MensajeError = msgError
                });
            }

            return Ok(new
            {
                Success = true
            });
        }
    }
}