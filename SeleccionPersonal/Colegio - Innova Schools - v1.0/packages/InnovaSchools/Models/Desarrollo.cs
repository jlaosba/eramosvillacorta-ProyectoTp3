using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovaSchools.Models
{
    [Table("gsp.Desarrollo")]
    public class Desarrollo
    {
        [Key]
        [Required]
        public int idDesarrollo { get; set; }

        [Display(Name = "Desarrollo")]
        [Column("descripcionDesarrollo", TypeName = "varchar")]
        [StringLength(50)]
        public string descripcionDesarrollo { get; set; }
    }
}