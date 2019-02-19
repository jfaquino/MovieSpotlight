using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DiplomadoMVC.Data
{
    [Table("Generos")]
    public class Genero
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Genero")]
        [StringLength(100)]
        public string Nombre { get; set; }
        
        [StringLength(150)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        public List<Pelicula> Peliculas { get; set; }
    }
}