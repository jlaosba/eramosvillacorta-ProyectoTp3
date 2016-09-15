using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovaSchools.Models
{
    [Table("gsp.TipoDocumento")]
    public class TipoDocumento
    {
        [Key]
        [Required]
        public int idTipoDocumento { get; set; }

        [Display(Name = "Tipo Documento")]
        [Column("descripcionDocumento", TypeName = "varchar")]
        [StringLength(50)]
        public string descripcionDocumento { get; set; }
    }
}