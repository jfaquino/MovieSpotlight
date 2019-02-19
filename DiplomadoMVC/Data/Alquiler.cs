using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DiplomadoMVC.Data
{
    [Table("Alquiler")]
    public class Alquiler
    {
        public int Id { get; set; }

        [Required]
        public int IdCliente { get; set; }
        
        public int? IdEstado { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Fecha { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Total { get; set; }

        [StringLength(150)]
        public string Observaciones { get; set; }
        
        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; }

        [ForeignKey("IdEstado")]
        public AlquilerEstado Estado { get; set; }

        public List<AlquilerDetalle> AlquilerDetalles { get; set; }
    }
}