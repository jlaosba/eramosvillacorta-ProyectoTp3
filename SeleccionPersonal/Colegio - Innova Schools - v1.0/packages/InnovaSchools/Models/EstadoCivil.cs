using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovaSchools.Models
{
    [Table("gsp.EstadoCivil")]
    public class EstadoCivil
    {
        [Key]
        [Required]
        public int idEstadoCivil { get; set; }

        [Display(Name = "Estado Civil")]
        [Column("estadoCivil", TypeName = "varchar")]
        [StringLength(50)]
        public string estadoCivil { get; set; }

    }
}