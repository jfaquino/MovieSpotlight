using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DiplomadoMVC.Data
{
    public class AlquilerDetalle
    {
        public int Id { get; set; }

        [Required]
        public int IdAlquiler { get; set; }

        [Required]
        public int IdPelicula { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Precio { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public int Dias { get; set; }

        [ForeignKey("IdAlquiler")]
        public Alquiler Alquiler { get; set; }

        [ForeignKey("IdPelicula")]
        public Pelicula Pelicula { get; set; }
    }
}