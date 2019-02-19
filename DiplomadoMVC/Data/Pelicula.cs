using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DiplomadoMVC.Data
{
    [Table("Peliculas")]
    public class Pelicula
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Formato")]
        public int IdFormato { get; set; }

        [Required]
        [Display(Name = "Género")]
        public int IdGenero { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [StringLength(50)]
        public string Foto { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Año")]
        public int Anio { get; set; }

        [Required]
        public string Sinopsis { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Precio { get; set; }

        [Display(Name = "Puntuación")]
        [DisplayFormat(DataFormatString = "{0:N1}", ApplyFormatInEditMode = true)]
        public decimal Puntuacion { get; set; }


        [ForeignKey("IdFormato")]
        public Formato Formato { get; set; }

        [ForeignKey("IdGenero")]
        public Genero Genero { get; set; }        
    }
}