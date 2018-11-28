using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alquileres.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        [Display(Name = "Nombres")]
        [Required]
        public string Nombres { get; set; }
        [Display(Name = "Apellidos")]
        [Required]
        public string Apellidos { get; set; }
        [Display(Name = "Telefono")]
        [Required]
        public string Telefono { get; set; }
        [Display(Name = "Correo")]
        [Required]
        public string Correo { get; set; }
        [Display(Name = "Categoria")]
        [Required]
        public string Categoria { get; set; }
        [Display(Name = "Garantia")]
        [Required]
        public string Garantia { get; set; }
        [Display(Name = "Fecha")]
        [Required]
        public DateTime FechaIngreso { get; set; }

    }
}