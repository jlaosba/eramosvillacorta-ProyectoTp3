using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovaSchools.Models
{
    [Table("gsp.Persona")]
    public class Persona
    {
        [Key]
        [Required]
        [Display(Name = "Nro. Identidad")]
        //[MaxLength(15, ErrorMessage = "El Código no puede tener más de 15 caracteres")]
        public int idPersona { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(20, ErrorMessage = "El Nombre no puede tener más de 15 caracteres")]
        [Column("nombre", TypeName = "varchar")]
        [StringLength(20)]
        public string nombre { get; set; }

        [Display(Name = "Ape. Paterno")]
        [Column("apellidoPaterno", TypeName = "varchar")]
        [StringLength(50)]
        public string apellidoPaterno { get; set; }

        [Display(Name = "Ape. Materno")]
        [Column("apellidoMaterno", TypeName = "varchar")]
        [StringLength(50)]
        public string apellidoMaterno { get; set; }

        [Display(Name = "Persona")]
        [NotMapped]
        public string nombreCompleto
        {
            get
            {
                return string.Concat(nombre, " ", apellidoPaterno, " ", apellidoMaterno);
            }
        }

        [Display(Name = "Dirección")]
        [Column("direccion", TypeName = "varchar")]
        [StringLength(20)]
        public string direccion { get; set; }

        [Display(Name = "Teléfono")]
        [Column("telefono", TypeName = "varchar")]
        [StringLength(15)]
        public string telefono { get; set; }

        [Display(Name = "Celular")]
        [Column("celular", TypeName = "varchar")]
        [StringLength(15)]
        public string celular { get; set; }

        [Display(Name = "Correo Electrónico")]
        [Column("correoElectronico", TypeName = "varchar")]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string correoElectronico { get; set; }

        [ForeignKey("idNacionalidad")]
        public virtual Nacionalidad Nacionalidad { get; set; }
        public int idNacionalidad { get; set; }

        [ForeignKey("idDocumentoIdentidad")]
        public virtual DocumentoIdentidad DocumentoIdentidad { get; set; }
        public int idDocumentoIdentidad { get; set; }

        //[ForeignKey("idTipoDocumento")]
        //public virtual TipoDocumento TipoDocumento { get; set; }
        //public int idTipoDocumento { get; set; }

        [Display(Name = "Documento")]
        public string documentoIdentidad { get; set; }
        
        [Display(Name = "Genero")]
        [Column("genero", TypeName = "varchar")]
        [StringLength(20)]
        public string genero { get; set; }

        [Display(Name = "Nro Hijos")]
        public int nroHijos { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fechaNacimiento { get; set; }

        [ForeignKey("idEstadoCivil")]
        public virtual EstadoCivil EstadoCivil { get; set; }
        public int idEstadoCivil { get; set; }

        [NotMapped]
        [Display(Name = "Fecha Inicio")]
        public String fecha_inicio { get; set; }

        [NotMapped]
        [Display(Name = "Fecha Fin")]
        public String fecha_fin { get; set; }

        
        public static IList<Persona> ListaAlumnos(int idgrupo)
        {
            //BDEscolarEntities BD = new BDEscolarEntities();
            InnovaSchoolsContext BD = new InnovaSchoolsContext();

            //recuperar la lista de alumnos desde la BD
            //var alumnos = BD.Alumno.Where(a => a.IdGrupoActual == idgrupo).OrderBy(a => a.Apellidos);
            var alumnos = BD.Persona.Where(w => w.nombre.Contains("J")).OrderBy(o => o.apellidoPaterno);
            return alumnos.ToList();
        }


    }
}