using GestionInventario.Domain.Entities;
using GestionInventario.Domain.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionInventario.Repository
{
    public class Repositorio<T> : IRepositorio<T> where T : Entidad, new()
    {
        private ApplicationDbContext _db;
        public Repositorio(ApplicationDbContext db)
        {
            _db = db;
        }

        public int Anadir(T entidad)
        {
            _db.Entry(entidad).State = EntityState.Added;
            _db.SaveChanges();
            return entidad.Id;
        }

        public void Eliminar(T entidad)
        {
            _db.Entry(entidad).State = EntityState.Deleted;
            _db.SaveChanges();

        }
        public IList<T> ObtenerTodos()
        {
            return _db.Set<T>().ToList<T>();
        }
    }
}
