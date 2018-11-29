﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alquileres.Models
{
    public class ciudad
    {
        [Key]
        public int CiudadId { get; set; }
        [Display(Name ="Detalle")]
        public string Detalle { get; set; }

        //

        public int ProvinciaId { get; set; }
        public Provincia Provincias { get; set; }
    }
}