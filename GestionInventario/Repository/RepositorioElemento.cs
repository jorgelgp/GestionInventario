using GestionInventario.Domain.Entities;
using GestionInventario.Domain.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionInventario.Repository
{
    public class RepositorioElemento : Repositorio<Elemento>, IRepositorioElemento
    {
        ApplicationDbContext _db;
        public RepositorioElemento(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IList<Elemento> Obtener(string nombre)
        {
            return _db.Elementos.Where(e => e.Nombre == nombre).ToList();
        }

        public IList<Elemento> Caducados()
        {
            return _db.Elementos.Where(e => e.Caducidad < DateTime.Now).ToList();
        }
    }
}
