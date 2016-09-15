using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovaSchools.Models
{
    [Table("gsp.Estado")]
    public class Estado
    {
        [Key]
        [Required]
        public int id_estado { get; set; }

        [Display(Name = "Estado")]
        public string descripcion_estado { get; set; }        
    }
}