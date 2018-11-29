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
        [Display(Name = "Cliente")]
        [Required]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        [Display(Name = "Inmueble")]
        [Required]
        public int InmuebleId { get; set; }
        public Inmuebles Inmuebles { get; set; }
        [Display(Name = "FormaPago")]
        [Required]
        public string ModoPago { get; set; }
        [Display(Name = "Duracion del Contrato")]
        [Required]
        public string DuracionContrato { get; set; }
        [Display(Name = "Fecha Inicio")]
        [Required]
        public DateTime FechaInicio { get; set; }
        [Display(Name = "Fecha Fin")]
        [Required]
        public DateTime FechaFin { get; set; }
    }
}