using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DiplomadoMVC.Data
{
    [Table("Entradas")]
    public class Entrada
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El {0} es obligatorio")]
        [StringLength(150, ErrorMessage = "La longitud del {0} debe ser máximo de 150 carácteres")]
        [MinLength(5, ErrorMessage = "La longuitud de {0} debe ser al menos de 5 carácteres")]
        public string Titulo { get; set; }

        [Required]
        public int IdCategoria { get; set; }

        [StringLength(100)]
        public string Foto { get; set; }

        [Required(ErrorMessage = "La {0} es obligatoria")]
        [StringLength(150, ErrorMessage = "La longitud del {0} debe ser máximo de 150 carácteres")]
        [MinLength(5, ErrorMessage = "La longuitud de {0} debe ser al menos de 5 carácteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La {0} es obligatoria")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Contenido { get; set; }

        [ForeignKey("IdCategoria")]
        public Categoria Categoria { get; set; }

        public List<Comentario> Comentarios { get; set; }

        

    }
}