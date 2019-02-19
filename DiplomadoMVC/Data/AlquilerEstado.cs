using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DiplomadoMVC.Data
{
    [Table("AlquilerEstados")]
    public class AlquilerEstado
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Estado { get; set; }

        [StringLength(150)]
        public string Descripcion { get; set; }

        public List<Alquiler> Alquiladas { get; set; }
    }
}