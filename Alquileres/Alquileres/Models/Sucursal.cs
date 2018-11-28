using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alquileres.Models
{
    public class Sucursales
    {
        [Key]
        public int SucursalId { get; set; }
        
        public string MyProperty { get; set; }
    }
}