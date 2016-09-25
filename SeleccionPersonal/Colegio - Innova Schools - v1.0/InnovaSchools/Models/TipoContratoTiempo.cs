using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovaSchools.Models
{
    [Table("gsp.TipoContratoTiempo")]
    public class TipoContratoTiempo
    {
        [Key]
        [Required]
        public int idTipoContratoTiempo { get; set; }

        [Display(Name = "Tipo Contrato Tiempo")]
        [Column("descripcionContratoTiempo", TypeName = "varchar")]
        [StringLength(50)]
        public string descripcionContratoTiempo { get; set; }
    }
}