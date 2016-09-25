using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovaSchools.Models
{
    [Table("gsp.Contrato")]
    public class Contrato
    {
        [Key]
        [Required]
        [Display(Name = "Nro. Contrato")]
        public int idContrato { get; set; }

        [Display(Name = "Nro. Contrato")]
        [Column("contactoEmergencia", TypeName = "varchar")]        
        [StringLength(20)]
        public String nroContrato { get; set; }

        [Display(Name = "Fecha Inicio Contrato")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]        
        public DateTime fechaInicioContrato { get; set; }

        [NotMapped]
        [Display(Name = "Fecha Inicio")]
        public String fechaInicioContratoStr { get; set; }

        [Display(Name = "Fecha Cese")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]        
        public DateTime fechaFinContrato { get; set; }

        [NotMapped]
        [Display(Name = "Fecha Fin")]
        public String fechaFinContratoStr { get; set; }

        [ForeignKey("idEmpleado")]
        public virtual Empleado Empleado { get; set; }
        public int idEmpleado { get; set; }
        
        [Display(Name = "Salario")]
        public decimal salario { get; set; }

        [ForeignKey("idTipoContrato")]
        public virtual TipoContrato TipoContrato { get; set; }
        public int idTipoContrato { get; set; }
        public int idTipoContratoTiempo { get; set; }
        
        //[ForeignKey("idPuesto")]
        //public virtual Puesto Puesto { get; set; }
        //public int idPuesto { get; set; }

        [ForeignKey("idConvocatoria")]
        public virtual Convocatoria Convocatoria { get; set; }
        public int idConvocatoria { get; set; }

    }
}