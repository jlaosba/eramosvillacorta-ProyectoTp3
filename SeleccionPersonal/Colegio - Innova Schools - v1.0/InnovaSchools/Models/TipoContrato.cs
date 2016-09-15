using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovaSchools.Models
{
    [Table("gsp.TipoContrato")]
    public class TipoContrato
    {
        [Key]
        [Required]
        public int idTipoContrato { get; set; }

        [Display(Name = "Tipo Contrato")]
        [Column("descripcionContrato", TypeName = "varchar")]
        [StringLength(50)]
        public string descripcionContrato { get; set; }
    }
}