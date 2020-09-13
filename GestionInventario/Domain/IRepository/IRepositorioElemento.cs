using GestionInventario.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionInventario.Domain.IRepository
{
    public interface IRepositorioElemento : IRepositorio<Elemento>
    {
        IList<Elemento> Obtener(string nombre);
        IList<Elemento> Caducados();
    }
}
