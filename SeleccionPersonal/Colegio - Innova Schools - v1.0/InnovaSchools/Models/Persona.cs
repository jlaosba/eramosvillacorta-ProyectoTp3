using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovaSchools.Models
{
    [Table("t_persona")]
    public class Persona
    {
        [Key]
        [Required]
        [Display(Name = "Nro. Identidad")]
        [MaxLength(15, ErrorMessage = "El Código no puede tener más de 15 caracteres")]
        public string codigo_persona { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(15, ErrorMessage = "El Nombre no puede tener más de 15 caracteres")]
        public string nombre { get; set; }

        [Display(Name = "Ape. Paterno")]
        public string apellido_paterno { get; set; }

        [Display(Name = "Ape. Materno")]
        public string apellido_materno { get; set; }

        [Display(Name = "Persona")]
        [NotMapped]
        public string nombreCompleto
        {
            get
            {
                return string.Concat(nombre, " ", apellido_paterno, " ", apellido_materno);
            }
        }

        ////public DateTime fecha_nacimiento { get; set; }

        [Display(Name = "Dirección")]
        public string direccion { get; set; }

        [Display(Name = "Teléfono")]
        public string telefono { get; set; }

        [Display(Name = "Celular")]
        public string celular { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }


        [ForeignKey("id_puesto")]
        public virtual Puesto Puesto { get; set; }
        public int id_puesto { get; set; }


        [NotMapped]
        [Display(Name = "Fecha Inicio")]
        public String fecha_inicio { get; set; }

        [NotMapped]
        [Display(Name = "Fecha Fin")]
        public String fecha_fin { get; set; }

        [NotMapped]
        public int id_programar_persona { get; set; }

        [NotMapped]
        public bool Checked { get; set; }

        [NotMapped]
        public Turno Turno { get; set; }

        public static IList<Persona> ListaAlumnos(int idgrupo)
        {
            //BDEscolarEntities BD = new BDEscolarEntities();
            InnovaSchoolsContext BD = new InnovaSchoolsContext();

            //recuperar la lista de alumnos desde la BD
            //var alumnos = BD.Alumno.Where(a => a.IdGrupoActual == idgrupo).OrderBy(a => a.Apellidos);
            var alumnos = BD.Persona.Where(w => w.nombre.Contains("J")).OrderBy(o => o.apellido_paterno);
            return alumnos.ToList();
        }


    }
}