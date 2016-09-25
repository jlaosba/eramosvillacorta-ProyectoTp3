using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovaSchools.Models
{
    [Table("gsp.NivelEstudio")]
    public class NivelEstudio
    {
        [Key]
        [Required]
        public int idNivelEstudio { get; set; }

        [Display(Name = "Grado Estudio")]
        [Column("gradoEstudio", TypeName = "varchar")]
        [StringLength(50)]
        public string gradoEstudio { get; set; }
    }
}