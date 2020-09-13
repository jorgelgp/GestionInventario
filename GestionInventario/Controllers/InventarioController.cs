using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionInventario.Domain.IEntities;
using GestionInventario.DTOs;
using GestionInventario.Mappers;
using GestionInventario.MVC.Hubs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionInventario.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        private readonly IElemento _elemento;
        public InventarioController(IElemento elemento)
        {
            _elemento = elemento;
        }

        // POST api/<InventarioController>
        [HttpPost]
        public IActionResult Post([FromBody] ElementoDTO value)
        {
            //Nuevo
            try
            {
                ElementoMapper.MapearElementoDTO2Elemento(value, _elemento);
                value.Id = _elemento.Anadir();
                return Ok(value.Id);
            }
            catch (Exception)
            {
                //TODO Log
                return this.Problem("Error interno", null, 500);
            }
        }

        // DELETE api/<InventarioController>/
        [HttpDelete("{nombre}")]
        public IActionResult Delete(string nombre)
        {
            try
            {
                _elemento.Eliminar(nombre);
                return Ok(true);
            }
            catch (Exception)
            {
                //TODO Log
                return this.Problem("Error interno", null, 500);
            }

        }

        [HttpGet]
        public IActionResult Caducados()
        {
            try
            {
                var caducados = _elemento.Caducados();
                var caducadosDTO = new List<ElementoDTO>();
                foreach (var elemento in caducados)
                {
                    var elementoDTO = new ElementoDTO();
                    ElementoMapper.MapearElemento2ElementoDTO(elemento, elementoDTO);
                    caducadosDTO.Add(elementoDTO);
                }
                return Ok(caducadosDTO);
            }
            catch (Exception)
            {
                //TODO Log
                return this.Problem("Error interno", null, 500);
            }
        }
    }
}
