using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovaSchools.Models
{
    [Table("gsp.Puesto")]
    public class Puesto
    {
        [Key]
        [Required]
        public int idPuesto { get; set; }

        [Display(Name = "Puesto")]
        [Column("descripcionPuesto", TypeName = "varchar")]
        [StringLength(50)]
        public string descripcionPuesto { get; set; }

        [Display(Name = "Función")]
        [Column("funcion", TypeName = "varchar")]
        [StringLength(50)]
        public string funcion { get; set; }
        
    }
}