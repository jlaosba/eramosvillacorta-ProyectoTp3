using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovaSchools.Models
{
    [Table("gsp.EstadoEmpleado")]
    public class EstadoEmpleado
    {
        [Key]
        [Required]
        public int idEstadoEmpleado { get; set; }

        [Display(Name = "Estado Empleado")]
        [Column("estadoEmpleado", TypeName = "varchar")]
        [StringLength(50)]
        public string estadoEmpleado { get; set; }
    }
}