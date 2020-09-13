using GestionInventario.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionInventario.Repository
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var _context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (_context.TiposElementos.Any())
                {
                    return;
                }

                _context.TiposElementos.AddRange(
                    new TipoElemento { Id = 1, Descripcion = "Lacteo" },
                    new TipoElemento { Id = 2, Descripcion = "Carnico" }
                 );

                _context.SaveChanges();

                if (_context.Elementos.Any())
                {
                    return;
                }

                _context.Elementos.AddRange(
                    new Elemento { Id = 1, Nombre = "Yogurt", TipoElementoId = 1, Caducidad = DateTime.MinValue },
                    new Elemento { Id = 2, Nombre = "Lomo de Cerdo", TipoElementoId = 2, Caducidad = DateTime.Now }
                    //new Elemento { Id = 2, Nombre = "Lomo de Cerdo", TipoElementoId = 2, Caducidad = DateTime.Now.AddDays(1) }
                 );

                _context.SaveChanges();

            }
        }
    }
}
