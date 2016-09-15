using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovaSchools.Models
{
    [Table("gsp.FondoPensiones")]
    public class FondoPensiones
    {
        [Key]
        [Required]
        public int idFondoPensiones { get; set; }

        [Display(Name = "Fondo Pensiones")]
        public string fondoPensiones { get; set; }
    }
}