using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
 
namespace Alquileres.Models
{
    public class Inmuebles
    {
        [Key]
        public int InmuebleId { get; set; }
        [Display(Name ="CALLE")]
        [Required]

        public string calle { get; set; }
        [Display(Name = "COLONIA")]
        [Required]
        public string colonia { get; set; }
        [Display(Name = "CIUDAD")]
        [Required]
        public string ciudad { get; set; }
        [Display(Name = "DEPARTAMENTO")]
        [Required]
        public string departamento { get; set; }
        [Display(Name = "TIPO")]
        [Required]
         public string tipo { get; set; }

    }
}