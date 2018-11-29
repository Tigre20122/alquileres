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

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int PropietarioId { get; set; }
        public Propietario Propietario { get; set; }

        public int InmuebleId { get; set; }
        public Inmuebles Inmuebles { get; set; }

        public string ModoPago { get; set; }
        public string DuracionContrato { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}