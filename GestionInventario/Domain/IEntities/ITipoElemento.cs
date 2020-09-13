using System.Collections.Generic;

namespace GestionInventario.Domain.IEntities
{
    public interface ITipoElemento
    {
        string Descripcion { get; set; }
        IEnumerable<ITipoElemento> ObtenerTodos();
    }
}