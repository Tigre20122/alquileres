using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alquileres.Models
{
    public class Sucursales
    {
        [Key]
        public int SucursalId { get; set; }

        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }

        public int CiudadId { get; set; }
        public ciudad ciudad { get; set; }

        public string Barrio { get; set; }

        public string calles { get; set; }

        public string telefono { get; set; }

    }
}