using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alquileres.Models
{
    public class Provincia
    {
        [Key]
        public int ProvinciaId { get; set; }
        [Display(Name = "Detalle")]
        [Required]
        public string Detalle { get; set; }

    }
}