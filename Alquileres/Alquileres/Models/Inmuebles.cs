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
        [Display(Name = "barrio")]
        [Required]
        public string barrio { get; set; }
        [Display(Name = "ciudad")]
        [Required]

        public int CiudadId { get; set; }
        public ciudad ciudades { get; set; }

        [Display(Name = "departamento")]
        [Required]
        public string departamento { get; set; }
        [Display(Name = "tipo")]
        [Required]
         public string tipo { get; set; }
        [Display(Name = "Numero de habitaciones")]
        [Required]
        public string NumeroHabitaciones { get; set; }

        [Display(Name = "Costo Mensual")]
        [Required]
        public string CostoMensual { get; set; }

        [Display(Name = "Propietario")]
        [Required]
        public int PropietarioId { get; set; }
        public Propietario Propietarios { get; set; }
    }
}