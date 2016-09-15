using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovaSchools.Models
{
    [Table("gsp.Candidato")]
    public class Candidato
    {
        //[Key]
        //[Required]
        //[Column(Order = 1)]
        //public int idConvocatoria { get; set; }

        [Key]
        [Required]
        //[Column(Order = 2)]        
        public int idCandidato { get; set; }
        //public virtual Convocatoria Convocatoria { get; set; }

        [ForeignKey("idPersona")]        
        public virtual Persona Persona { get; set; }
        public int idPersona { get; set; }

        [ForeignKey("idEstadoCandidato")]
        public virtual EstadoCandidato EstadoCandidato { get; set; }
        public int idEstadoCandidato { get; set; }

        //[ForeignKey("idEmpleado")]
        //public virtual Empleado Empleado { get; set; }       
        //[Required(AllowEmptyStrings = true)]
        //public int? idEmpleado { get; set; }

        [Display(Name = "Nombre Candidato")]
        [NotMapped]
        public string nombreCompleto
        {
            get
            {
                return string.Concat(Persona.nombre, " ", Persona.apellidoPaterno, " ", Persona.apellidoMaterno);
            }
        }

        [Display(Name = "Copia DNI")]
        [Column("rutaImgDni", TypeName = "varchar")]
        [StringLength(700)]
        public string rutaImgDni { get; set; }

        [Display(Name = "Declaración Jurada Domiciliaria")]
        [Column("rutaImgDeclaracionJurada", TypeName = "varchar")]
        [StringLength(700)]
        public string rutaImgDeclaracionJurada { get; set; }

        [Display(Name = "Antecedentes Penales")]
        [Column("rutaImgAntecedentesPenales", TypeName = "varchar")]
        [StringLength(700)]
        public string rutaImgAntecedentesPenales { get; set; }

        [Display(Name = "Antecedentes Policiales")]
        [Column("rutaImgAntecedentesPoliciales", TypeName = "varchar")]
        [StringLength(700)]
        public string rutaImgAntecedentesPoliciales { get; set; }

        [Display(Name = "Título Profesional")]
        [Column("rutaImgTituloProfesional", TypeName = "varchar")]
        [StringLength(700)]
        public string rutaImgTituloProfesional { get; set; }

        public string estado { get; set; }

    }
}