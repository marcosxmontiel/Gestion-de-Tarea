using GestionTareas.Business;
using GestionTareas.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionTareas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class EstadoTareaController : ControllerBase
    {
        private readonly ILogger<EstadoTareaController> _logger;
        private EstadoTareaBusiness _oBusiness;

        public EstadoTareaController(ILogger<EstadoTareaController> logger, ControlTareasContext db)
        {
            this._logger = logger;
            this._oBusiness = new EstadoTareaBusiness(db);
        }

        [HttpGet]
        [Route("GetEstadoTarea")]
        public IActionResult Get()
        {
            string msgError = "";
            var result = this._oBusiness.GetEstadoTarea(ref msgError);

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
                Estados = result
            });
        }
    }
}