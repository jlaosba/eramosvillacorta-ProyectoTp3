using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovaSchools.Models
{
    [Table("gsp.Seguro")]
    public class Seguro
    {
        [Key]
        [Required]
        public int idSeguro { get; set; }

        [Display(Name = "Seguro")]
        [Column("descripcionSeguro", TypeName = "varchar")]
        [StringLength(50)]
        public string descripcionSeguro { get; set; }
    }
}