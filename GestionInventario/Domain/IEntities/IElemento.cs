using GestionInventario.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionInventario.Domain.IEntities
{
    public interface IElemento
    {
        int Id { get; set; }
        DateTime Caducidad { get; set; }
        string Nombre { get; set; }
        ITipoElemento Tipo { get; set; }
        int TipoElementoId { get; set; }
        int Anadir();
        void Eliminar(Elemento elemento);
        int Eliminar(string nombre);
        IList<Elemento> Caducados();
    }
}
