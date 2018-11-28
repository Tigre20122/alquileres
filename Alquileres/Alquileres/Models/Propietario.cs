using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alquileres.Models
{
    public class Propietario
    {
        public int PropietarioId { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }

       
    }
}