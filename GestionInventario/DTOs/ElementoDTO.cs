using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionInventario.DTOs
{
    public class ElementoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Caducidad { get; set; }
        public int Tipo { get; set; }
    }
}
