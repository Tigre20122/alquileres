using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alquileres.Models
{
    public class Empleado
    {
        [Key]
        public int EmpleadoId { get; set; }
        [Display(Name ="Nombres")]
        [Required]
        public string Nombres { get; set; }
        [Display(Name = "Apellidos")]
        [Required]
        public string Apellidos { get; set; }
        [Display(Name = "Direccion")]
        [Required]
        public string Direccion { get; set; }
        [Display(Name = "Cargo")]
        [Required]
        public string Cargo { get; set; }
        [Display(Name = "Salario")]
        [Required]
        public string Salario { get; set; }
        [Display(Name = "Correo")]
        [Required]
        public string Correo { get; set; }
        [Display(Name = "Fecha")]
        [Required]
        public string Fecha { get; set; }
        [Display(Name = "Edad")]
        [Required]
        public string Edad { get; set; }
    }
}