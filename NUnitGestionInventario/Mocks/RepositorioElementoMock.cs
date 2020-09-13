using GestionInventario.Domain.Entities;
using GestionInventario.Domain.IRepository;
using GestionInventario.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NUnitGestionInventario.Mocks
{
    public class RepositorioElementoMock : RepositorioMock<Elemento>, IRepositorioElemento
    {
        public IList<Elemento> Obtener(string nombre)
        {
           var listRetorno = new List<Elemento>();
            if (nombre == "Platano")
                listRetorno.Add(new Elemento { Id = 2, Caducidad = DateTime.Now.AddDays(2), Nombre = "Platano", TipoElementoId = 4 });
            return listRetorno;
        }

        public IList<Elemento> Caducados()
        {
            var listRetorno = new List<Elemento>();
            listRetorno.Add(new Elemento { Id = 1, Caducidad = DateTime.Now, Nombre = "Mango", TipoElementoId = 4 });
            return listRetorno;
        }
    }
}
