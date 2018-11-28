using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alquileres.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Categoria { get; set; }
        public string Garantia { get; set; }
        public DateTime FechaIngreso { get; set; }

    }
}