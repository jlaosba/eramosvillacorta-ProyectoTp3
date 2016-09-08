using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovaSchools.Models
{
    [Table("t_turno")]
    public class Turno
    {
        [Key]
        [Required]
        public int id_turno { get; set; }

        [Display(Name = "Turno")]
        public string descripcion_turno { get; set; }

    }
}