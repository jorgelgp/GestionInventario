using GestionInventario.Domain.IEntities;
using GestionInventario.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionInventario.Domain.Entities
{
    public class TipoElemento : Entidad, ITipoElemento
    {
        private readonly IRepositorioTipoElemento _repositorio;
        public TipoElemento() { }
        public TipoElemento(IRepositorioTipoElemento repositorio)
        {
            _repositorio = repositorio;
        }
        public string Descripcion { get; set; }

        public IEnumerable<ITipoElemento> ObtenerTodos()
        {
            return _repositorio.ObtenerTodos();
        }
    }
}
