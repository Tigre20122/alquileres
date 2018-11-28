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
        [Display(Name ="calle")]
        [Required]
        public string calle { get; set; }
        [Display(Name = "colonia")]
        [Required]
        public string colonia { get; set; }
        [Display(Name = "ciudad")]
        [Required]
        public string ciudad { get; set; }
        [Display(Name = "departamento")]
        [Required]
        public string departamento { get; set; }
     

    }
}