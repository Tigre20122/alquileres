using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alquileres.Models
{
    public class Contrato
    {
        [Key]
        public int ContratoId { get; set; }
    }
}