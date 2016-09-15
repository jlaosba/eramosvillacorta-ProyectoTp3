using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovaSchools.Models
{
    [Table("gsp.Banco")]
    public class Banco
    {
        [Key]
        [Required]
        public int idBanco { get; set; }

        [Display(Name = "Banco")]
        [Column("nombreBanco", TypeName = "varchar")]
        [StringLength(70)]
        public string nombreBanco { get; set; }

        [Display(Name = "Prefijo Cuenta")]
        [Column("prefijoCuenta", TypeName = "varchar")]
        [StringLength(4)]
        public string prefijoCuenta { get; set; }

        //[Display(Name = "Cuenta")]
        //public string cuenta { get; set; }
        
    }
}