using GestionInventario.Domain.Entities;
using GestionInventario.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionInventario.Repository
{
    public class RepositorioTipoElemento : Repositorio<TipoElemento>, IRepositorioTipoElemento
    {
        public RepositorioTipoElemento(ApplicationDbContext db) : base(db){ }
    }
}
