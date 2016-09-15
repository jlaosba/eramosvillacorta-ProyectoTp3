using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovaSchools.Models
{
    [Table("gsp.EstadoCandidato")]
    public class EstadoCandidato
    {
        [Key]
        [Required]
        public int idEstadoCandidato { get; set; }

        [Display(Name = "Estado")]
        [Column("estadoCandidato", TypeName = "varchar")]
        [StringLength(50)]
        public string estadoCandidato { get; set; }
    }
}