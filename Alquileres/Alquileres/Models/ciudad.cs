using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alquileres.Models
{
    public class ciudad
    {
        [Key]
        public int CiudadId { get; set; }
        [Display()]
        public string Detalle { get; set; }
    }
}