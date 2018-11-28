using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alquileres.Models
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }

        public string PriNombre { get; set; }

        public string SegNombre { get; set; }

        public string PriApellido { get; set; }

        public string SegApellido { get; set; }

        public string Direccion { get; set; }

        public string CategoriaLaboral { get; set; }

        public string Salario { get; set; }

        public string Correo { get; set; }

        public string FechaN { get; set; }

        public string Edad { get; set; }
    }
}