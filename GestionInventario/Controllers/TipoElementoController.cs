using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionInventario.Domain.IEntities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionInventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoElementoController : ControllerBase
    {
        private readonly ITipoElemento _tipoElemento;
        public TipoElementoController(ITipoElemento tipoElemento)
        {
            _tipoElemento = tipoElemento;
        }
        // GET: api/<TipoElementoController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tipoElemento.ObtenerTodos());
            }
            catch (Exception)
            {
                //TODO Log
                return this.Problem("Error interno", null, 500);
            }
            
        }
    }
}
