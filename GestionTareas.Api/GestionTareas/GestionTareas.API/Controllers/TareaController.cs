using Azure;
using GestionTareas.Business;
using GestionTareas.Data.Entity;
using GestionTareas.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionTareas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class TareaController : ControllerBase
    {
        private readonly ILogger<TareaController> _logger;
        private TareaBusiness _oBusiness;

        public TareaController(ILogger<TareaController> logger, ControlTareasContext db)
        {
            this._logger = logger;
            this._oBusiness = new TareaBusiness(db);
        }

        [HttpGet]
        [Route("GetTareas")]
        public IActionResult Get()
        {
            string msgError = "";
            var result = this._oBusiness.GetTareas(ref msgError);

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
        [Route("GetTareasxId")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return BadRequest();

            string msgError = "";
            var result = this._oBusiness.GetTarea(id, ref msgError);

            if (!string.IsNullOrEmpty(msgError))
            {
                return Ok(new
                {
                    Success = false,
                    MensajeError = msgError
                });
            }

            if(result == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                Success = true,
                Tarea = result
            });
        }

        [HttpPost]
        [Route("GuardarTareas")]
        public IActionResult Post([FromBody] TareaDTO tareaDTO)
        {
            if (tareaDTO == null)
                return BadRequest();

            string msgError = "";
            this._oBusiness.SaveTarea(tareaDTO, ref msgError);

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
        //[Route("EliminarTareas")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            string msgError = "";
            this._oBusiness.DeleteTarea(id, ref msgError);

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