using GestionTareas.Business;
using GestionTareas.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionTareas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CategoriaController : ControllerBase
    {
        private readonly ILogger<CategoriaController> _logger;
        private CategoriaBusiness _oBusiness;

        public CategoriaController(ILogger<CategoriaController> logger, ControlTareasContext db)
        {
            this._logger = logger;
            this._oBusiness = new CategoriaBusiness(db);
        }

        [HttpGet]
        [Route("GetCategoria")]
        public IActionResult Get()
        {
            string msgError = "";
            var result = this._oBusiness.GetCategoria(ref msgError);

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
                Categorias = result
            });
        }
    }
}