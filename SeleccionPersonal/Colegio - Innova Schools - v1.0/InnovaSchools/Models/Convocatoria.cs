using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovaSchools.Models
{
    [Table("t_convocatoria")]
    public class Convocatoria
    {
        [Key]
        [Required]
        public string id_convocatoria { get; set; }

        [Display(Name = "Fecha Inicio")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fechaInicioPublicacion { get; set; }

        [Display(Name = "Fecha Fin")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fechaFinPublicacion { get; set; }

        [Display(Name = "Nro. Vacantes")]
        public int numeroVacantes { get; set; }

        [Display(Name = "Tipo Convocatoria")]
        public string tipoConvocatoria { get; set; }

        [Display(Name = "año de experiencia")]
        public int añoExperiencia { get; set; }

        [Display(Name = "Conocimiento")]
        public string conocimiento { get; set; }

        [ForeignKey("id_puesto")]
        public virtual Puesto Puesto { get; set; }
        public int id_puesto { get; set; }
        

    }
}