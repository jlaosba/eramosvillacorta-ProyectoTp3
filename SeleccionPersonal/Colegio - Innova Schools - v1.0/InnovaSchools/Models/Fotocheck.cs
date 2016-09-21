using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovaSchools.Models
{
    [Table("gsp.Fotocheck")]
    public class Fotocheck
    {
        [Key]
        [Required]
        public int idFotocheck { get; set; }

        //[ForeignKey("idEmpleado")]
        //public virtual Empleado Empleado { get; set; }
        //public int idEmpleado { get; set; }

        //[ForeignKey("idContrato")]
        //public virtual Contrato Contrato { get; set; }
        //public int idContrato { get; set; }


    }
}