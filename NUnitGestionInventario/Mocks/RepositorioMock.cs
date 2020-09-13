using GestionInventario.Domain.Entities;
using GestionInventario.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitGestionInventario.Mocks
{
    public class RepositorioMock<T> : IRepositorio<T> where T : Entidad, new()
    {
        public int Anadir(T entidad)
        {
            entidad.Id = 5;
            return entidad.Id;
        }

        public void Eliminar(T entidad)
        {

        }
        public IList<T> ObtenerTodos()
        {
            IList<T> retornoGenerico = new List<T>();
            var listRetorno = new List<Entidad>();
            T entidad = new T();
            if (entidad is TipoElemento)
            {
                listRetorno.Add(new TipoElemento { Id = 1, Descripcion = "Lacteo"});
                listRetorno.Add(new TipoElemento { Id = 2, Descripcion = "Carnico" });
                listRetorno.Add(new TipoElemento { Id = 3, Descripcion = "Verdura" });
                listRetorno.Add(new TipoElemento { Id = 4, Descripcion = "Fruta" });
            }
            else if (entidad is Elemento)
            {
                listRetorno.Add(new Elemento { Id = 1 , Caducidad = DateTime.Now, Nombre = "Mango", TipoElementoId = 4 });
                listRetorno.Add(new Elemento { Id = 2, Caducidad = DateTime.Now.AddDays(2), Nombre = "Platano", TipoElementoId = 4 });
            }

            foreach (var item in listRetorno)
            {
                retornoGenerico.Add((T)item);
            }
            
            return retornoGenerico;
        }
    }
}
