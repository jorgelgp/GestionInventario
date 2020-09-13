using GestionInventario.Domain.IEntities;
using GestionInventario.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionInventario.Domain.Entities
{
    public class Elemento : Entidad, IElemento
    {
        private readonly IRepositorioElemento _repositorio;

        public Elemento() { }
        public Elemento(IRepositorioElemento repositorio)
        {
            _repositorio = repositorio;
        }
        public string Nombre { get; set; }
        public DateTime Caducidad { get; set; }
        public ITipoElemento Tipo { get; set; }

        public int TipoElementoId { get; set; }

        public int Anadir()
        {
            _repositorio.Anadir(this);
            return this.Id;
        }

        public IList<Elemento> Obtener(string nombre)
        {
            return _repositorio.Obtener(nombre);
        }

        public IList<Elemento> Caducados()
        {
            return _repositorio.Caducados();
        }

        public int Eliminar(string nombre)
        {
            int eliminados = 0;
            var elementos = this.Obtener(nombre);
            foreach (var elemento in elementos)
            {
                this.Eliminar(elemento);
                eliminados = eliminados + 1;
            }
            return eliminados;
        }

        public void Eliminar(Elemento elemento)
        {
            _repositorio.Eliminar(elemento);
        }
    }
}
