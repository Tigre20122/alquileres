using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alquileres.Models
{
    public class Inmuebles
    {
        public int inmuebleId { get; set; }
        public string calle { get; set; }
        public string colonia { get; set; }
        public string ciudad { get; set; }
        public string departamento { get; set; }
        public string tipo { get; set; }

    }
}