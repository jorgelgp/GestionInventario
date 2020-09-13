using GestionInventario.Domain.IEntities;
using GestionInventario.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionInventario.Mappers
{
    public static class ElementoMapper
    {
        public static void MapearElementoDTO2Elemento(ElementoDTO elementoDTO, IElemento elemento)
        {
            elemento.Nombre = elementoDTO.Nombre;
            elemento.Caducidad = elementoDTO.Caducidad;
            elemento.TipoElementoId = elementoDTO.Tipo;
        }

        public static void MapearElemento2ElementoDTO(IElemento elemento, ElementoDTO elementoDTO)
        {
            elementoDTO.Nombre = elemento.Nombre;
            elementoDTO.Caducidad = elemento.Caducidad;
            elementoDTO.Tipo = elemento.TipoElementoId;
        }
    }
}
