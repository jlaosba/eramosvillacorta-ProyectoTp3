using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovaSchools.Models
{
    [Table("gsp.Reporte")]
    public class Reporte
    {
        [Key]
        [Required]
        public int idEmpleado { get; set; }

        [Display(Name = "Documento")]
        public string documentoIdentidad { get; set; }

        [Display(Name = "Nombre Completo")]
        public string nombreCompleto { get; set; }

        [Display(Name = "Puesto")]
        [Column("descripcionPuesto", TypeName = "varchar")]
        [StringLength(50)]
        public string descripcionPuesto { get; set; }

        [Display(Name = "Fecha Ingreso")]
        public String fechaIngresoStr { get; set; }

        [Display(Name = "Contrato")]
        [Column("descripcionContrato", TypeName = "varchar")]
        [StringLength(50)]
        public string descripcionContrato { get; set; }
    }
}