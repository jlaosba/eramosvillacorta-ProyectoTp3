using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovaSchools.Models
{
    [Table("gsp.TipoPuesto")]
    public class TipoPuesto
    {
        [Key]
        [Required]
        [Column("idTipoPuesto", TypeName = "int")] 
        public int idTipoPuesto { get; set; }

        [Display(Name = "Tipo Puesto")]
        [Column("descripcionPuesto", TypeName = "varchar")]
        [StringLength(50)]
        public string descripcionPuesto { get; set; }
    }
}