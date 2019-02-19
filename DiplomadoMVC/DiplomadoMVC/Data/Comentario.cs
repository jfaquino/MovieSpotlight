using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomadoMVC.Data
{
    [Table("Comentarios")]
    public class Comentario
    {
        public int Id { get; set; }
        [Required]
        public int IdEntrada { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Fecha { get; set; }

        [Required]
        [StringLength(500)]
        public string Contenido { get; set; }

        [ForeignKey("IdEntrada")]
        public Entrada Entrada { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
        
    }
}