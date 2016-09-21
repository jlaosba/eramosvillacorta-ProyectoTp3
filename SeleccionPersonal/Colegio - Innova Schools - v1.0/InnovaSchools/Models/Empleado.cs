using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovaSchools.Models
{
    [Table("gsp.Empleado")]
    public class Empleado
    {
        //[Required(AllowEmptyStrings = true)]
        [Key]
        [Required]
        public int idEmpleado { get; set; }

        [ForeignKey("idCandidato")]
        public virtual Candidato Candidato { get; set; }
        public int idCandidato { get; set; }

        [ForeignKey("idFondoPensiones")]
        public virtual FondoPensiones FondoPensiones { get; set; }
        public int idFondoPensiones { get; set; }
        
        [ForeignKey("idSeguro")]
        public virtual Seguro Seguro { get; set; }
        public int idSeguro { get; set; }

        [ForeignKey("idEstadoEmpleado")]
        public virtual EstadoEmpleado EstadoEmpleado { get; set; }
        public int idEstadoEmpleado { get; set; }

        [ForeignKey("idBanco")]
        public virtual Banco Banco { get; set; }
        public int idBanco { get; set; }

        [ForeignKey("idNivelEstudio")]
        public virtual NivelEstudio NivelEstudio { get; set; }
        public int idNivelEstudio { get; set; }

        [Display(Name = "Contacto Emergencia")]
        [Column("contactoEmergencia", TypeName = "varchar")]
        [StringLength(50)]
        public string contactoEmergencia { get; set; }

        [Display(Name = "Teléfono Emergencia")]
        [Column("telefonoEmergencia", TypeName = "varchar")]
        [StringLength(15)]
        public string telefonoEmergencia { get; set; }

        [Display(Name = "Cuenta")]
        [Column("cuentaBanco", TypeName = "varchar")]
        [StringLength(15)]
        public string cuentaBanco { get; set; }

        [Display(Name = "Código Fotocheck")]
        [Column("codigoFotocheck", TypeName = "varchar")]
        [StringLength(50)]
        public string codigoFotocheck { get; set; }


        [Display(Name = "Nombre Empleado")]
        [NotMapped]
        public string nombreCompleto
        {
            get
            {
                return string.Concat(Candidato.Persona.nombre, " ", Candidato.Persona.apellidoPaterno, " ", Candidato.Persona.apellidoMaterno);
            }
        }

        //public virtual ICollection<Contrato> Contratos { get; set; } 
    }
}