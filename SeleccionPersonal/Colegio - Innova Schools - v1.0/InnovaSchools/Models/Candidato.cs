using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovaSchools.Models
{
    [Table("t_candidato")]
    public class Candidato
    {
        [Key]
        [Required]
        [Column(Order = 1)] 
        public string id_convocatoria { get; set; }

        [Key]
        [Required]
        [Column(Order = 2)] 
        public int id_candidato { get; set; }

        public virtual Persona Persona { get; set; }
        public string codigo_persona { get; set; }

        [Display(Name = "Copia DNI")]
        public string rutaImgDni { get; set; }

        [Display(Name = "Declaración Jurada Domiciliaria")]
        public string rutaImgDeclaracionJurada { get; set; }

        [Display(Name = "Antecedentes Penales")]
        public string rutaImgAntecedentesPenales { get; set; }

        [Display(Name = "Antecedentes Policiales")]
        public string rutaImgAntecedentesPoliciales { get; set; }

        [Display(Name = "Título Profesional")]
        public string rutaImgTituloProfesional { get; set; }

        public string estado { get; set; }
               
        

    }
}