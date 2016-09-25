using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovaSchools.Models
{
    [Table("gsp.Convocatoria")]
    public class Convocatoria
    {
        [Key]
        [Required]
        public int idConvocatoria { get; set; }

        [Display(Name = "Fecha Inicio")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fechaInicioPublicacion { get; set; }

        [Display(Name = "Fecha Fin")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fechaFinPublicacion { get; set; }

        [NotMapped]
        [Display(Name = "Fecha Fin Convocatoria")]
        public String fechaFinPublicacionStr { get; set; }


        [Display(Name = "Nro. Vacantes")]
        public int numeroVacantes { get; set; }

        [Display(Name = "Tipo Convocatoria")]
        public string tipoConvocatoria { get; set; }

        [Display(Name = "año de experiencia")]
        public int añoExperiencia { get; set; }

        [Display(Name = "Conocimiento")]
        public string conocimiento { get; set; }

        [Display(Name = "F. Vct. Docum.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fechaVencimientoDocumento { get; set; }

        [Display(Name = "F. Vct. Docum.")]
        [NotMapped]
        public String fechaVencimientoDocumentoStr { get; set; }

        [ForeignKey("idTipoPuesto")]
        public virtual TipoPuesto TipoPuesto { get; set; }
        public int idTipoPuesto { get; set; }

        [ForeignKey("idPuesto")]
        public virtual Puesto Puesto { get; set; }
        public int idPuesto { get; set; }

        [ForeignKey("idArea")]
        public virtual Area Area { get; set; }
        public int? idArea { get; set; } 

        [ForeignKey("idDesarrollo")]
        public virtual Desarrollo Desarrollo { get; set; }
        public int? idDesarrollo { get; set; }

        //[ForeignKey("id_candidato")]
        [NotMapped]
        public virtual ConvocatoriaCandidato ConvocatoriaCandidato { get; set; }
        //public int id_candidato { get; set; }

    }
}