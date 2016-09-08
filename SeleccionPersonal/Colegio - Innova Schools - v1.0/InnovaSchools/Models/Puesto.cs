using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovaSchools.Models
{
    [Table("t_puesto")]
    public class Puesto
    {
        [Key]
        [Required]
        public int id_puesto { get; set; }

        [Display(Name = "Puesto")]
        public string descripcion_puesto { get; set; }

        [Display(Name = "Función")]
        public string funcion { get; set; }
        
        //public virtual List<Persona> Personas { get; set; }
    }
}