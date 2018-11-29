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
        [Display(Name="Empleado")]
        [Required]
        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }
        [Display(Name="Ciudad")]
        [Required]
        public int CiudadId { get; set; }
        public ciudad ciudad { get; set; }
        [Display(Name="Barrio")]
        [Required]
        public string Barrio { get; set; }
        [Display(Name="Barrio")]
        [Required]
        public string calles { get; set; }
        [Display(Name="Telefono")]
        [Required]
        public string telefono { get; set; }
    }
}