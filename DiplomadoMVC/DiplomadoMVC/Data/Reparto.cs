using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DiplomadoMVC.Data
{
    [Table("Reparto")]
    public class Reparto
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Pelicula")]
        public int IdPelicula { get; set; }

        [Required]
        [Display(Name = "Actor")]
        public int IdActor { get; set; }

        [ForeignKey("IdPelicula")]
        public Pelicula Pelicula { get; set; }

        [ForeignKey("IdActor")]
        public Actor Actor { get; set; }
    }
}