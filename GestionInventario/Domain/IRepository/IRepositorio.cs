using GestionInventario.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionInventario.Domain.IRepository
{
    public interface IRepositorio<T> where T : Entidad
    {
        int Anadir(T entidad);
        void Eliminar(T entidad);

        IList<T> ObtenerTodos();
    }
}
